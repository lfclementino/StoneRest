Desafio Stone

Setembro/2017

- Objetivos

1) Construir um aplicativo para monitorar a temperatura de determinadas cidades e armazenar em um banco de dados. 

2) Construir uma Web API RESTful para acesso e controle das informações contidas no banco.

- Rotas de comando:

GET: /api/cities/{city_name}/temperatures - Retorna as temperaturas das últimas 30 horas da cidade informada.
POST: /api/cities/{city_name} - Cadastra uma nova cidade para ter a temperatura monitorada.
DELETE: /api/cities/{city_name} - Remove uma cidade do monitoramento.
DELETE: /api/cities/{city_name}/temperatures - Apaga o histórico de temperaturas da cidade.
GET: /temperatures/ - Retorna a lista paginada das cidades em ordem decrescente da última temperatura registrada.

i- Bônus:

POST: /api/cities/by_cep/{cep} - Cadastrar uma cidade pelo seu CEP.

OBS: Caminho /api/ foi necessário para evitar conflito entre a Web API e o MVC na solução.

- Banco de Dados

Foi utilizado o "LiteDB", um banco NoSQL para .NET considerado adequado às necessidades do projeto.

- StoneRest.Monitor

Aplicativo para monitorar as temperaturas. Deve ser executado de dentro da pasta do projeto da Web API (/StoneRest)
