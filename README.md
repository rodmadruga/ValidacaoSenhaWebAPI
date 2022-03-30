# ValidacaoSenhaWebAPI

Esta API possui a funcionalidade de validação de senha.

+ Critérios
    + Nove ou mais caracteres
    + Ao menos 1 dígito
    + Ao menos 1 letra minúscula
    + Ao menos 1 letra maiúscula
    + Ao menos 1 caractere especial, considerando os seguintes caracteres: !@#$%^&*()-+
    + Não possuir caracteres repetidos dentro do conjunto

## Respostas

| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso (success).|
| `400` | Erros de validação.|
| `404` | Registro pesquisado não encontrado (Not found).|


### Validar [GET /api/Senha/Validar/{senha}]

+ Parameters
    + senha (required, string, `a123456789Z@`) ... Senha

+ Response 200 - Senha válida.
    + Body

            true

+ Response 400 - Quando a senha não é válida.
    + Body

            "Necessário possuir nove ou mais caracteres"

