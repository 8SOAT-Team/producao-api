# language: pt-BR
Funcionalidade: Gerenciar itens do pedido
  Para garantir que os itens de um pedido sejam gerenciados corretamente,
  Como desenvolvedor
  Eu quero realizar testes de comportamento na classe ItemDoPedido.

  Cenário: Criar um item do pedido válido
    Dado que eu tenha um pedido com ID "c6e5d33d-7c1e-48a5-8a94-d40b317915bc"
      E um produto com ID "f0fdbefb-08b2-4ad7-bdfc-8c3f0e070d8e" e categoria Acompanhamento
      E uma quantidade igual a 2
    Quando eu criar o item do pedido
    Então o item deve ser criado com sucesso

  Cenário: Tentar criar um item com quantidade inválida
    Dado que eu tenha um pedido com ID "c6e5d33d-7c1e-48a5-8a94-d40b317915bc"
      E um produto com ID "f0fdbefb-08b2-4ad7-bdfc-8c3f0e070d8e"
      E uma quantidade igual a 0    
    Então uma exceção deve ser lançada com a mensagem "Obrigatório informar uma quantidade maior que zero."
