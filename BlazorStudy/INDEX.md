# 📑 Índice de Documentação - BlazorLab

## 🚀 Comece Aqui

1. **PRIMEIRO:** Leia [QUICKSTART.md](QUICKSTART.md) ⚡
   - 5 minutos para começar
   - Comandos essenciais
   - Solução de problemas rápida

2. **DEPOIS:** Leia [README.md](README.md) 📖
   - Visão geral do projeto
   - Estrutura da solução
   - Como rodar
   - Conceitos abordados

3. **APRENDIZADO:** Siga [docs/roteiro.md](docs/roteiro.md) 🎓
   - Guia passo-a-passo
   - Exercícios práticos
   - Perguntas de entrevista
   - Timeline recomendada

## 📚 Documentação Disponível

### Para Começar Rápido
| Arquivo | Tempo | Descrição |
|---------|-------|-----------|
| [QUICKSTART.md](QUICKSTART.md) | 5 min ⚡ | Setup e primeiros passos |
| [README.md](README.md) | 15 min | Visão geral e instruções |
| [CHANGELOG.md](CHANGELOG.md) | 10 min | O que foi implementado |

### Para Aprender
| Arquivo | Tempo | Descrição |
|---------|-------|-----------|
| [docs/roteiro.md](docs/roteiro.md) | 6-8h 📖 | Guia completo de aprendizado |
| [DEVELOPMENT.md](DEVELOPMENT.md) | 20 min | Dicas e padrões de código |
| [PROJECT_STATUS.md](PROJECT_STATUS.md) | 10 min | Status e estatísticas |

## 🎯 Roteiros por Objetivo

### "Quero aprender Blazor"
```
1. QUICKSTART.md (5 min)    ← Setup
2. README.md (15 min)       ← Entenda o projeto
3. docs/roteiro.md (6-8h)   ← Aprenda com exercícios
4. DEVELOPMENT.md (20 min)  ← Aprenda padrões
```

### "Quero clonar e rodar"
```
1. QUICKSTART.md            ← Siga seção "5 Minutos"
2. Pronto! 🎉
```

### "Quero entender a arquitetura"
```
1. README.md - seção "Arquitetura em Camadas"
2. DEVELOPMENT.md - seção "Fluxo de Dados"
3. Explore src/BlazorLab.Application/
4. Explore src/BlazorLab.Infrastructure/
5. Explore src/BlazorLab.Web/
```

### "Quero resolver um problema"
```
1. QUICKSTART.md - seção "Solução de Problemas"
2. DEVELOPMENT.md - seção "Troubleshooting"
3. Verifique console de erros
4. Limpe cache: dotnet clean
```

### "Quero preparar para entrevista"
```
1. docs/roteiro.md - seção "Perguntas de Entrevista"
2. DEVELOPMENT.md - seção "Padrões Usados"
3. Estude os 3 exemplos: CicloDeVida, DataBinding, Tarefas
4. Pratique modificando o código
```

## 📂 Estrutura de Arquivos

```
BlazorLab/
├── 📄 QUICKSTART.md              ← ⭐ Comece aqui! (5 min)
├── 📄 README.md                  ← Documentação principal
├── 📄 CHANGELOG.md               ← Histórico de versões
├── 📄 DEVELOPMENT.md             ← Dicas de desenvolvimento
├── 📄 PROJECT_STATUS.md          ← Status e estatísticas
├── 📄 .gitignore                 ← Git exclusions
├── 🔧 setup.bat                  ← Script de configuração
├── 🔧 BlazorLab.slnx             ← Solução
│
├── 📁 src/
│   ├── BlazorLab.Web/            ← Aplicação Blazor
│   │   ├── Components/
│   │   │   ├── Pages/            ← Páginas (Home, CicloDeVida, etc)
│   │   │   ├── Shared/           ← Componentes reutilizáveis
│   │   │   └── Conceitos/        ← Componentes de demonstração
│   │   ├── Program.cs            ← Configuração DI
│   │   └── appsettings.json      ← Configurações
│   ├── BlazorLab.Application/    ← Lógica de negócio
│   │   ├── Models/               ← Entidades (Tarefa)
│   │   ├── Dtos/                 ← Data Transfer Objects
│   │   └── Interfaces/           ← Contratos
│   └── BlazorLab.Infrastructure/ ← Acesso a dados
│       ├── Data/                 ← EF Core DbContext
│       ├── Repositories/         ← Repository Pattern
│       └── Services/             ← Serviços (TarefaService)
│
├── 📁 tests/
│   └── BlazorLab.Tests/          ← Testes (xUnit + bUnit)
│
└── 📁 docs/
    └── roteiro.md                ← Guia de aprendizado
```

## 🗂️ Documentação por Tópico

### Blazor Básico
- **Ciclo de Vida:** README.md, docs/roteiro.md
- **Data Binding:** README.md, docs/roteiro.md
- **Componentes:** docs/roteiro.md
- **Rotas:** README.md (roadmap)

