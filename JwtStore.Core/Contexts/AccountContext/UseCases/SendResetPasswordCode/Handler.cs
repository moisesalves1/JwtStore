using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;
using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode
{
    public class Handler :IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;
        private readonly IService _service;

        public Handler(IRepository repository, IService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            #region 01 - Valida a requisição

            try
            {
                var res = Specification.Ensure(request);
                if (!res.IsValid)
                    return new Response("Requisicação inválida", 400, res.Notifications);
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
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
            }

            #endregion

            #region 05 - Envia E-mail com código de redefinição de senha

            try
            {
                await _service.SendResetPasswordCodeAsync(user, cancellationToken);
            }
            catch (Exception e)
            {
                // Do nothing
            }

            #endregion


            #region 05. Retorna os dados

            return new Response("O código de redefinição de senha foi enviado", 201);

            #endregion
        }
    }
}
