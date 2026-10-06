# BlazorLab 🚀

Um projeto educacional completo para aprender Blazor Server com .NET 10, implementando padrões e conceitos reais do mercado de trabalho.

## Objetivo

Demonstrar como construir aplicações Blazor profissionais com:
- ✅ Arquitetura em camadas (Web, Application, Infrastructure)
- ✅ Repository Pattern e Injeção de Dependências
- ✅ Entity Framework Core com SQLite
- ✅ Ciclo de vida dos componentes Blazor
- ✅ Data binding e eventos
- ✅ Comunicação entre componentes
- ✅ Logging com Serilog
- ✅ Testes com bUnit
- ✅ Sistema prático de Tarefas (CRUD)

## Estrutura da Solução

```
BlazorLab/
├── src/
│   ├── BlazorLab.Web              # Aplicação Blazor (páginas, componentes)
│   ├── BlazorLab.Application      # Lógica de negócio (DTOs, interfaces)
│   └── BlazorLab.Infrastructure   # Dados (EF Core, repositories, serviços)
├── tests/
│   └── BlazorLab.Tests            # Testes com xUnit e bUnit
└── docs/
    └── roteiro.md                 # Guia de aprendizado
```

## Como Rodar

### Pré-requisitos
- .NET 10 SDK
- Visual Studio Code ou Visual Studio

### Executar

1. **Clone e acesse o projeto:**
   ```bash
   cd BlazorLab
   ```

2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

3. **Aplique as migrações (criar banco de dados):**
   ```bash
   dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
   ```

4. **Execute a aplicação:**
   ```bash
   cd src/BlazorLab.Web
   dotnet run
   ```

5. **Acesse em:** `https://localhost:7001`

## Navegação

### 📚 Conceitos Básicos
- **Home** - Visão geral dos tópicos
- **Ciclo de Vida** (`/conceitos/ciclo-de-vida`) - Métodos do ciclo de vida dos componentes
- **Data Binding** (`/conceitos/data-binding`) - Binding, eventos e listas

### 🔗 Avançado
- **Sistema de Tarefas** (`/tarefas`) - CRUD completo com:
  - Repository Pattern
  - Service Layer
  - Entity Framework Core
  - Injeção de Dependências
  - Tratamento de erros e loading states

## Módulos de Aprendizado

### 1. Ciclo de Vida Blazor
Aprenda quando cada método é chamado:
- `SetParametersAsync()`
- `OnInitialized()` / `OnInitializedAsync()`
- `OnParametersSet()` / `OnParametersSetAsync()`
- `ShouldRender()`
- `OnAfterRender()` / `OnAfterRenderAsync()`
- `DisposeAsync()`

**Demo Interativa:** Botões para alterar parâmetros, forçar re-render e ver o log de eventos.

### 2. Data Binding e Eventos
- One-way binding: `@valor`
- Two-way binding: `@bind="propriedade"`
- Events: `@onclick`, `@onsubmit`, `@onchange`
- Renderização condicional e listas com `@key`

### 3. Arquitetura em Camadas

#### Application Layer (BlazorLab.Application)
- **Models:** Entidades do domínio (Tarefa)
- **DTOs:** Transferência de dados (CreateTarefaDto, TarefaDto)
- **Interfaces:** Contratos (ITarefaService, IRepository)

#### Infrastructure Layer (BlazorLab.Infrastructure)
- **Data:** DbContext e configurações do EF Core
- **Repositories:** Implementação genérica do Repository Pattern
- **Services:** Lógica de negócio (TarefaService)

#### Web Layer (BlazorLab.Web)
- **Components:** Componentes Razor reutilizáveis
- **Pages:** Páginas interativas
- **Program.cs:** Configuração de DI e middleware

### 4. Repository Pattern

```csharp
// Injeção
IRepository<Tarefa> _repository

// Uso
var tarefas = await _repository.ObterTodosAsync();
var tarefa = await _repository.ObterPorIdAsync(id);
await _repository.AdicionarAsync(novaTarefa);
await _repository.AtualizarAsync(tarefa);
await _repository.DeletarAsync(id);
```

### 5. Injeção de Dependências

Em `Program.cs`:
```csharp
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

Nos componentes:
```csharp
@inject ITarefaService TarefaService

protected override async Task OnInitializedAsync()
{
    Tarefas = await TarefaService.ObterTarefasAsync();
}
```

## Componentes Reutilizáveis

### DemoCard
Moldura padrão para demonstrações com título, descrição e área de demo.

```csharp
<DemoCard Titulo="Meu Exemplo" Descricao="Descrição">
    <!-- Conteúdo -->
    <PontoChave>
        <ul>
            <li>Ponto 1</li>
            <li>Ponto 2</li>
        </ul>
    </PontoChave>
</DemoCard>
```

### LogPanel
Registra eventos com timestamp em tempo real (ótimo para aprender ciclo de vida).

```csharp
<LogPanel @ref="LogPanel" />

@code {
    private LogPanel? LogPanel;
    
    protected override void OnInitialized()
    {
        LogPanel?.RegistrarEvento("Init", "Componente inicializado");
    }
}
```

### CodeSnippet
Exibe trechos de código com opção de mostrar/ocultar.

## Banco de Dados

SQLite local em `Data/blazorlab.db`. Para resetar:

```bash
dotnet ef database drop --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
```

## Logging

Configurado com Serilog. Logs aparecem no console durante desenvolvimento.

## Próximos Passos

1. ✅ Fundamentos (Ciclo de Vida, Data Binding)
2. ⬜ Comunicação entre Componentes (EventCallback, CascadingValue)
3. ⬜ Routing e Navegação
4. ⬜ Formulários e Validação
5. ⬜ Autenticação e Autorização
6. ⬜ JS Interop
7. ⬜ Testes (bUnit)
8. ⬜ Deployment

## Perguntas de Entrevista Frequentes

### Sobre Ciclo de Vida
- **P:** Qual a diferença entre `OnInitialized` e `OnInitializedAsync`?
- **R:** Ambos são chamados na primeira renderização, mas `OnInitializedAsync` permite operações assíncronas (carregar dados).

- **P:** Quando `OnParametersSet` é chamado?
- **R:** Toda vez que os parâmetros do componente mudam.

### Sobre Data Binding
- **P:** Qual a diferença entre one-way e two-way binding?
- **R:** One-way (`@valor`) apenas exibe; two-way (`@bind`) atualiza em tempo real.

### Sobre Arquitetura
- **P:** Por que usar Repository Pattern?
- **R:** Desacopla a lógica da aplicação do acesso a dados, facilitando testes e manutenção.

- **P:** O que é Injeção de Dependências?
- **R:** Passar dependências pelo construtor em vez de criá-las dentro da classe, melhorando testabilidade.

## Recursos Úteis

- [Microsoft Learn - Blazor](https://learn.microsoft.com/en-us/training/paths/build-web-apps-with-blazor/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [bUnit Documentation](https://bunit.dev/)
- [Serilog](https://serilog.net/)

## Licença

MIT

---

**Criado para educação.** Use como base para seus projetos!
