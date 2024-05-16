using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Uplay.Application.Extensions;

public static class Validator
{
    [Obsolete("Obsolete")]
    public static IMvcBuilder AddFluentValidationCustom(this IMvcBuilder builder)
    {
        builder
            .AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;

                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

        return builder;
    }
}
