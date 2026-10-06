# Dicas de Desenvolvimento - BlazorLab

## Estrutura de Pastas Explicada

```
BlazorLab/
├── src/
│   ├── BlazorLab.Web/
│   │   ├── Components/
│   │   │   ├── Layout/          # MainLayout, NavMenu
│   │   │   ├── Pages/           # Páginas com @page (Home, Tarefas)
│   │   │   ├── Shared/          # Componentes reutilizáveis (DemoCard, LogPanel)
│   │   │   ├── Conceitos/       # Componentes de demonstração (ChildComponenteVidaUtil)
│   │   │   ├── _Imports.razor   # Imports globais
│   │   │   ├── App.razor        # Raiz da aplicação
│   │   │   └── Routes.razor     # Definição de rotas
│   │   ├── wwwroot/             # Arquivos estáticos (CSS, JS, imagens)
│   │   ├── Data/                # Banco de dados SQLite (criado ao rodar)
│   │   ├── Program.cs           # Configuração da aplicação
│   │   ├── appsettings.json     # Configurações
│   │   └── BlazorLab.Web.csproj # Projeto Web
│   │
│   ├── BlazorLab.Application/
│   │   ├── Models/              # Entidades de domínio (Tarefa)
│   │   ├── Dtos/                # Data Transfer Objects (TarefaDto)
│   │   └── Interfaces/          # Contratos (ITarefaService, IRepository)
│   │
│   └── BlazorLab.Infrastructure/
│       ├── Data/                # DbContext (ApplicationDbContext)
│       ├── Repositories/        # Repository Pattern (Repository<T>)
│       └── Services/            # Serviços (TarefaService)
│
├── tests/
│   └── BlazorLab.Tests/
│       └── BlazorLab.Tests.csproj
│
├── docs/
│   └── roteiro.md               # Guia de aprendizado
│
├── README.md                    # Documentação principal
├── CHANGELOG.md                 # Histórico de mudanças
├── .gitignore                   # Arquivos ignorados pelo Git
└── setup.bat                    # Script de configuração
```

## Convenções de Código

### Nomenclatura
- **Classes:** PascalCase (Tarefa, TarefaService)
- **Métodos:** PascalCase (ObterTarefas, CriarTarefa)
- **Propriedades:** PascalCase (Titulo, Descricao)
- **Campos privados:** _camelCase (_repository, _logger)
- **Parâmetros:** camelCase (tarefa, id)
- **Variáveis locais:** camelCase (novaTarefa, tarefas)

### Interfaces
- Sempre começam com 'I' (IRepository<T>, ITarefaService)
- Definem contratos/abstração
- Facilitam testes e manutenção

### DTOs vs Models
```csharp
// Model - Representa dados no banco
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    // ... mapped to database table
}

// DTO - Transfere dados entre camadas
public class TarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    // ... used for API responses, component binding
}
```

## Fluxo de Dados

### Criar Tarefa
```
Tarefas.razor (componente)
    ↓ (input: CreateTarefaDto)
ITarefaService.CriarTarefaAsync()
    ↓
TarefaService (cria model)
    ↓
IRepository<Tarefa>.AdicionarAsync()
    ↓
Repository<Tarefa> (EF Core)
    ↓
ApplicationDbContext.SaveChangesAsync()
    ↓
SQLite (insere linha)
    ↓ (return: TarefaDto)
ListaTarefas.Add() (atualiza UI)
```

### Obter Tarefas
```
OnInitializedAsync()
    ↓
ITarefaService.ObterTarefasAsync()
    ↓
TarefaService
    ↓
IRepository<Tarefa>.ObterTodosAsync()
    ↓
Repository<Tarefa>.ToListAsync()
    ↓
EF Core consulta banco
    ↓
Mapeia para List<TarefaDto>
    ↓
ListaTarefas = resultado
    ↓
UI renderiza (StateHasChanged automático)
```

## Padrões Usados

### Repository Pattern
**Benefício:** Abstrai acesso a dados
```csharp
// Interface
public interface IRepository<T> where T : class
{
    Task<List<T>> ObterTodosAsync();
    Task<T?> ObterPorIdAsync(int id);
    Task<T> AdicionarAsync(T entity);
    Task<bool> AtualizarAsync(T entity);
    Task<bool> DeletarAsync(int id);
}

// Implementação
public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    // ... implementação genérica
}
```

