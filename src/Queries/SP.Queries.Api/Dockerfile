FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ["Queries/SP.Queries.Api/SP.Queries.Api.csproj", "Queries/SP.Queries.Api/"]
#COPY ["Queries/SP.Queries.Application/SP.Queries.Application.csproj", "Queries/SP.Queries.Application/"]
COPY ["Queries/SP.Queries.Domain/SP.Queries.Domain.csproj", "Queries/SP.Queries.Domain/"]
COPY ["Queries/SP.Queries.Infra/SP.Queries.Infra.csproj", "Queries/SP.Queries.Infra/"]
COPY ["Core/SP.Core/SP.Core.csproj", "Core/SP.Core/"]
COPY ["Common/SP.Common/SP.Common.csproj", "Common/SP.Common/"]
RUN dotnet restore Queries/SP.Queries.Api/SP.Queries.Api.csproj
COPY . .
WORKDIR /app/Queries/SP.Queries.Api
RUN dotnet build -c Realease -o /app/build

FROM build As publish
RUN dotnet publish -c release -o /app/publish --no-restore

FROM base As final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "SP.Queries.Api.dll" ]