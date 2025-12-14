# PokePricer 2.0

![Status](https://img.shields.io/badge/STATUS-EM_DESENVOLVIMENTO-green?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=for-the-badge)
![Selenium](https://img.shields.io/badge/Selenium-WebDriver-43B02A?style=for-the-badge&logo=selenium&logoColor=white)

Ferramenta de automação desktop desenvolvida para colecionadores de Pokémon TCG. O sistema conecta o gerenciamento de coleção digital (TCG Collector) com o mercado brasileiro real, permitindo a precificação automática de itens baseada na **LigaPokemon**.

O objetivo é eliminar a necessidade de verificar preços manualmente, carta por carta, convertendo uma coleção dolarizada para o valor real de mercado em Reais (R$).

## Funcionalidades

- **Autenticação Automatizada:** Realiza login seguro no painel do usuário no *TCG Collector*.
- **Web Scraping Inteligente:** - Extrai dados da coleção (Nome, ID, Set, Variantes).
  - Navega na *LigaPokemon* para buscar o valor de mercado atual.
- **Precificação Lógica:**
  - Filtra cartas ignorando variantes japonesas quando necessário.
  - Identifica automaticamente o **menor preço** disponível por condição da carta.
- **Relatórios:**
  - Exporta a coleção bruta para `cartas.json`.
  - Gera relatório final de valores em `precos_pokemon.json`.

## Tecnologias Utilizadas

* **C# (.NET Framework 4.8)**: Estrutura principal da aplicação.
* **Windows Forms**: Interface gráfica (GUI).
* **Selenium WebDriver (Chrome)**: Motor de automação de navegador.
* **Newtonsoft.Json**: Serialização e manipulação de dados JSON.

## Como executar o projeto

### Pré-requisitos
* Visual Studio 2022.
* Google Chrome instalado (versão recente).

### Passo a passo
1. Clone este repositório.
2. Abra o arquivo `PokePricer2.0.sln` no Visual Studio.
3. Ao compilar, o **NuGet** restaurará automaticamente os pacotes do Selenium e Json.NET.
4. Execute o projeto (`F5`).
5. Insira suas credenciais do TCG Collector e inicie a extração.

## Aviso Legal
Este software foi desenvolvido para fins educacionais e de uso pessoal para gerenciamento de coleção própria. O funcionamento depende do layout dos sites de terceiros, que podem sofrer alterações.
