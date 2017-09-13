Desafio Stone

Setembro/2017

- Objetivos

1) Construir um aplicativo para monitorar a temperatura de determinadas cidades e armazenar em um banco de dados. 

2) Construir uma Web API RESTful para acesso e controle das informa��es contidas no banco.

- Rotas de comando:

GET: /api/cities/{city_name}/temperatures - Retorna as temperaturas das �ltimas 30 horas da cidade informada.
POST: /api/cities/{city_name} - Cadastra uma nova cidade para ter a temperatura monitorada.
DELETE: /api/cities/{city_name} - Remove uma cidade do monitoramento.
DELETE: /api/cities/{city_name}/temperatures - Apaga o hist�rico de temperaturas da cidade.
GET: /temperatures/ - Retorna a lista paginada das cidades em ordem decrescente da �ltima temperatura registrada.

i- B�nus:

POST: /api/cities/by_cep/{cep} - Cadastrar uma cidade pelo seu CEP.

OBS: Caminho /api/ foi necess�rio para evitar conflito entre a Web API e o MVC na solu��o.

- Banco de Dados

Foi utilizado o "LiteDB", um banco NoSQL para .NET considerado adequado �s necessidades do projeto.

- StoneRest.Monitor

Aplicativo para monitorar as temperaturas. Deve ser executado de dentro da pasta do projeto da Web API (/StoneRest)
