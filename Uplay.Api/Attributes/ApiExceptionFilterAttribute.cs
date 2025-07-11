﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Uplay.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Uplay.Application.Exceptions;

namespace Uplay.Api.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly AppDbContext db;
        private IDbContextTransaction Transaction => db.Database.CurrentTransaction;
        public ApiExceptionFilterAttribute(AppDbContext db)
        {
            this.db = db;

            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                {typeof(ValidationException), HandleValidationException},
                {typeof(NotFoundException), HandleNotFoundException},
                {typeof(UnauthorizedException), HandleUnauthorizedException},
                {typeof(BadHttpRequestException), HandleBadHttpRequestException}

            };
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            HandleException(context);

            if (Transaction is not null)
                await db.Database.RollbackTransactionAsync();

            await base.OnExceptionAsync(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;
            var details = new ValidationProblemDetails(exception?.Errors);
            context.ExceptionHandled = true;
            context.Result = new UnprocessableEntityObjectResult(details);
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var details = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = context.Exception.Message
            };

            context.ExceptionHandled = true;
            context.Result = new NotFoundObjectResult(details);
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState);

            context.ExceptionHandled = true;
            context.Result = new BadRequestObjectResult(details);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Əməliyyat zamanı xəta baş verdi."
            };

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(details);
        }

        private void HandleUnauthorizedException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = context.Exception.Message
            };

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(details);
        }

        private void HandleBadHttpRequestException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = context.Exception.Message
            };

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(details);
        }
    }

}
