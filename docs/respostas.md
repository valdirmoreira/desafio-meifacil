# desafio-meifacil

Perguntas:


Explique com suas palavras o que é domain driven design e sua importância na estratégia de desenvolvimento de software.
==

O Domain Driven Design é uma abordagem para o desenvolvimento de software que ajuda a simplificar as complexidades que encontramos no nosso dia-a-dia como desenvolvedor, o DDD não é uma uma receita de bolo e muito menos uma bala de prata, tal abordagem reúne boas práticas para a modelagem de software focando no domínio da aplicação.
Meu primeiro contato com DDD foi um tanto quanto difícil, eu estava mudando de stack e até então tinha trabalhado somente com PHP e estava acostumado com o bom e velho MVC mas com o tempo pude perceber todos os benefícios que o DDD traz consigo, hoje por mais simples que o projeto seja e mesmo sabendo que posso estar praticando Overengineering eu utilizo DDD em todos meus projetos.
Alguns dos benefícios que pude notar utilizando o DDD foram: redução da complexidade, boa manutenibilidade, facilidade para testar aplicação, utilização dos conceitos de SOLID, não que seja obrigatório o uso do DDD para aplicar o SOLID mas utilizando o DDD você acaba praticando os princípios como responsabilidade única, inversão de dependências, entre outros naturalmente.


Explique com suas palavras o que é e como funciona uma arquitetura baseada em microservices. explique ganhos com este modelo, desafios em sua implementação e desvantagens.
==

Micro serviços é uma abordagem no desenvolvimento de software em que uma grande aplicação (monolítica) é divida em serviços pequenos, focados em negócios específicos que se comunicam entre si mas que sejam independentes um dos outros. Os principais benefícios que considero de uma abordagem baseada em microserviços são: o isolamento de prováveis falhas, ou seja se um serviço parar o outro não será afetado, a liberdade da escolha de tecnologia, micro serviços precisam se comunicar utilizando o mesmo protocolo mas podem ser construídos utilizando diversas linguagens, escalabilidade e reutilização, um microserviço pode ser escalado independente de outro serviço, além disso ele pode ser utilizado por diversos outros serviços. Eu considero que as principais dificuldades de se trabalhar com micro serviços seja na parte de infra, pois apesar de termos ferramentas incríveis hoje em dia como, por exemplo o Docker ainda é exigido um nível de conhecimento para que possa manter esses serviços rodando e consistentes. Como desvantagem eu acredito que no contexto geral da aplicação como toda é adicionada uma complexidade extra justamente para manter essa comunicação entre os serviços, apesar de que dividindo o software em pequenos pedaços teremos consequentemente problemas menores.


Explique qual a diferença entre processamento sincrono e assincrono e qual o melhor cenário para utilizar um ou outro.
==

Para falar de processamento síncrono e assíncrono eu preciso voltar aos meus tempos de desenvolvedor front-end pois foi nessa época que tive o primeiro contato com esses conceitos, foi utilizando o XMLHttpRequest para realizar chamadas ajax que conheci os conceito de processos síncronos e assíncronos. O Processamento síncrono é executado um após o outro, o próximo só inicia quando seu antecessor finalizar e assim por diante além disso eles são executados na mesma thread, já o processamento assíncrono não depende do resultado de outro processamento, os processos são realizados simultaneamente e quando o processo for concluído, ele notifica a thread principal. Apesar do processamento assíncrono parecer ser a melhor escolha temos que ter cuidado ao utilizar, um dos problemas que eu passei por exemplo foi o famoso callback hell.
Eu utilizo programação síncrona quando a operação a ser executada for simples, curta e que utiliza mais CPU (cálculos matemáticos, por exemplo) no lugar de rede e disco. Já a programação assíncrona utilizo quando preciso executar operações complexas, de alta performance e que geralmente utilizam rede e disco.
