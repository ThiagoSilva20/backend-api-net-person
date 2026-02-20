# Backend (.NET)

API REST em .NET 10 com Entity Framework Core e SQLite.

## Requisitos

- **.NET SDK** (versão do projeto: `net10.0`)
- (Opcional) **SQLite** ou ferramenta para visualizar o banco (`person.sqlite`)
- (Opcional) **dotnet-ef** para criar e aplicar migrations

## Configuração

```bash
# Verificar se o SDK está instalado
dotnet --version

# Instalar ferramenta EF Core (necessária para migrations)
dotnet tool install --global dotnet-ef

# Restaurar dependências do projeto
dotnet restore
```

## Rodar a aplicação 

```bash
dotnet watch run
```
## Migrations (Entity Framework)

```bash
# Caso precise criar uma nova migration
dotnet ef migrations add NomeDaMigration

# Aplicar migrations ja existentes ao banco
dotnet ef database update
```

Em **modo desenvolvimento**:
- API: `https://localhost:5xxx` ou `http://localhost:5xxx` (porta no terminal)
- Documentação OpenAPI: `/openapi/v1.json`

