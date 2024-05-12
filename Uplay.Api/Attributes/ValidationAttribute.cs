using Microsoft.AspNetCore.Mvc.Filters;
using Uplay.Application.Exceptions;

namespace Uplay.Api.Attributes
{
    public class ValidationAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var exception = new ValidationException();
                var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                foreach (var error in errorsInModelState)
                {
                    exception.Errors.Add(error.Key, error.Value.ToArray());
                }

                throw exception;
            }
            else
            {
                await next();
            }
        }
    }
}
