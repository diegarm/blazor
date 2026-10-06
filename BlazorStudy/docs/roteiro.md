# 📖 Roteiro de Aprendizado - BlazorLab

## Fase 1: Fundamentos Blazor (2-3 horas)

### 1.1 Começar pela Home
- Acesse `https://localhost:7001`
- Entenda a estrutura e navegação do projeto
- Veja os 4 módulos principais

### 1.2 Ciclo de Vida dos Componentes (30 min)
**URL:** `/conceitos/ciclo-de-vida`

#### Conceitos:
1. Cada componente Blazor passa por várias etapas
2. Métodos são chamados em uma sequência específica
3. Você pode "ouvir" a cada etapa

#### Exercício 1: Observe o Log
- Clique em "Alterar Parâmetro"
- Veja quais métodos são chamados no LogPanel
- Note a ordem: `OnInitialized` → `OnParametersSet` → `OnAfterRender`

#### Exercício 2: Teste StateHasChanged
- Clique "Alterar sem Re-render" - a UI não muda
- Clique "Alterar com Re-render" - a UI muda
- Entenda que Blazor nem sempre detecta mudanças automaticamente

#### Perguntas para Refletir:
- Por que `OnInitialized` é chamado apenas uma vez?
- O que é `StateHasChanged()` e quando usar?
- Qual a diferença entre `OnInitialized` e `OnAfterRender`?

### 1.3 Data Binding e Eventos (45 min)
**URL:** `/conceitos/data-binding`

#### Conceitos:
1. **One-Way Binding:** Exibe dados mas não atualiza automaticamente
2. **Two-Way Binding:** Conecta input ao state
3. **Events:** Respond to user actions
4. **Listas:** Use `@key` para otimizar

#### Exercício 1: Teste Binding
- Digiteano campo "One-Way" - note que o valor acima não muda
- Digite no campo "Two-Way" - note que muda automaticamente
- Entenda a diferença

#### Exercício 2: Explore Eventos
- Clique o botão "Clique Aqui" várias vezes
- O contador deve aumentar
- Teste o formulário com seu nome

#### Exercício 3: Trabalhe com Listas
- Digite itens e adicione à lista
- Use o botão "Remover"
- Entenda como `@key` ajuda Blazor a rastrear items

#### Perguntas para Refletir:
- Qual binding você usa em um input de email? (`@bind` ou sem?)
- Como diferenciar entre `oninput` e `onchange`?

## Fase 2: Padrões de Arquitetura (1-2 horas)

### 2.1 Sistema de Tarefas - CRUD Prático
**URL:** `/tarefas`

#### Conceitos:
1. **Repository Pattern:** Abstrai acesso a dados
2. **Service Layer:** Lógica de negócio
3. **Dependency Injection:** Injetar dependências
4. **Entity Framework Core:** ORM para dados
5. **DTOs:** Transferir dados entre camadas

#### Exercício 1: Crie Sua Primeira Tarefa
- Preencha Título, Descrição, Data e Prioridade
- Clique "Criar Tarefa"
- Veja a tarefa aparecer na lista
- Note o contador de estatísticas atualizar

#### Exercício 2: Manipule Tarefas
- Marque uma tarefa como concluída (checkbox)
- A tarefa deve aparecer com strikethrough
- Clique "Deletar" em uma tarefa
- A lista deve ser atualizada

#### Exercício 3: Observe a Arquitetura
- Clique "Ver Código" no card "Estrutura de Serviços"
- Leia como os serviços estão estruturados
- Note o caminho dos dados:
  ```
  Componente (Tarefas.razor)
    ↓ (injeta)
  ITarefaService (interface)
    ↓ (implementação)
  TarefaService (lógica)
    ↓ (usa)
  IRepository<Tarefa> (abstração)
    ↓ (implementação)
  Repository<T> (EF Core)
    ↓ (usa)
  ApplicationDbContext (banco)
    ↓
  SQLite (arquivo blazorlab.db)
  ```

### 2.2 Explore a Estrutura do Código

#### Abra os Arquivos:
1. `src/BlazorLab.Application/Models/Tarefa.cs` - Entidade de domínio
2. `src/BlazorLab.Application/Dtos/TarefaDto.cs` - Dados transferidos
3. `src/BlazorLab.Application/Interfaces/ITarefaService.cs` - Contrato
4. `src/BlazorLab.Infrastructure/Services/TarefaService.cs` - Implementação
5. `src/BlazorLab.Infrastructure/Repositories/Repository.cs` - Repository genérico
6. `src/BlazorLab.Web/Program.cs` - Configuração de DI
7. `src/BlazorLab.Web/Components/Pages/Tarefas.razor` - Componente

