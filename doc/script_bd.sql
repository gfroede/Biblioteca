-- Create table livros
CREATE TABLE `livros` (
  `id` INT PRIMARY KEY auto_increment,
  `titulo` VARCHAR(100) NOT NULL,
  `autor` VARCHAR(50) NOT NULL,
  `ano` int NOT NULL
);

-- Create emprestimos
CREATE TABLE `emprestimos` (
  `id` INT PRIMARY KEY auto_increment,
  `dataemprestimo` datetime(6) NOT NULL,
  `DataDevolucao` datetime(6) NOT NULL,
  `nomeusuario` VARCHAR(100) NOT NULL,
  `telefone` VARCHAR(20) NOT NULL,
  `devolvido` tinyint(1) NOT NULL,
  `livroid` int NOT NULL,
  constraint fk_LivroId foreign key (livroid) REFERENCES livros (id) 
);

--
-- Estrutura da tabela `usuario`
--
CREATE TABLE `usuario` (
  `id` INT PRIMARY KEY auto_increment,
  `nome` VARCHAR(200) NOT NULL,
  `login` VARCHAR(50) NOT NULL,
  `senha` VARCHAR(20) NOT NULL,
  `tipo` INT NOT NULL
);
