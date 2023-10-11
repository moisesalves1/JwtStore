using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.AccountContext.ValueObjects.Exceptions;
using MediatR;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.DeleteUser
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
            => _repository = repository;

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
                user = await _repository.GetUserByIdAsync(request.Id, cancellationToken);
                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
            }

            #endregion

            #region 03. Delete o perfil
            try
            {
                await _repository.DeleteUserAsync(user, cancellationToken);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível deletar o perfil", 500);
            }

            #endregion



            #region 05. Retorna os dados

            return new Response("Usuário deletado com sucesso", new ResponseData(user.Id, user.Name, user.Email));

            #endregion
        }
    }
}
