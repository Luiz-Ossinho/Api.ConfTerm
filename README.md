# CONF-TERM

Api REST criada para dar suporte a um modulo web para sistema um sistema embarcado com determina��o de �ndices de conforto t�rmico.   
Vai ser usado no meu projeto de TCC, onde vai se acumular um banco de dados de indices de conforto termicos e emitir relatorios para produtores do nordeste.   
Usa SQLite InMemmory quando rodando localmente.   
Nao aplica migrations ainda, optando por usar EnsureCreated.   
Tem swagger e [instalacao no heroku](https://conf-term.herokuapp.com).   

# Board de contribuicao.
Alem dos pontos comentados, qualquer contribuicao ou discussao � bem vinda.

## TODO
* Opniao sobre globalizacao
	* Vendo como o codigo ja esta baguncado nesse sentido, acho que vou preferir deixar tudo em ingles no codigo e nem implementar globalizacao pelo tutorial da microsoft
* Opiniao sobre Startup
	* Juntando varios objetos de configuracao em um so, armengue ou legal?
	* Criacao de um scope no configure, tem alternativas?

## IN PROGRESS
* Solucao para validacao de erros e controle de fluxo nos Handlers (UseCase)
	* Foi avaliado que maior separacao em metodos e uso de FluentValidation para gerar erros � o suficiente
* Checar implementacao do Handler Pattern
	* MediatoR iria diminuir parametros nos endpoints.
* Criar endpoints GET antes de comecar integracao com front end