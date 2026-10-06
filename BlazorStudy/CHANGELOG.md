# Changelog - BlazorLab

## v1.0.0 - Lançamento Inicial (06/10/2026)

### ✨ Novas Funcionalidades

#### Estrutura do Projeto
- ✅ Solução em 3 camadas (Web, Application, Infrastructure)
- ✅ Setup completo com .NET 10
- ✅ Configuração de DI e middleware
- ✅ Logging com Serilog
- ✅ SQLite com Entity Framework Core

#### Componentes Reutilizáveis
- ✅ `DemoCard` - Moldura padrão para demonstrações
- ✅ `LogPanel` - Painel de log de eventos em tempo real
- ✅ `CodeSnippet` - Exibição de código com toggle

#### Páginas Educacionais
- ✅ `Home` - Página inicial com navegação
- ✅ `CicloDeVida` - Demonstração interativa do ciclo de vida
- ✅ `DataBinding` - Exemplos de binding e eventos
- ✅ `Tarefas` - Sistema CRUD completo

#### Lógica de Negócio
- ✅ Modelo `Tarefa` com validações
- ✅ DTOs para transferência de dados
- ✅ Interface `ITarefaService` e implementação
- ✅ Repository Pattern genérico
- ✅ DbContext com configurações EF Core

#### Documentação
- ✅ README.md completo
- ✅ Roteiro de aprendizado (docs/roteiro.md)
- ✅ Guia de perguntas de entrevista
- ✅ Script de setup automático

### 📦 Dependências Incluídas
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Serilog & Serilog.AspNetCore
- bUnit (testes de componentes)
- NSubstitute (mocks)

### 🎯 Módulos Implementados
1. **Fundamentos** ✅
   - Sintaxe Razor
   - Data Binding (one-way, two-way)
   - Eventos e formulários
   - Renderização condicional
   - Listas com @key

2. **Ciclo de Vida** ✅
   - SetParametersAsync
   - OnInitialized/OnInitializedAsync
   - OnParametersSet/OnParametersSetAsync
   - ShouldRender
   - OnAfterRender/OnAfterRenderAsync
   - DisposeAsync
   - StateHasChanged

3. **Arquitetura** ✅
   - Repository Pattern
   - Injeção de Dependências
   - Service Layer
   - Application/Infrastructure/Presentation layers
   - Entity Framework Core

4. **Sistema de Tarefas** ✅
   - CRUD completo
   - Persistência em SQLite
   - Estados de loading
   - Tratamento de erros
   - Estatísticas em tempo real

### 📝 Documentação
- README.md com instruções de setup
- Roteiro de aprendizado com exercícios
- Perguntas de entrevista com gabaritos
- Comentários inline no código
- Exemplos de código nos componentes

### 🚀 Como Começar
1. Execute `setup.bat` para configuração inicial
2. Abra `README.md` para instruções
3. Acesse `https://localhost:7001`
4. Leia `docs/roteiro.md` para aprender

## Roadmap Futuro

### v1.1.0 - Comunicação (planejado)
- [ ] Componentes com EventCallback
- [ ] CascadingValue/CascadingParameter
- [ ] Serviço de estado com padrão Observer
- [ ] Referências de componentes (@ref)

### v1.2.0 - Routing (planejado)
- [ ] Routing avançado
- [ ] Parâmetros de rota
- [ ] Query strings
- [ ] NavigationManager
- [ ] Layouts aninhados

### v1.3.0 - Formulários (planejado)
- [ ] EditForm e DataAnnotations
- [ ] Validação customizada
- [ ] FluentValidation
- [ ] Feedback visual de validação

### v2.0.0 - Autenticação (planejado)
- [ ] ASP.NET Core Identity
- [ ] Login/Logout
- [ ] Roles e Policies
- [ ] Proteção de páginas com [Authorize]

### v2.1.0 - Avançado (planejado)
- [ ] JS Interop
- [ ] Virtualize
- [ ] ErrorBoundary
- [ ] QuickGrid
- [ ] PersistentComponentState

### v3.0.0 - Testes (planejado)
- [ ] Testes completos com bUnit
- [ ] Exemplos de testes de componentes
- [ ] Testes de serviços com xUnit
- [ ] Cobertura de testes mínima de 80%

---

Desenvolvido para educação em Blazor com padrões de mercado. 🚀
