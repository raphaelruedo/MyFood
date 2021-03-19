# MyFood 
- https://myfood-teste.azurewebsites.net/swagger/index.html
## Projeto de Teste
Projeto de teste e estudos
## Tecnologias

- .NET Core 5
- CQRS
- DDD
- AutoMapper
- .NET Core Native DI
- FluentValidator
- MediatR
- Azure Services

## Features
- Criação de novos restaurantes
- Atualização
- Exclusão
- Listagem de todos restaurantes
- Listagem de restaurante por Id
- Listagem dos restaurantes mais próximos

## Como Usar

Obs: Caso prefira utilizar baixar a collection para Insomnia no repositório para agilizar as chamadas

Install the dependencies and devDependencies and start the server.

## Criação 

```sh
POST
Endpoint: https://myfood-teste.azurewebsites.net/api/Restaurant
Headers: Content-Type: application/json
body:
{
  "name": "Bolos no Pote",
  "description": "Os melhores doces no pote da Sorocaba",
  "isActive": true,
  "expertiseId": "99b87677-c9b6-486a-81a9-731b85e76b30",
  "address": {
    "street": "Rua Ana Augusta Soares",
    "number": 100,
    "complement": "",
    "city": "Sorocaba",
    "district": "Jardim Leocadia",
    "country": "Brasil",
    "longitude": "-23.4356452",
    "latitude": "46.7429576",
    "zipCode": "18085160"
	}
}
```
## Listar Todos
```sh
GET
https://myfood-teste.azurewebsites.net/api/Restaurant
```

## Lista por Id
```sh
GET
https://myfood-teste.azurewebsites.net/api/Restaurant/{Id}
Exemplo: https://myfood-teste.azurewebsites.net//api/Restaurant/1517cbc4-103f-42f3-b111-5f037c5c774c
```
## Update
```sh
PUT
Endpoint: https://myfood-teste.azurewebsites.net/api/Restaurant
Headers: Content-Type: application/json
body:
{
	"id": "3394e003-2fdd-43f3-83c3-c72563d2c654",
  "name": "Os melhores Bolos no pote",
  "description": "Os melhores doces no pote da Sorocaba",
  "isActive": true,
  "expertiseId": "99b87677-c9b6-486a-81a9-731b85e76b30",
  "address": {
    "street": "Rua Ana Augusta Soares",
    "number": 100,
    "complement": "",
    "city": "Sorocaba",
    "district": "Jardim Leocadia",
    "country": "Brasil",
    "longitude": "-23.4356452",
    "latitude": "46.7429576",
    "zipCode": "18085160"
	}
}
```
## DELETE
```sh
DELETE
https://myfood-teste.azurewebsites.net/api/Restaurant/{Id}
Exemplo: https://myfood-teste.azurewebsites.net//api/Restaurant/1517cbc4-103f-42f3-b111-5f037c5c774c
```

## Listar os mais próximos
```sh
GET
https://myfood-teste.azurewebsites.net//api/Restaurant/-21.1372829/-48.9635144/1000
```



## License

MIT

**Free Software, Hell Yeah!**
