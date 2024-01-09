
alter login alex23 with password='senha1234';
create user usuario from login alex23;
exec sp_addrolemember 'DB_DATAREADER', 'usuario';
exec sp_addrolemember 'DB_DATAWRITER', 'usuario';


CREATE TABLE Clientes
(
    Id int primary key identity,
	NomeCliente varchar(50) not null,
	Cnpj varchar(20) not null,
	Email varchar(50),
    Telefone varchar(20)
);

CREATE TABLE Produtos
(
	Id int primary key identity,
	NomeProduto varchar(50) not null,
	Descricao varchar(100) not null,
	Tipo varchar(50) not null,
	Preco decimal(4, 2) not null
);

CREATE TABLE Vendas
(
    Id int primary key identity,
	DataVenda datetime not null,
	ListaVenda varchar(100) not null,	
	ClienteId int not null,
    foreign key (ClienteId) references Clientes(Id),
    ProdutoId int not null,
    foreign key (ProdutoId) references Produtos(Id)
);

drop table Vendas
drop table Produtos
drop table Clientes




insert into Clientes(NomeCliente, Cnpj, Email, Telefone) values ('PostoDoZé', '0123456', 'ze@email.com', '40044000');
insert into Clientes(NomeCliente, Cnpj, Email, Telefone) values ('BrPosto', '0987654', 'br@email.com', '40049999');
insert into Clientes(NomeCliente, Cnpj, Email, Telefone) values ('Exxon', '22234555', 'exxon@email.com', '55554000');
insert into Clientes(NomeCliente, Cnpj, Email, Telefone) values ('7Eleven', '44889900', '7eleven@email.com', '88889999');



insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('Gasolina', 'Combustível', '', '', 3.15)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('Diesel', 'Combustível', '', '', 3.65)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('Alcool', 'Combustível', '', '', 2.15)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('Gas55', 'Gas', '', '', 17.12)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('Gas6', 'Gas', '', '', 31.43)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('Gas15', 'Gas', '', '', 122.77)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('ÓleoCarro',  'Óleo&Lubrificante', '', '', 19.99)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('ÓleoMoto',  'Óleo&Lubrificante', '', '', 9.99)
insert into Produtos(NomeProduto, Tipo, Descricao,  Quantidade, Preco) values ('ÓleoCaminhão', 'Óleo&Lubrificante', '', '', 29.99)

insert into Produtos(NomeProduto, Tipo, Descricao,Preco) values ('Gas55', 'Gas', '', 17.12);
insert into Produtos(NomeProduto, Tipo, Descricao, Preco) values ('ÓleoCarro',  'Óleo&Lubrificante', '', 19.99)



select * from Clientes

select * from Produtos