# 🚗 Desafio - Sistema de Locadoras de Veículos

Este projeto tem como objetivo a construção de um sistema para **gestão de locadoras de veículos**, incluindo cadastro, gerenciamento e relatórios.  
O desafio aborda conceitos de **relacionamento entre entidades**, **restrição de duplicidades** e **histórico (log) de movimentação de veículos**.

---

## 📋 Requisitos do Sistema

### Entidades

- **Locadoras**
  - Atributos: `Nome Fantasia`, `Razão Social`, `CNPJ`, `E-mail`, `Telefone`
  - Cada locadora possui um **endereço**:
    - Atributos: `CEP`, `Rua`, `Número`, `Bairro`, `Estado`, `Cidade`
  - **Regra**: não permitir duplicidade de locadoras (referência: **CNPJ**)

- **Montadoras**
  - Atributos: `Nome`
  - **Regra**: não permitir duplicidade de montadora

- **Modelos**
  - Atributos: `Nome`, `Montadora`
  - **Regra**: não permitir duplicidade de modelos (referência: **Nome + Montadora**)

- **Veículos**
  - Atributos: `Número de Portas`, `Modelo`, `Cor`, `Fabricante`, `Ano Modelo`, `Ano Fabricação`, `Placa`, `Chassi`, `Data de Criação`
  - **Regra**: não permitir duplicidade de veículos (referência: **Placa + Chassi**)
  - Um veículo pertence a uma **locadora**, mas pode ser transferido entre locadoras
  - Deve existir um **log histórico** com os períodos de cada veículo em cada locadora

---

## 📊 Relatórios

1. **Locadoras x Veículos**
   - Informações: Nome da locadora (atual dona), Modelo*, Placa, Data de cadastro
   - Filtros: Locadora, Data de criação do veículo, Modelos (dropdown)
   - Caso nenhum filtro seja aplicado → retorna todos os registros

2. **Locadoras x Modelos**
   - Informações: Nome da locadora, Modelo*, Quantidade de veículos por modelo

3. **Log de Veículos**
   - Informações: Nome da locadora, Modelo*, Data de início e Data de fim (se houver)

> **Observação:** *Modelo* deve considerar **Nome do Modelo + Nome da Montadora**

---

## 🛠️ Tecnologias Permitidas

- **Banco de Dados**: SQL Server  
- **Backend**: C#  
- **Frontend**: Angular  

---

## 🚀 Como Executar o Projeto

### 2. Configuração do Banco
- Criar um banco no **SQL Server**
- Executar os scripts de criação das tabelas (em `./database`)

### 3. Backend
```bash
cd backend
dotnet restore
dotnet run
