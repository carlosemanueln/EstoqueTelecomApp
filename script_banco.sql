-- Cria o banco de dados
CREATE DATABASE EstoqueTelecom;

USE EstoqueTelecom;

-- 1. Tabela de Categorias
CREATE TABLE Categorias (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    descricao VARCHAR(255)
);

-- 2. Tabela de Usuários (Técnicos)
CREATE TABLE Usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    senha VARCHAR(255) NOT NULL
);

-- 3. Tabela de Equipamentos (Com chave estrangeira apontando para Categorias)
CREATE TABLE Equipamentos (
    id_equipamento INT AUTO_INCREMENT PRIMARY KEY,
    nome_modelo VARCHAR(100) NOT NULL,
    fabricante VARCHAR(50) NOT NULL,
    quantidade_estoque INT NOT NULL DEFAULT 0,
    id_categoria INT,
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria)
);

-- 4. Tabela de Ordens de Serviço (Com chave estrangeira apontando para Usuários)
CREATE TABLE Ordens_Servico (
    id_ordem INT AUTO_INCREMENT PRIMARY KEY,
    data_ordem DATETIME DEFAULT CURRENT_TIMESTAMP,
    tipo ENUM('Entrada', 'Saida') NOT NULL,
    id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);

-- 5. Tabela Intermediária (Liga as Ordens aos Equipamentos)
CREATE TABLE Itens_Ordem (
    id_item_ordem INT AUTO_INCREMENT PRIMARY KEY,
    id_ordem INT,
    id_equipamento INT,
    quantidade_movimentada INT NOT NULL,
    FOREIGN KEY (id_ordem) REFERENCES Ordens_Servico(id_ordem),
    FOREIGN KEY (id_equipamento) REFERENCES Equipamentos(id_equipamento)
);