﻿using JwtStore.Core.AccountContext.Entities;
using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ResetToken
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
            => _repository = repository;
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken) 
        {
            #region 01. Valida a requisição

            try
            {
                var res = Specification.Ensure(request);
                if (!res.IsValid)
                    return new Response("Requisição inválida", 400, res.Notifications);
            }
            catch
            {
                return new Response("Não foi possível validar sua requisição", 500);
            }

            #endregion

            #region 02. Recupera o perfil

            User? user;
            try
            {
                user = await _repository.GetUserByEmailAsync(request.JwtUserEmail, cancellationToken);
                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
            }

            #endregion

            #region 04. Checa se a conta está verificada

            try
            {
                if (!user.Email.Verification.IsActive)
                    return new Response("Conta inativa", 400);
            }
            catch
            {
                return new Response("Não foi possível verificar seu perfil", 500);
            }

            #endregion


            #region 05. Retorna os dados

            try
            {
                var data = new ResponseData
                {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Email = user.Email,
                    Roles = user.Roles.Select(x =>x.Name).ToArray()
                };

                return new Response(string.Empty, data);
            }
            catch
            {
                return new Response("Não foi possível obter os dados do perfil", 500);
            }

            #endregion
        }
    }
}
