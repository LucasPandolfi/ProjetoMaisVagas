USE MaisVagas

SELECT Usuario.Nome, Usuario.Email, Usuario.Senha, Usuario.Foto, Usuario.Telefone, Usuario.CEP, Usuario.Estado, Usuario.Cidade, Usuario.Bairro, Usuario.IdTipoUsuario, TipoUsuario.Titulo FROM Usuario
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario;

SELECT Vaga.NomeVaga, Vaga.LogoEmpresa, Vaga.DescricaoVaga, Vaga.SoftSkills, Vaga.HardSkills, Vaga.QualificacaoProfissional, Vaga.NumeroVagaDisponiveis, Vaga.NivelExperiencia, Vaga.Jornada, Vaga.Setor, Vaga.Salario, Vaga.Beneficios, Vaga.IdEmpresa, Vaga.IdTipoContrato, TipoContrato.Nome FROM Vaga
INNER JOIN Empresa ON Vaga.IdVaga = Empresa.IdEmpresa
INNER JOIN TipoContrato ON Vaga.IdVaga = TipoContrato.IdTipoContrato;


SELECT Candidato.CPF, Candidato.DataNascimento, Candidato.Matricula, Candidato.AlunoExAluno, Candidato.IdCurso, Curso.Nome, Candidato.IdUsuario, Usuario.Nome FROM Candidato
INNER JOIN Curso ON Candidato.IdCurso = Curso.IdCurso
INNER JOIN Usuario ON Candidato.IdUsuario = Usuario.IdUsuario


SELECT  Administrador.NivelAcesso, Administrador.IdUsuario, Usuario.Nome FROM Administrador
INNER JOIN Usuario ON Administrador.IdAdministrador = Usuario.IdUsuario

SELECT Contrato.DataInicio, Contrato.DataTermino, Contrato.DiasContrato, Contrato.ResponsavelEstagio, Contrato.DescriçaoEstagio, Contrato.DescriçãoCancelamento, Contrato.IdSituacao, Situacao.Nome, Contrato.IdVaga, Vaga.NomeVaga, Contrato.IdCandidato FROM Contrato
INNER JOIN Situacao ON Contrato.IdContrato = Situacao.IdSituacao
INNER JOIN Vaga ON Contrato.IdContrato = Vaga.IdVaga
INNER JOIN Candidato ON Contrato.IdContrato = Candidato.IdCandidato

SELECT Inscricao.IdCandidato, Inscricao.IdVaga, Vaga.NomeVaga FROM Inscricao
INNER JOIN Vaga ON Inscricao.IdInscricao = Vaga.IdVaga







