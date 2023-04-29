FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ["Commands/SP.Commands.Api/SP.Commands.Api.csproj", "Commands/SP.Commands.Api/"]
COPY ["Commands/SP.Commands.Application/SP.Commands.Application.csproj", "Commands/SP.Commands.Application/"]
COPY ["Commands/SP.Commands.Domain/SP.Commands.Domain.csproj", "Commands/SP.Commands.Domain/"]
COPY ["Commands/SP.Commands.Infra/SP.Commands.Infra.csproj", "Commands/SP.Commands.Infra/"]
COPY ["Core/SP.Core/SP.Core.csproj", "Core/SP.Core/"]
COPY ["Common/SP.Common/SP.Common.csproj", "Common/SP.Common/"]
RUN dotnet restore Commands/SP.Commands.Api/SP.Commands.Api.csproj
COPY . .
WORKDIR /app/Commands/SP.Commands.Api
RUN dotnet build -c Realease -o /app/build

FROM build As publish
RUN dotnet publish -c release -o /app/publish --no-restore

FROM base As final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "SP.Commands.Api.dll" ]