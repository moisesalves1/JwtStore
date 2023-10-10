using JwtStore.Core.AccountContext.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace JwtStore.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Create

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Repository>();

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IService,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Service>();

            #endregion

            #region Authenticate

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Authenticate.Repository>();

            #endregion

            #region Verify

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Verify.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Verify.Repository>();

            #endregion

            #region ChangeName

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ChangeName.Repository>();

            #endregion

            #region ChangePassword

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ChangePassword.Repository>();

            #endregion

            #region ChangeEmail

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ChangeEmail.Repository>();

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail.Contracts.IService,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ChangeEmail.Service>();

            #endregion

            #region ResendVerificationCode

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ResendVerificationCode.Repository>();

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode.Contracts.IService,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ResendVerificationCode.Service>();

            #endregion

            #region SendResetPasswordCode

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.SendResetPasswordCode.Repository>();

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode.Contracts.IService,
                JwtStore.Infra.Contexts.AccountContext.UseCases.SendResetPasswordCode.Service>();

            #endregion

            #region ResetPassword

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.ResetPassword.Repository>();

            #endregion
        }

        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Create

            app.MapPost("api/v1/users", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.Create.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.Create.Response> handler) => 
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
                    : Results.Json(result, statusCode: result.Status);
            });

            #endregion


            #region Authenticate

            app.MapPost("api/v1/authenticate", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                return Results.Ok(result);
            });

            #endregion

            #region Verify

            app.MapPost("api/v1/verify", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.Verify.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.Verify.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.Verify.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            });



            #endregion

            #region ChangeName

            app.MapPost("api/v1/change-name", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName.Response> handler,
                    ClaimsPrincipal user) =>
            {
                request.JwtUserEmail = user?.Identity?.Name;
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            }).RequireAuthorization("Usuario");

            #endregion

            #region ChangePassword

            app.MapPost("api/v1/change-password", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword.Response> handler,
                    ClaimsPrincipal user) =>
            {
                request.JwtUserEmail = user?.Identity?.Name;
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            }).RequireAuthorization("Usuario");

            #endregion

            #region ChangeEmail

            app.MapPost("api/v1/change-email", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail.Response> handler,
                    ClaimsPrincipal user) =>
            {
                request.JwtUserEmail = user?.Identity?.Name;
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            }).RequireAuthorization("Usuario");

            #endregion

            #region ResendVerificationCode

            app.MapPost("api/v1/resend-verification-code", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            });

            #endregion

            #region SendResetPasswordCode

            app.MapPost("api/v1/send-reset-password-code", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            });

            #endregion

            #region ResetPassword

            app.MapPost("api/v1/reset-password", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                return Results.Ok(result);
            });

            #endregion

        }
    }
}
