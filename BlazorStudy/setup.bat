@echo off
REM Script para setup inicial do BlazorLab

echo.
echo ╔════════════════════════════════════════════════════════════════════════════╗
echo ║                         SETUP INICIAL - BlazorLab                          ║
echo ║                    Iniciando configuração do projeto...                    ║
echo ╚════════════════════════════════════════════════════════════════════════════╝
echo.

REM 1. Restaurar dependências
echo [1/3] Restaurando dependências NuGet...
dotnet restore
if errorlevel 1 (
    echo ERRO ao restaurar dependências!
    exit /b 1
)
echo ✓ Dependências restauradas
echo.

REM 2. Criar diretório de dados
echo [2/3] Criando diretório de dados...
if not exist "src\BlazorLab.Web\Data" (
    mkdir "src\BlazorLab.Web\Data"
    echo ✓ Diretório criado
) else (
    echo ✓ Diretório já existe
)
echo.

REM 3. Aplicar migrações
echo [3/3] Criando banco de dados (SQLite)...
cd src\BlazorLab.Web
dotnet ef database update --project ..\BlazorLab.Infrastructure
if errorlevel 1 (
    echo ERRO ao criar banco de dados!
    cd ..\..
    exit /b 1
)
echo ✓ Banco de dados criado
cd ..\..
echo.

echo ╔════════════════════════════════════════════════════════════════════════════╗
echo ║                      ✓ SETUP CONCLUÍDO COM SUCESSO!                       ║
echo ║                                                                            ║
echo ║  Para executar a aplicação, digite:                                        ║
echo ║                                                                            ║
echo ║    cd src\BlazorLab.Web                                                     ║
echo ║    dotnet run                                                              ║
echo ║                                                                            ║
echo ║  A aplicação estará disponível em: https://localhost:7001                  ║
echo ║                                                                            ║
echo ║  Leia o README.md para mais informações!                                    ║
echo ╚════════════════════════════════════════════════════════════════════════════╝
echo.
pause
