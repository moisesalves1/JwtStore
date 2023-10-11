using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects.Exceptions;
using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.GetUsers
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
            => _repository = repository;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {

            #region 02. Recupera o perfil

            List<User>? users;
            try
            {
                users = await _repository.GetAllUsersAsync(cancellationToken);
                if (users is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception e)
            {
                return new Response("Não foi possível recuperar seu perfil", 500);
            }

            #endregion

            List<ResponseData> allUsers = new();
            users.ForEach(user => {
                var usr = new ResponseData
                {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Email = user.Email,
                    VerifiedAt = user.Email.Verification.VerifiedAt,
                    Image = user.Image,
                    Roles = user.Roles.Select(x => x.Name).ToArray()
                };
                allUsers.Add(usr);
            });


            #region 05. Retorna os dados

            return new Response("", allUsers);

            #endregion
        }
    }
}
