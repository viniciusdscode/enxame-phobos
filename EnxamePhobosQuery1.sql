use EnxamePhobosDB;
select * from filme;
select*from tipousuario;

insert into tipousuario (Descricao) values ('Adminastrador'),('Outros'); 

insert into usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_id) values 
('Uil','uil@email.com','123456','19800229',1),('Robsu','robsu@email.com','123457','19600622',2); 

/* Autenticar */

select Nome, Senha, TipoUsuario_id from Usuario where Nome='Robsu' and Senha='123457';

/*listar*/
select Usuario.id, Nome, Email, Senha, DataNascUsuario, Descricao from Usuario inner join TipoUsuario
on Usuario.TipoUsuario_id = TipoUsuario.id order by Usuario.id asc; 

SELECT Usuario.id, Nome, Email, Senha, DataNascUsuario, Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.TipoUsuario_id = TipoUsuario.id WHERE usuario.nome = 'robsu';

SELECT Usuario.Id, Nome, Email, Senha, DataNascUsuario, Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.TipoUsuario_id = TipoUsuario.id WHERE usuario.nome = 'uil';

/**/
select*from usuario where usuario.nome = 'uil';

insert into usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_id) values 
('Cylvia','cylvia@email.com','111111','20010329',2),('Infernia','infernia@email.com','222222','19921016',1),('Samael','samael@email.com','333333','19880607',2); 

update Usuario set Nome = 'kaiqque',Email='kaiqque@email.com' where Usuario.Id = 6;

DELETE FROM filme WHERE filme.Id = 21;

select * from Filme;

insert into Classificacao (Descricao) values ('Livre'),('+14'),('+18'); 
select * from Classificacao;

insert into Genero (Descricao) values ('Animação'),('Aventura'),('Drama'),('Ficção'),('Terror'); 
select * from Genero;

insert into filme (titulo,produtora,urlimg,classificacao_id,genero_id) values 
('Pânico','Dimension Films','c:\\img\\panico.png',3,5),
('Terrifier','´Epic Pictures Group','c:\\img\\terrifier.png',3,5),
('De Volta Pro Futuro','Universal Studios','c:\\img\\futuro.png',1,4),
('Jumanji','Columbia Pictures','c:\\img\\jumanji.png',2,4),
('As Fumaças Falaram Por Mim','Zoio','c:\\img\\alek.pnh',2,3), 
('Peter Pan','Universal Studios','c:\\img\\peterpan.png',2,2),  
('Toy Story','Pixar','c:\\img\\brinquedos.png',1,1); 

select * from filme where titulo = 'Jumanji';

select filme.id,titulo,produtora,urlimg,genero.GENERO,classificacao.CLASSIFICACAO from filme
inner join genero on genero_id = genero.id inner join classificacao on classificacao_id = classificacao.id
order by filme.id asc;

update filme set urlimg = 'c:\\img\\alek.png' where id = 5;

SELECT filme.id,titulo,produtora,urlimg,genero.descricao AS genero,classificacao.descricao AS classificacao FROM filme INNER JOIN genero ON genero_id = genero.id
INNER JOIN classificacao ON classificacao_id = classificacao.id ORDER BY filme.id ASC;

SELECT * FROM filme WHERE filme.Titulo = titulo;

UPDATE filme SET UrlImg = '~/resource/img/panico.jpg' WHERE id=1;
UPDATE filme SET UrlImg = '~/resource/img/terrifier.jpg' WHERE id=2;
UPDATE filme SET UrlImg = '~/resource/img/future.jpg' WHERE id=3;
UPDATE filme SET UrlImg = '~/resource/img/jumanj.jpg' WHERE id=4;
UPDATE filme SET UrlImg = '~/resource/img/20191016040230.jpg' WHERE id=5;
UPDATE filme SET UrlImg = '~/resource/img/peter.jpg' WHERE id=6;
UPDATE filme SET UrlImg = '~/resource/img/toy.jpg' WHERE id=7;

ALTER TABLE genero
CHANGE GENERO1 Genero VARCHAR(150) NOT NULL;

describe GENERO;

ALTER TABLE classificacao
CHANGE descricao DescricaoClassificacao VARCHAR(150) NOT NULL;

DELETE FROM usuario WHERE usuario.id = 21;

SELECT filme.id,titulo,produtora,urlimg,genero.DescricaoGenero,classificacao.DescricaoClassificacao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON classificacao_id = classificacao.id ORDER BY filme.id ASC;


select * from usuario;

SELECT filme.id,Titulo,produtora,UrlImg,genero_id, DescricaoClassificacao FROM filme INNER JOIN classificacao ON classificacao_id = classificacao.id WHERE filme.Titulo = 'Terrifier';

SELECT * FROM filme WHERE filme.id = 2;

UPDATE filme SET Titulo='Terrifier', Produtora='MONDO', UrlImg='~/resource/img/terrifier.jpg', Genero_Id='5', Classificacao_Id='2' WHERE filme.Id = '2';

SELECT Usuario.Id, Nome, Email, Senha, DataNascUsuario, Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.TipoUsuario_Id = TipoUsuario.Id WHERE Usuario.Nome = 'robsu';

SELECT filme.id,Titulo,Produtora,UrlImg,DescricaoGenero,DescricaoClassificacao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON Classificacao_Id = classificacao.id WHERE filme.titulo = 'Terrifier';


SELECT filme.id,titulo,produtora,urlimg,genero.DescricaoGenero,classificacao.DescricaoClassificacao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON classificacao_id = classificacao.id