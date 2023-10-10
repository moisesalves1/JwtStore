﻿using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail
{

    public class Request : IRequest<Response>
    {
        public string ActualEmail { get; init; }
        public string NewEmail { get; init; }
        public string JwtUserEmail { get; set; }
    }
}
