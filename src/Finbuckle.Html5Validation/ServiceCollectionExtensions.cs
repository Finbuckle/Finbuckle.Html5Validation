// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

using Finbuckle.Html5Validation.Internal;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Finbuckle.Html5Validation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHtml5Validation(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IValidationAttributeAdapterProvider, Html5ValidationAttributeAdapterProvider>();
    }
}