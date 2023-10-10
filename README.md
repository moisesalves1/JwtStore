# Curso 3001 do Balta.io - Segurança em APIs ASP.NET com JWT e Bearer Authentication

## Neste curso sobre segurança em APIs eu pude entender sobre...

*   Autenticação no ASP.NET
*   Autorização no ASP.NET
*   Token
*   Claim
*   Role
*   Policy
*   JWT
*   oAuth
*   Bearer Authentication

## Tecnologias e versões utilizadas
*   C# 11 e .NET 7

## Projeto do curso
*   Uma solução em Minimal APIs com criação de usuário e autenticação utilizando JWT Bearer
 
## Updates realizados após a conclusão do Curso
*   Unificação de IRepository, IService
*   Unificação de Repository, Service
*   Service alterado de SendGrid para Brevo
*   Adicionado Swagger UI
*   Métodos PUT (email, nome e senha) e GET (Details) só aceitam solicitações do usuário do Token

## Funcionalidades adicionadas após a conclusão do Curso
*  Altera Email
*  Altera Nome
*  Altera Senha
*  Lista Detalhes do Usuário
*  Reset de Senha
*  Envio de Código de Reset de Senha
*  Reenvio de Código de Verificação
*  Ativação de Usuário com Código de Verificação

## Passos para utilização
* Atualização do AppSettings: ConnectionStrings, Secrets, Brevo, Email
* Dentro do projeto JwtStore.Api:
```
  dotnet ef database update
```
* Criação de Roles no Database
```
  INSERT INTO [Role]
  VALUES(NEWID(), 'Usuario'), (NEWID(), 'Admin')
```
