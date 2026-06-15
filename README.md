# EstoqueTelecomApp — Gestão Resiliente de Ativos de Rede

Um ecossistema de software multiplataforma moderno, desenvolvido em C# com .NET MAUI, projetado especificamente para enfrentar os desafios logísticos e operacionais na expansão de infraestruturas críticas de telecomunicações (como redes de Fibra Óptica GPON e implantações de células 5G/6G).

O grande diferencial deste projeto reside na sua **arquitetura de persistência híbrida e distribuída**, integrando três paradigmas de bancos de dados diferentes (MySQL, SQLite e MongoDB) para entregar uma solução robusta e focada na experiência humana da equipe de campo.

---

## 🚀 Pilares Tecnológicos e Propósito Científico

Em operações reais de engenharia de rede, os sistemas de software tradicionais falham ao assumir uma conectividade perfeita. Este projeto quebra esse paradigma ao implementar uma arquitetura resiliente dividida em três frentes:

1. **Persistência Central Estruturada (MySQL):** Gerencia o núcleo do inventário corporativo, categorias rígidas e dados relacionais com forte integridade referencial através de conexões de alto desempenho.
2. **Arquitetura de Resiliência Local (SQLite — Offline First):** Pensando exclusivamente no operador técnico que trabalha em áreas rurais ou zonas de sombra de sinal (sem cobertura 5G ou celular), o aplicativo possui um banco embutido no dispositivo. O técnico registra o consumo de ativos (como ONUs, OLTs e cabos) localmente com segurança absoluta de dados, habilitando flags para posterior sincronização com o servidor central assim que a conectividade for restabelecida.
3. **Auditoria Massiva Não-Relacional (MongoDB):** Utiliza o paradigma NoSQL baseado em documentos JSON para atuar como a "caixa-preta" do sistema. Toda mutação de estado crítica realizada na infraestrutura de estoque dispara logs telemétricos assíncronos e extremamente rápidos para o MongoDB, garantindo conformidade de auditoria sem gerar gargalos de performance nas tabelas relacionais do MySQL.

---

## 🏛️ Padrões de Projeto e Arquitetura de Software

O código foi meticulosamente blindado utilizando boas práticas de Engenharia de Software e Programação Orientada a Objetos (POO):

* **Arquitetura em Camadas (Decoupled MVC + Service):** Isolamento total de responsabilidades. A interface gráfica (View) não conhece o banco de dados; ela se comunica com os *Controllers* (pontes de comando), que por sua vez acionam a camada de *Services* (onde residem as regras de negócio e validações lógicas), que utilizam os objetos *DAO* para gravação física.
* **Polimorfismo com Generics (`IDAO<T>`):** Criação de contratos de interfaces genéricas. Isso permite que o sistema mude o destino da gravação de dados (seja trocando o conector MySQL por outro fornecedor) sem alterar uma única linha da lógica de negócio ou da interface do usuário.
* **Resiliência a Falhas Críticas:** Mecanismos de contenção (*Try-Catch Bloking*) implementados na camada de auditoria externa para garantir que instabilidades temporárias em servidores secundários (como o MongoDB) jamais causem o fechamento abrupto (*crash*) do aplicativo principal do técnico na ponta.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# 10/11 (.NET 8)
* **Framework Multiplataforma:** .NET MAUI (suporte nativo a Windows, Android, iOS e macOS)
* **Bancos de Dados:**
  * **MySQL** (Relacional Central)
  * **SQLite** (Relacional Local/Embutido)
  * **MongoDB** (NoSQL Baseado em Documentos)
* **Conectores e Bibliotecas:** `MySqlConnector`, `Microsoft.Data.Sqlite`, `MongoDB.Driver`

---

## 📁 Estrutura Externa do Projeto

```text
EstoqueTelecomApp/
│
├── Models/           # Classes de Entidade Puras (Categoria, Equipamento, Usuario, Log)
├── Interfaces/       # Contratos Genéricos (IDAO<T>, IService<T>, IController<T>)
├── DAO/              # Data Access Objects (Implementações específicas MySQL, SQLite, MongoDB)
├── Services/         # Camada de Inteligência e Validação de Regras de Negócio
├── Controllers/      # Controladores de Fluxo (Orquestradores entre View e Service)
└── Views/            # Telas Declarativas em XAML e lógicas de componentes (code-behind)


## 🏁 Como Executar o Projeto

### Pré-requisitos
* Visual Studio 2022 (com carga de trabalho .NET MAUI)
* MySQL Server (porta 3306) e MongoDB Server (porta 27017) ativos localmente

### Passo a Passo
1. **Clone o projeto:** `git clone https://github.com/carlosemanueln/EstoqueTelecomApp.git`
2. **MySQL:** Execute o script SQL de criação no MySQL Workbench para gerar a base `EstoqueTelecomDB` e suas tabelas.
3. **Execução:** Abra o `.sln` no Visual Studio e clique em **Windows Machine** (Play). O app restaurará as dependências NuGet automaticamente e criará a base SQLite e a coleção MongoDB no primeiro uso.

---

## 📡 Impacto Operacional e Conectividade

Este ecossistema foi projetado para unir rigor técnico e valor humano. Na expansão de infraestruturas críticas de telecomunicações (redes de Fibra Óptica GPON e antenas 5G), o técnico de campo frequentemente enfrenta áreas de sombra de sinal. 

A arquitetura híbrida resolve esse problema: a separação em camadas via MVC e o uso de interfaces garantem um software escalável e limpo, enquanto o armazenamento local (SQLite) combinado à auditoria assíncrona (MongoDB) entregam uma aplicação infalível na ponta da linha, blindando a operação contra perdas de dados e falhas de rede.