# MyStack - Gerenciador de Hardware Full Stack

O **MyStack** é uma aplicação completa para gerenciamento de componentes de hardware, desenvolvida para colocar em prática conceitos avançados de arquitetura de software, conteinerização e integração entre diferentes tecnologias.

## 🛠️ Tecnologias Utilizadas

* **Backend:** C# com .NET 10 (Web API)
* **Frontend:** React com TypeScript e Tailwind CSS
* **Banco de Dados:** PostgreSQL
* **Infraestrutura:** Docker e Docker Compose (Orquestração completa)
* **Arquitetura:** Repository Pattern, Dependency Injection e Soft Delete

## ✨ Funcionalidades

* **CRUD de Hardware:** Cadastro, listagem e exclusão (Soft Delete).
* **Soft Delete:** Os dados não são removidos permanentemente do banco, apenas marcados como inativos (`IsActive = false`).
* **Interface Responsiva:** Desenvolvida com Tailwind CSS para um visual moderno e "Dark Mode".
* **Ambiente Isolado:** Todo o ecossistema sobe com um único comando via Docker.

## 🚀 Como Executar o Projeto

Certifique-se de ter o **Docker** instalado em sua máquina.

1. Clone o repositório:
   ```bash
   git clone [https://github.com/FelixDev01/MyStack.git](https://github.com/FelixDev01/MyStack.git)
Na raiz do projeto, execute o comando:

Bash
docker-compose up -d --build
Acesse no seu navegador:

Frontend: http://localhost:5173

API (Swagger): http://localhost:8080/swagger

Desenvolvido por Felix


---