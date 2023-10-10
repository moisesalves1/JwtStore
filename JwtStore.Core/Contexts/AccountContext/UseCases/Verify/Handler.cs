using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects.Exceptions;
using JwtStore.Core.Contexts.AccountContext.UseCases.Verify.Contracts;
using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Verify
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




            #region 03. Checa se a conta está verificada

            try
            {
                user.Email.Verification.Verify(request.VerificationCode);

                if (!user.Email.Verification.IsActive)
                    return new Response("Não foi possível ativar sua conta", 400);

                if(user.Email.Verification.ExpiresAt.Value < DateTime.UtcNow)
                    return new Response("Código de ativação expirado", 400);

            }
            catch (InvalidVerificationException e)
            {
                return new Response(e.Message, 500);
            }
            catch
            {
                return new Response("Não foi possível verificar seu perfil", 500);
            }

            #endregion

            #region 04 - Persistir os dados

            try
            {
                await _repository.UpdateAsync(user, cancellationToken);
            }
            catch (Exception e)
            {
                return new Response("Falha ao persistir dados", 500);
            }

            #endregion


            #region 05. Retorna os dados

            return new Response("Conta ativada com sucesso", 201);

            #endregion
        }
    }
}