### Arquitetura
- **Repository Pattern:** DEVELOPMENT.md, README.md
- **Injeção de Dependências:** DEVELOPMENT.md, README.md
- **Camadas:** DEVELOPMENT.md, PROJECT_STATUS.md
- **DTOs vs Models:** DEVELOPMENT.md

### Desenvolvimento
- **Padrões de código:** DEVELOPMENT.md
- **Debugging:** DEVELOPMENT.md
- **Performance:** DEVELOPMENT.md
- **Testes:** DEVELOPMENT.md, README.md

### Setup & Deployment
- **Instalação:** QUICKSTART.md, README.md
- **Troubleshooting:** QUICKSTART.md, DEVELOPMENT.md
- **Produção:** DEVELOPMENT.md
- **Banco de dados:** DEVELOPMENT.md

## 🔗 Links Rápidos

### Documentação
- [QUICKSTART.md](QUICKSTART.md) - Comece em 5 minutos ⚡
- [README.md](README.md) - Documentação completa 📖
- [docs/roteiro.md](docs/roteiro.md) - Guia de aprendizado 🎓
- [DEVELOPMENT.md](DEVELOPMENT.md) - Dicas técnicas 🔧

### Código-Fonte
- [src/BlazorLab.Web/Program.cs](src/BlazorLab.Web/Program.cs) - Setup da app
- [src/BlazorLab.Web/Components/Pages/Tarefas.razor](src/BlazorLab.Web/Components/Pages/Tarefas.razor) - Exemplo CRUD
- [src/BlazorLab.Infrastructure/Services/TarefaService.cs](src/BlazorLab.Infrastructure/Services/TarefaService.cs) - Service layer
- [src/BlazorLab.Infrastructure/Repositories/Repository.cs](src/BlazorLab.Infrastructure/Repositories/Repository.cs) - Repository pattern

### Recursos Externos
- [Microsoft Learn - Blazor](https://learn.microsoft.com/en-us/training/paths/build-web-apps-with-blazor/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [bUnit Documentation](https://bunit.dev/)
- [Repository Pattern](https://martinfowler.com/eaaCatalog/repository.html)

## 📊 Resumo Rápido

| Aspecto | Detalhe |
|---------|---------|
| **Versão .NET** | 10.0 |
| **Tipo de Aplicação** | Blazor Server |
| **Banco de Dados** | SQLite |
| **Arquitetura** | 3 camadas (Web, Application, Infrastructure) |
| **Padrões** | Repository, Service Layer, Dependency Injection |
| **Testes** | xUnit + bUnit + NSubstitute |
| **Logging** | Serilog |
| **Documentação** | 7 arquivos (33 KB+) |
| **Exemplos Práticos** | 4 páginas principais |
| **Status** | ✅ Completo e Funcional |

## ✅ Checklist de Leitura

### Essencial
- [ ] QUICKSTART.md (5 min)
- [ ] README.md (15 min)
- [ ] docs/roteiro.md (primeiras 2 seções, 30 min)

### Importante
- [ ] DEVELOPMENT.md - seção "Fluxo de Dados" (15 min)
- [ ] docs/roteiro.md - seção "Exercícios" (30 min)

### Recomendado
- [ ] DEVELOPMENT.md completo (30 min)
- [ ] docs/roteiro.md completo (total 6-8h com prática)
- [ ] PROJECT_STATUS.md (10 min)
- [ ] CHANGELOG.md (10 min)

## 🎓 Trilha de Aprendizado Recomendada

### Dia 1 - Fundamentos (3-4 horas)
```
Morning:
1. QUICKSTART.md + Setup (30 min)
2. README.md (30 min)
3. Home Page + Navegação (30 min)

Afternoon:
4. CicloDeVida page + log (1 hora)
5. DataBinding page + exercícios (1 hora)
```

### Dia 2 - Arquitetura (3-4 horas)
```
Morning:
1. DEVELOPMENT.md - Arquitetura (30 min)
2. Explorar código-fonte (1 hora)
3. Tarefas CRUD + testes (1 hora)

Afternoon:
4. docs/roteiro.md - Exercícios (1-2 horas)
```

### Dia 3 - Consolidação (2-3 horas, opcional)
```
1. Entrevista prep - perguntas (1 hora)
2. Criar seu próprio componente (1-2 horas)
3. Deploy preparação (30 min)
```

---

## 🎉 Pronto para Começar?

### 1️⃣ Leia [QUICKSTART.md](QUICKSTART.md) (5 minutos)
### 2️⃣ Execute `setup.bat`
### 3️⃣ Abra `https://localhost:7001`
### 4️⃣ Siga [docs/roteiro.md](docs/roteiro.md)

**Divirta-se aprendendo Blazor!** 🚀

---

**Última atualização:** 06/10/2026
**Versão:** 1.0.0
**Status:** ✅ Completo
