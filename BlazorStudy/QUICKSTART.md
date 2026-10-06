# ⚡ Quick Start - BlazorLab

## 5 Minutos para Começar

### 1️⃣ Clonar / Abrir Projeto
```bash
cd C:\ReposPerson\Blazor
```

### 2️⃣ Setup (execute uma vez)
**Windows:**
```bash
setup.bat
```

**Ou manualmente:**
```bash
dotnet restore
dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
```

### 3️⃣ Executar
```bash
cd src/BlazorLab.Web
dotnet run
```

### 4️⃣ Abrir no Browser
```
https://localhost:7001
```

### 5️⃣ Explorar
Pronto! Você está dentro do BlazorLab! 🎉

---

## O Que Fazer Primeiro?

### Para Aprender Blazor
1. Clique em **Ciclo de Vida** → observe o log interativo
2. Clique em **Data Binding** → teste os exemplos
3. Clique em **Tarefas** → crie sua primeira tarefa

### Para Entender a Arquitetura
1. Abra `Program.cs` → veja a configuração de DI
2. Abra `src/BlazorLab.Application/Models/Tarefa.cs` → veja o modelo
3. Abra `src/BlazorLab.Infrastructure/Services/TarefaService.cs` → veja a lógica
4. Abra `src/BlazorLab.Web/Components/Pages/Tarefas.razor` → veja o componente

### Para Modificar
1. Edite um arquivo `.razor` (componentes)
2. Edite um arquivo `.cs` (lógica)
3. Salve
4. Browser atualiza automaticamente ✨

---

## Comandos Úteis

```bash
# Build
dotnet build

# Teste
dotnet test tests/BlazorLab.Tests

# Clean
dotnet clean

# Resetar banco de dados
dotnet ef database drop --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web
```

---

## Estrutura Rápida

```
BlazorLab/
├── src/BlazorLab.Web/              ← Componentes, páginas, UI
├── src/BlazorLab.Application/       ← Models, DTOs, interfaces
├── src/BlazorLab.Infrastructure/    ← Banco, repositórios, serviços
├── tests/BlazorLab.Tests/           ← Testes
├── README.md                        ← Documentação completa
└── docs/roteiro.md                  ← Guia de aprendizado
```

---

## Páginas Principais

| URL | Descrição |
|-----|-----------|
| `/` | Home - navegação principal |
| `/conceitos/ciclo-de-vida` | Ciclo de vida com log interativo |
| `/conceitos/data-binding` | Exemplos de binding e eventos |
| `/tarefas` | CRUD com Repository Pattern |

---

## Dados de Acesso

- **Banco:** SQLite em `src/BlazorLab.Web/Data/blazorlab.db`
- **Host:** localhost:7001
- **SSL:** Habilitado (HTTPS)
- **Logs:** Console durante execução

---

## Solução de Problemas

### Erro: "Cannot find command: dotnet"
→ Instale .NET 10 SDK: https://dotnet.microsoft.com

### Erro: "Cannot find sqlite database"
→ Execute: `dotnet ef database update --project src/BlazorLab.Infrastructure --startup-project src/BlazorLab.Web`

### Erro: "Cannot connect to localhost:7001"
→ Aplicação pode estar usando outra porta
→ Verifique console para URL correta

### Erro: "Component is not a known element"
→ Adicione `@using BlazorLab.Web.Components.Shared` no arquivo .razor

---

## Próximas Etapas

1. ✅ Rodou com sucesso?
2. 📖 Leia `docs/roteiro.md` para guia completo
3. 🔍 Explore o código-fonte
4. ✏️ Modifique os exemplos
5. 🧪 Crie seus próprios componentes
6. 🚀 Deploy em produção

---

## Precisa de Ajuda?

- 📖 Leia **README.md** para documentação completa
- 📚 Acesse **docs/roteiro.md** para aprender passo a passo
- 🔧 Verifique **DEVELOPMENT.md** para dicas técnicas
- 💻 Consulte **PROJECT_STATUS.md** para status do projeto

---

**Bem-vindo ao BlazorLab! Divirta-se aprendendo! 🚀**
