# Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
COPY ["MyStack.Api/MyStack.Api.csproj", "MyStack.Api/"]
RUN dotnet restore "MyStack.Api/MyStack.Api.csproj"

# Copia o restante do código e compila
COPY . .
WORKDIR "/src/MyStack.Api"
RUN dotnet build "MyStack.Api.csproj" -c Release -o /app/build

# Publicação
FROM build AS publish
RUN dotnet publish "MyStack.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define a porta que a API vai rodar dentro do container
EXPOSE 8080
ENTRYPOINT ["dotnet", "MyStack.Api.dll"]