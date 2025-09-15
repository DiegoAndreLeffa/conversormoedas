# Conversor de Moedas em C #

Um simples, porém robusto, conversor de moedas construído em C# e .NET, seguindo as melhores práticas de desenvolvimento como SOLID, testes unitários e controle de versão com Git.

## ✨ Funcionalidades

- Conversão entre diversas moedas (BRL, USD, EUR, etc.).
- Cotações em tempo real consumidas da [ExchangeRate-API](https://www.exchangerate-api.com/).
- Arquitetura limpa e desacoplada.
- Testes unitários para garantir a lógica de negócio.

## 🚀 Tecnologias Utilizadas

- **C# e .NET 8**
- **xUnit** para testes unitários
- **Git e GitHub** para controle de versão
- **Injeção de Dependência** (`Microsoft.Extensions.DependencyInjection`)

## ⚙️ Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

### Passo a Passo

1. **Clone o repositório:**

    ```bash
    git clone https://github.com/DiegoAndreLeffa/conversormoedas.git
    cd conversormoedas
    ```

2. **Obtenha uma API Key:**
    - Crie uma conta gratuita no site [ExchangeRate-API](https://www.exchangerate-api.com/).
    - Copie sua API Key.

3. **Configure a API Key (Secrets Manager):**
    Navegue até a pasta do projeto de API e configure o segredo:

    ```bash
    cd src/ConversorMoedas.Api
    dotnet user-secrets init
    dotnet user-secrets set "ExchangeRateApiKey" "SUA_API_KEY_AQUI"
    ```

4. **Execute a aplicação:**
    Volte para a raiz do projeto e execute:

    ```bash
    dotnet run --project src/ConversorMoedas.Api/ConversorMoedas.Api.csproj
    ```

## 🧪 Rodando os Testes

Para executar os testes unitários, rode o seguinte comando na raiz do projeto:

```bash
dotnet test
