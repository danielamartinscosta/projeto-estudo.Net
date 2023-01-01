CREATE TABLE clientes(
    id int NOT NULL AUTO_INCREMENT,
    nome varchar(100) NOT NULL,
    email varchar(150),
    PRIMARY KEY (id)
);


/*para ver todos os itens cadastrados na tabela*/
select * from clientes;

/*para ver itens específicos cadastrados na tabela*/
select * from clientes where id = 1; --filtra por um id
select * from clientes where id in (1,2); --filtra por vários id's

/*para filtrar por nome de forma exata*/
select * from clientes where nome = 'Daniela'

/*para filtrar por nome de forma exata (o nome tem que estar escrito da mesma forma)*/
select * from clientes where nome = 'Daniela'

/*para filtrar por parte do nome*/
select * from clientes where nome like 'Dan%'--filtra por parte do nome no começo

/*para filtrar por parte do nome*/
select * from clientes where nome like '%ela'--filtra por parte do nome no final

/*para filtrar por parte do nome*/
select * from clientes where nome like '%Dan%'--filtra por qualquer parte do nome

select * from clientes where id = '10' or email like '%bia%'


/*Inserir*/
insert into clientes(nome, email)values('Daniela', 'dani@gmail.com');
insert into clientes(nome, email)values('Beatriz', 'bia@gmail.com');

/*update -alterar*/

update clientes set nome='Beatriz', email='beatriz@gmail.com' where id=2;

/*delete - deletar*/
delete from clientes where id=2;


START TRANSACTION; -- starta uma transação segura onde precisa de confirmação para efetuar
COMMIT; --confirma a transação
ROLLBACK; -- desfaz a transação

/*Como fazer um dump/backup no banco de dados*/
mysqldump -u [username-usuario] -p [password] [options] [database-name] [tablename] > [dumpfilename.sql]

mysqldump -uroot -p persistencia_codigo_do_futuro > console/sql/backup.sql;

/*Para fazer uma retauração do banco de dados*/
mysql -u root -p persistencia_codigo_do_futuro < console/sql/backup.sql;






CREATE TABLE produtos(
    id int NOT NULL AUTO_INCREMENT,
    nome varchar(100) NOT NULL,
    descricao varchar(250),
    data_criacao DATE NOT NULL,
    data_validade DATE NOT NULL,
    quatidade_estoque int NOT NULL,
    PRIMARY KEY (id)
);