### Service Layer
**Benefício:** Centraliza lógica de negócio
```csharp
public class TarefaService : ITarefaService
{
    private readonly IRepository<Tarefa> _repository;
    
    // DTOs → Models, Models → DTOs
    // Validações, cálculos, regras de negócio
}
```

### Dependency Injection
**Benefício:** Flexibilidade, testabilidade
```csharp
// Program.cs
builder.Services.AddScoped<ITarefaService, TarefaService>();

// Componente
@inject ITarefaService TarefaService

// Serviço recebe IRepository
public class TarefaService
{
    public TarefaService(IRepository<Tarefa> repository)
    {
        _repository = repository; // injetado
    }
}
```

## Debugging

### No Visual Studio Code
1. Abra `.vscode/launch.json` (se não existe, F5 cria)
2. Escolha "Blazor" como debugger
3. F5 para debugar com breakpoints
4. Inspecione variáveis durante execução

### No Console
```csharp
// Log manualmente
_logger.LogInformation($"Tarefa criada: {tarefa.Id}");

// No browser console (F12)
console.log('Debug message');
```

### Erro Comum: "Cannot modify read-only property"
- Use `@bind` em vez de `@onchange`
- Ou ensure a property tem `{ get; set; }`

### Erro Comum: "Type 'X' could not be resolved in the current scope"
- Adicione `@using namespace` no topo do arquivo .razor
- Ou em `_Imports.razor` para escopo global

## Performance

### Otimizações
1. **Use `@key`** em listas para rastrear items
   ```razor
   @foreach (var item in Items)
   {
       <div @key="item.Id">@item.Name</div>
   }
   ```

2. **Implemente `ShouldRender()`** para evitar re-renders desnecessários
   ```csharp
   protected override bool ShouldRender()
   {
       // Retorna false se não há mudança relevante
       return AlgoMudou;
   }
   ```

3. **Use `StateHasChanged()` sparingly**
   - Blazor detecta mudanças automaticamente em eventos
   - Use apenas quando necessário

4. **Carregue dados assincronamente**
   ```csharp
   protected override async Task OnInitializedAsync()
   {
       Tarefas = await TarefaService.ObterTarefasAsync();
   }
   ```

## Testes

### Com bUnit (Teste de Componentes)
```csharp
[Fact]
public void ComponenteRenderizaCorretamente()
{
    using var ctx = new TestContext();
    var component = ctx.RenderComponent<Tarefas>();
    
    component.Find("button").Click();
    
    Assert.Contains("Tarefa", component.Markup);
}
```

### Com xUnit (Teste de Serviços)
```csharp
[Fact]
public async Task CriarTarefa_DeveRetornarDto()
{
    var service = new TarefaService(mockRepository);
    var dto = new CreateTarefaDto { Titulo = "Teste" };
    
    var resultado = await service.CriarTarefaAsync(dto);
    
    Assert.NotNull(resultado);
    Assert.Equal("Teste", resultado.Titulo);
}
```

## Deployment

### Preparar para Produção
1. Execute `dotnet publish --configuration Release`
2. Configure variáveis de ambiente
3. Mude connectionstring para servidor real
4. Desabilite detailed error pages

## Comandos Úteis

```bash
# Restaurar dependências
dotnet restore

# Build
dotnet build
dotnet build --configuration Release

# Executar
dotnet run --project src/BlazorLab.Web

# Teste
dotnet test tests/BlazorLab.Tests

# Migrações
dotnet ef migrations add NomeDaMigracao --project src/BlazorLab.Infrastructure
dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
dotnet ef database drop --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web

# Publicar
dotnet publish --configuration Release
```

## Troubleshooting

### "Cannot find Microsoft.EntityFrameworkCore"
```bash
dotnet add package Microsoft.EntityFrameworkCore
```

### "Build fails with RZ errors"
- Verifique `@using` directives
- Confirm namespaces corretos
- Clean and rebuild: `dotnet clean && dotnet build`

### Banco de dados não existe
```bash
dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
```

### Componente não renderiza
- Verifique se é `@page` ou compartilhado
- Verifique `@rendermode InteractiveServer`
- Verifique namespace em `@namespace`

---

**Bom desenvolvimento! 🎉**
