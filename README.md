# PokePricer

Ferramenta desktop para precificar coleção de Pokémon TCG com base na LigaPokemon.

![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow?style=flat-square)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=flat-square)
![Selenium](https://img.shields.io/badge/Selenium-WebDriver-43B02A?style=flat-square)

## Sobre

Conecta a coleção do TCG Collector com preços do mercado brasileiro (LigaPokemon).  
A ideia é evitar checar carta por carta e converter a coleção para valor real em R$.

## Stack

| Item | Tecnologia |
| --- | --- |
| Linguagem | C# (.NET Framework 4.8) |
| Interface | Windows Forms |
| Automação | Selenium WebDriver (Chrome) |
| Dados | Newtonsoft.Json |

## Funcionalidades

- Login automatizado no TCG Collector
- Extração da coleção (nome, ID, set, variantes)
- Busca de preço na LigaPokemon
- Filtros (ex.: ignorar variantes japonesas quando necessário)
- Identificação do menor preço por condição
- Exporta coleção bruta em `cartas.json`
- Gera relatório de valores em `precos_pokemon.json`

## Como rodar

Requisitos: Visual Studio 2022 e Google Chrome.

1. Clone o repositório
2. Abra `PokePricer2.0.sln` no Visual Studio
3. Compile (NuGet restaura Selenium e Json.NET)
4. Execute com F5
5. Informe as credenciais do TCG Collector e inicie a extração

## Aviso

Uso pessoal e educacional. O funcionamento depende do layout de sites de terceiros, que podem mudar.

## Autor

[Paulo Mafra Watanabe](https://github.com/paulomafraa) · [LinkedIn](https://www.linkedin.com/in/paulo-watanabe/)
