# TrabalhoFinalAcademiaNet

Este é o trabalho de conclusão da 5a. Academia .NET, em parceria da ATOS com a UFN. 
O objetivo é fazer um minissistema em C#, ASPNET Core, Entity Framework MVC, utilizando também SQL Server e Web API.
Este sistema foi pensado para uma empresa fornecedora de combustíveis, onde basicamente:
1) O usuário entra na página através de seu Login e Senha.
2) O usuário verifica na página "Clientes" os dados já cadastrados das empresas compradoras e também pode criar um novo "Cliente".
   2.1) Campos: Nome, Cnpj, email, telefone e CEP (que puxa para o sistema as informações do endereço utilizando a API do site ViaCEP).
   2.2) Também é possível alterar(edit), excluir(delete) e ver os detalhes do cliente cadastrado (details).
3) O usuário verifica na página "Produtos" os produtos já cadastrados e também pode criar um novo "Produto".
   3.1) Campos: Nome, Tipo, Quantidade-Estoque e Preço.
   3.2) Também é possível alterar(edit), excluir(delete) e ver os detalhes do produto cadastrado (details).
4) O usuário verifica na página "Vendas" as vendas já cadastradas e também pode criar um novo "Venda".
   4.1) Campos: ClienteId, ProdutoId, Data-Venda, Quantidade-Entrega e Endereço-Entrega.
   4.2) Em ClienteId é possível selecionar uma das empresas já cadastradas. A
   4.2.1) Ao selecionar um Cliente, as informações do endereço são preenchidas em Endereço-Entrega.   
   4.3) Em ProdutoId é possível selecionar um dos produtos já cadastrados.
   4.4) Ao selecionar a Quantidade-Entrega, o campo Quantidade-Estoque (página Produtos) é subtraído pela Quantidade-Entrega em Vendas.   
   4.5) Também é possível alterar(edit), excluir(delete) e ver os detalhes da venda cadastrada (details).
5) O usuário verifica na página "Entregas" os detalhes da venda feita e do produto que será entregue.
   5.1) É possível verificar, através de um API do Google Maps, o Mapa que mostra o ponto de partida e o ponto de destino da entrega.
   5.2) Em "Detalhes", além do mapa personalizado, é possível conferir a distância que será percorrida, o tempo estimado de deslocamento e os dias estimados para entrega.

   Por último, quero agradecer a toda equipe da ATOS pela oportunidade de crescimento profissional durante estes 3 meses de imersão na Academia!
   Também quero agradecer aos professor Ricardo, Fabrício e Alexandre pelas aulas e todo suporte fornecido nesse período!
   
