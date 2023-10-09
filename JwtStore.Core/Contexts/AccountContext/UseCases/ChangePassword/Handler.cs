using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword.Contracts;
using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword
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
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
            }

            #endregion



            #region 03 - Verifica se a senha atual está correta

            if (!user.Password.Challenge(request.ActualPassword))
            {
                return new Response("Senha atual inválida", 400);
            }

            #endregion

            #region 04 - Altera a senha do usuário

            try
            {
               user.UpdatePassword(request.NewPassword);
            }
            catch (Exception e)
            {
                return new Response("Falha ao alterar nome", 500);
            }

            #endregion


            #region 05 - Persistir os dados

            try
            {
                await _repository.UpdateAsync(user, cancellationToken);
            }
            catch (Exception e)
            {
                return new Response("Falha ao persistir dados", 500);
            }

            #endregion


            #region 06. Retorna os dados

            return new Response("Senha alterada com sucesso", 201);

            #endregion
        }
    }
}
