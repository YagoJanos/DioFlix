# DioFlix
# Um CRUD para cadastro de séries e filmes em .NET
#
## Detalhes de implementação
Nesse projeto implementei todas as possíveis melhorias citadas pelo professor no vídeo, inclusive o desafio de criar o cadastro de filmes, para tanto foram criados dois submenus a partir das escolhas do menu principal, um para a manipulação de filmes e outro para a manipulação de séries.

Além disso, implementei programação defensiva em todo o programa para que as escolhas erradas do usuário não interrompam o bom funcionamento do sistema. Também desenvolvi um mecanismo de limpeza no console para que a tela esteja sempre limpa para o usuário e a experiência seja sempre agradável sem a necessidade de limpezas esporádicas e manuais.

Quanto ao design, criei uma classe chamada Cinematografia que generaliza tanto a classe Filme quanto a classe Serie e que contem todos os atributos e métodos antes pertencentes
apenas à classe Serie, ou seja, agora Filme e Serie herdam de Cinematografia, o que permite o reaproveitamento de código.
A fim de prover uma melhor experiência para o usuário foi implementada uma tela estática ao fim de cada operação do CRUD contendo o resultado da mesma, essa tela permanece até que o usuário digite qualquer coisa então retornando ao menu anterior.

#
## No que estou trabalhando agora:

- Singleton nas classes dos repositórios, pois mesmo que seu uso seja considerado uma prática um pouco ruim por ir em sentido oposto ao princípio da responsabilidade única do SOLID, como se trata de um repositório único para filmes e um repositório único para séries, seria bom que não houvesse mais de uma instância desses repositórios.
- Criação de uma classe abstrata que ao mesmo tempo que implementa a interface IRepositorio, é superclasse de SerieRepositorio e FilmeRepositorio com o intuito de fazer com que essa nova classe abstrata criada possua a implementação genérica dos métodos de manipulação de repositório que serão usadas por ambas as classes filhas (pelo repositório de filmes e pelo repositório de séries), pois dessa forma caso haja necessidade de criação de mais algum repositório, bastará a criação de uma outra classe, respeitando o Open/Closed Principle do Solid e o reaproveitamento de código.

