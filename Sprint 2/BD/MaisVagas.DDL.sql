CREATE DATABASE MaisVagas

USE MaisVagas

CREATE TABLE TipoUsuario (
    IdTipoUsuario INT IDENTITY PRIMARY KEY,
    Titulo VARCHAR(60)
);

GO

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY PRIMARY KEY,
    Nome VARCHAR(117) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE,
    Senha VARCHAR(75) NOT NULL,
	Foto VARCHAR(255),
	Telefone VARCHAR(17),
    CEP CHAR(11),
    Estado VARCHAR(35),
    Cidade VARCHAR(40),
    Bairro VARCHAR(40),
    IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);

GO

CREATE TABLE Empresa (
    IdEmpresa INT IDENTITY PRIMARY KEY,
    CNPJ VARCHAR(17) NOT NULL UNIQUE,
    CNAE VARCHAR(10) NOT NULL,
    NumeroEmpregados VARCHAR(10) NOT NULL,
    NomeParaContato VARCHAR(110) NOT NULL,
	Verificacao BIT,
    ImagemCarimboCnpj VARCHAR(40),
    ImagemCarimboAssinaturaDoResponsavel VARCHAR(40),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
);

GO

CREATE TABLE TipoContrato (
	IdTipoContrato INT PRIMARY KEY IDENTITY,
	Nome	VARCHAR(80)
);

GO

CREATE TABLE Vaga (
    IdVaga INT PRIMARY KEY IDENTITY,
    NomeVaga VARCHAR(110) NOT NULL,
    LogoEmpresa VARCHAR(30),
    DescricaoVaga VARCHAR(255)NOT NULL,
    SoftSkills VARCHAR(60),
    HardSkills VARCHAR(60),
    QualificacaoProfissional VARCHAR(100),
    NumeroVagaDisponiveis VARCHAR(15) NOT NULL,
    NivelExperiencia VARCHAR(80),
    Jornada VARCHAR(100) NOT NULL,
    Setor VARCHAR(100) NOT NULL,
    Salario BIGINT NOT NULL,
    Beneficios VARCHAR(100),
	IdTipoContrato INT FOREIGN KEY REFERENCES TipoContrato(IdTipoContrato),
    IdEmpresa INT FOREIGN KEY REFERENCES Empresa(IdEmpresa)
);

GO

CREATE TABLE Curso (
    IdCurso INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(60) NOT NULL,
	Termo	VARCHAR(20) NOT NULL,
	Turno	VARCHAR(20) NOT NULL
);

GO

CREATE TABLE Candidato (
    IdCandidato INT PRIMARY KEY IDENTITY,
    CPF CHAR(14) NOT NULL UNIQUE,
    DataNascimento DATE NOT NULL,
    Matricula CHAR(8) NOT NULL,
    AlunoExAluno BIT,
	Curriculo	VARCHAR(110),
    IdCurso INT FOREIGN KEY REFERENCES Curso(IdCurso),
    IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
);

GO

CREATE TABLE Situacao(
	IdSituacao INT PRIMARY KEY IDENTITY,
	Nome	VARCHAR(50),
);

GO

CREATE TABLE Contrato (
	IdContrato	INT PRIMARY KEY IDENTITY,
	DataInicio	DATE NOT NULL,
	DataTermino DATE NOT NULL,
	DiasContrato	VARCHAR(15),
	ResponsavelEstagio	VARCHAR(110),
	DescriçaoEstagio	VARCHAR(255),
	DescriçãoCancelamento	VARCHAR(255),
	IdTipoContrato INT FOREIGN KEY REFERENCES TipoContrato(IdTipoContrato),
	IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
	IdVaga		INT FOREIGN KEY REFERENCES Vaga(IdVaga),
	IdCandidato	INT FOREIGN KEY REFERENCES Candidato(IdCandidato)
);


GO

CREATE TABLE Inscricao(
	IdInscricao INT PRIMARY KEY IDENTITY,
	Selecionado BIT,
	IdVaga		INT FOREIGN KEY REFERENCES Vaga(IdVaga),
	IdCandidato	INT FOREIGN KEY REFERENCES Candidato(IdCandidato)
);

GO

CREATE TABLE Administrador (
    IdAdministrador INT PRIMARY KEY IDENTITY,
	NivelAcesso		BIT,
    IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
);

GO

CREATE TABLE VagasFavoritas(
	IdVagasFavoritas INT PRIMARY KEY IDENTITY,
	IdCandidato INT FOREIGN KEY REFERENCES Candidato(IdCandidato),
	IdVaga		INT FOREIGN KEY REFERENCES Vaga(IdVaga)
);

SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM Empresa
SELECT * FROM Vaga
SELECT * FROM Candidato
SELECT * FROM Curso
SELECT * FROM Inscricao
SELECT * FROM Situacao
SELECT * FROM Contrato
SELECT * FROM Administrador
SELECT * FROM VagasFavoritas
SELECT * FROM TipoContrato

delete from Candidato where IdCurso=1


truncate table Contrato
truncate table Candidato
truncate table Curso
truncate table Usuario
truncate table Inscricao
truncate table VagasFavoritas




