USE  MaisVagas;

INSERT INTO TipoUsuario(Titulo)
VALUES ('Administrador'), ('Candidato'), ('Empresa');



INSERT INTO Usuario(Nome, Email, Senha, Foto, Telefone, CEP, Estado, Cidade, Bairro, IdTipoUsuario)
VALUES  ('Isabella Alves',	'isa@g.com'	,'111111', 'Foto' , '+55 11 11111-1111',	'05945-090',	'São Paulo',	'São Paulo',	'Vila Mirante', 1),
		('Lucas Lagos',	'luck@g.com',	'222222', 'Foto' , '+55 11 22222-2222',	'05945-090',	'São Paulo',	'Mogi Das Cruzes',	'Vila Oliveira', 1),
		('TITec',	'titec@titec.com',	'111111', 'Foto' , '+55 11 33333-3333'	,'05945-090',	'São Paulo'	,'São Paulo',	'Vila Mirante', 3),
		('Daniel Araujo',	'dan@g.com',	'222222', 'Foto' , '+55 11 44444-4444', '05945-090',	'São Paulo',	'Mogi Das Cruzes',	'Vila Oliveira', 2),
		('Gustavo Xavier',	'gusta@g.com',	'111111', 'Foto' , '+55 11 55555-5555',	'05945-090',	'São Paulo',	'São Paulo',	'Vila Mirante', 2),
		('Reconty',	'reconty@contyg.com',	'222222', 'Foto' , '+55 11 66666-6666',	'05945-090',	'São Paulo',	'Mogi Das Cruzes',	'Vila Oliveira',3),
		('Priscila',	'pri@prig.com',	'111111', 'Foto' , '+55 11 77777-7777',	'05945-090',	'São Paulo',	'São Paulo',	'Vila Mirante', 2);

		Select * from Empresa

INSERT INTO Empresa(CNPJ, CNAE, NumeroEmpregados, NomeParaContato, ImagemCarimboCnpj, ImagemCarimboAssinaturaDoResponsavel, Verificacao, IdUsuario)
VALUES	('12345122324244',	'1234567',	'2650',	'Alexandre', 'Url',	'Url', 0, 3),
		('98765412412152',	'7654321',	'1234',	'Saulo', 'Url',	'Url', 1, 6);

INSERT INTO TipoContrato(Nome)
VALUES	('Tempo Determinado'),('Tempo Indeterminado'),('Clt'),('Estagio');

INSERT INTO Vaga(NomeVaga, LogoEmpresa, DescricaoVaga, SoftSkills, HardSkills, QualificacaoProfissional, NumeroVagaDisponiveis, NivelExperiencia, Jornada, Setor, Salario, Beneficios, IdEmpresa, IdTipoContrato)
VALUES	('FullStack', 'img', 'Vaga que busca Desenvolvedores Full Stack com algumas especificações, sendo elas, Ingles intermediario, Analise de dados e Redes e Computadores.','Proatividade, Flexibilidade e Criatividade.','Tecnicas Gerais, Detecções e Soluções de Problemas', 'senior' , '23 vagas','1 ano no mercado', '8 horas', 'Setor de desenvolvimento', 1900, 'Vt+Vr', 1, 4),
		('Estagio',	'img', 'Vaga que busca estagiarios Desenvolvimentos de Sistemas com algumas especificações, sendo elas, Ingles intermediario, Armazenamento de dados e Big Data.','Comunicabilidade, Visão Global de Negocios', 'Atualização de Habilidades e  User Experience Design', 'Senior' ,'12 vagas' , '2 anos no mercado', '6 horas',	'Setor de desenvolvimento',	1500,	'Vt+Vr', 2, 4);
select * from Vaga

INSERT INTO Curso(Nome, Termo, Turno)
VALUES ('Desenvolvimento', '1°', 'Manhã'), ('Redes', '2°', 'Tarde'),('Multimidias', '3°', 'Tarde');


INSERT INTO Candidato( CPF, DataNascimento, Matricula, AlunoExAluno, Curriculo, IdCurso, IdUsuario)
VALUES	('12345678909', '02/01/1990', '11111111',	'1','Url' , 1,	2),
		('13344576207', '13/02/2001', '22222222'	,'2','Url' , 2,	5);


INSERT INTO Administrador(IdUsuario, NivelAcesso)
VALUES	(1, 1), (2, 1);


INSERT INTO Situacao(Nome)
VALUES ('Concluido'), ('Pendente'), ('Cancelado');

INSERT INTO Contrato(DataInicio, DataTermino, DiasContrato, ResponsavelEstagio, DescriçaoEstagio, DescriçãoCancelamento, IdTipoContrato ,IdSituacao, IdVaga, IdCandidato)
VALUES	('04/09/2020','04/09/2021', '365', 'Thiago', 'O Aluno efetuará atividades tecnicas sobre Front-End e Back-End','Opcional', 1 , 2, 3, 1),
		('05/09/2020','05/09/2021', '365', 'Kaique', 'O Aluno efetuará atividades tecnicas sobre Front-End e Back-End','Opcional', 4 ,2, 4, 2);
		select * from Contrato

INSERT INTO Inscricao(Selecionado, IdCandidato, IdVaga)
VALUES (1, 1, 3);

INSERT INTO VagasFavoritas(IdVaga, IdCandidato)
VALUES (3, 1); 






		

		
