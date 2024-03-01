# Entity-framework

## Перед запуском
Создайте файл `.env` по примеру из `.env.template`

## Разворачиваение докер композ
```
docker compose up -d --force-recreate
```

## Проведение миграций
```
dotnet-ef migrations add InitialMigration
dotnet ef database update
```

или из Rider `tools` -> `Entity framework core` -> `Add migration`; `tools` -> `Entity framework core` -> `Update database`

## Если не найден dotnet-ef
```
dotnet tool install --global dotnet-ef --version 8.0.0
```
