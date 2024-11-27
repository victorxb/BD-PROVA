# Prova de Banco de dados.

Instruções para o uso:

Instalar MSQL workbench 8.0 C.E
- carregar a seguinte querry:
  CREATE DATABASE ColaboradorDB
  default character set utf8mb4
  default collate utf8mb4_general_ci;
  
  USE ColaboradorDB;
  
  CREATE TABLE Colaboradores (
      Id INT AUTO_INCREMENT PRIMARY KEY,
      Ctps VARCHAR(20) NOT NULL,
      Pis VARCHAR(20) NOT NULL,
      TituloEleitor VARCHAR(20),
      Reservista BOOLEAN,
      EstadoCivil VARCHAR(15),
      NumDependentes INT,
      Ativo BOOLEAN,
      Setor VARCHAR(50),
      Cargo VARCHAR(50),
      Salario DECIMAL(10,2),
      Telefone1 VARCHAR(15),
      Telefone2 VARCHAR(15),
      EmailPessoal VARCHAR(50),
      EmailCorporativo VARCHAR(50)
  );

Feito com visual studio code community 2022: https://visualstudio.microsoft.com/pt-br/vs/

Rodar ele no visual studio code.