#### Leia e Entenda:
- Como os dados fluem de um lado para o outro
- Por que usamos interfaces (ITarefaService)
- Como o Repository funciona genericamente

## Fase 3: Conceitos Avançados (opcional)

### 3.1 Injeção de Dependências
- Abra `Program.cs`
- Leia as linhas com `builder.Services.Add*`
- Entenda Singleton, Scoped, Transient

### 3.2 Entity Framework Core
- Abra `src/BlazorLab.Infrastructure/Data/ApplicationDbContext.cs`
- Veja como as tabelas são configuradas
- Teste criar e deletar tarefas, observando o banco

### 3.3 Logging com Serilog
- Rode a aplicação em modo DEBUG
- Abra o console
- Veja os logs sendo registrados
- Customize em `Program.cs`

## Perguntas de Entrevista - Gabarito

### Blazor e Ciclo de Vida
**P: Qual a diferença entre OnInitialized e OnInitializedAsync?**
R: OnInitialized é síncrono, OnInitializedAsync é assíncrono (para carregar dados de APIs).

**P: Quando OnParametersSet é acionado?**
R: Toda vez que os parâmetros [Parameter] do componente mudam.

**P: O que faz StateHasChanged()?**
R: Avisa ao Blazor que o estado mudou e o componente precisa ser re-renderizado.

### Data Binding
**P: Qual binding usar em um input?**
R: @bind="" para two-way (valor muda na hora) ou value="@propriedade" para one-way.

**P: Qual a diferença entre @bind:event="oninput" e "onchange"?**
R: oninput atualiza a cada tecla, onchange apenas quando sai do campo.

### Arquitetura
**P: Por que usar Repository Pattern?**
R: Para desacoplar a lógica da aplicação do banco de dados. Facilita testes e mudanças.

**P: O que é Injeção de Dependências?**
R: Passar dependências pelo construtor em vez de criar dentro. Melhora testabilidade.

**P: Qual a diferença entre DTO e Model?**
R: Model representa dados no banco/banco, DTO é para transferir entre camadas.

**P: Por que usar camadas (Application, Infrastructure, Web)?**
R: Separação de responsabilidades. Código mais limpo, testável e manutenível.

### EF Core
**P: O que é OnModelCreating?**
R: Método para configurar mapeamentos entre classes C# e tabelas do banco.

**P: Como criar uma migração?**
R: `dotnet ef migrations add MeuNome --project src/BlazorLab.Infrastructure`

## Exercícios Propostos

### Nível 1: Básico
1. Altere a cor do badge de prioridade "Alta" para vermelho mais escuro
2. Adicione um campo "Categoria" ao modelo Tarefa
3. Ordene tarefas por prioridade na lista

### Nível 2: Intermediário
1. Implemente um filtro por status (Concluídas, Pendentes, Todas)
2. Crie um componente reutilizável para listar tarefas
3. Adicione persistência da preferência de filtro no localStorage

### Nível 3: Avançado
1. Implemente paginação na lista de tarefas
2. Crie testes com bUnit para o componente Tarefas
3. Adicione autenticação simples (usuários terão suas próprias tarefas)

## Timeline Recomendada

**Dia 1 (3-4 horas):**
- Fase 1 (Fundamentos) completa
- Fase 2.1 (Sistema de Tarefas)

**Dia 2 (2-3 horas):**
- Fase 2.2 (Explore o Código)
- Exercícios Nível 1-2

**Dia 3+ (Optativo):**
- Fase 3 (Conceitos Avançados)
- Exercícios Nível 3

## Como Debugar

1. **Abra o Developer Tools** (F12)
2. **Console:** Veja logs e erros
3. **Application:** Inspect localStorage/sessionStorage
4. **Network:** Veja requisições HTTP
5. **No VS Code:** Pressione F5 para debug com breakpoints

## Recursos Adicionais

- Documentação oficial Blazor: https://learn.microsoft.com/en-us/aspnet/core/blazor
- Repository Pattern: https://martinfowler.com/eaaCatalog/repository.html
- SOLID Principles: https://en.wikipedia.org/wiki/SOLID
- Entity Framework Core: https://learn.microsoft.com/en-us/ef/core/

---

**Você fez! Parabéns por aprender Blazor com BlazorLab! 🎉**

Próximos passos sugeridos:
1. Crie um projeto próprio baseado nesta arquitetura
2. Estude WebAssembly e Blazor WASM
3. Explore autenticação com Identity
4. Aprenda sobre SignalR para tempo real
