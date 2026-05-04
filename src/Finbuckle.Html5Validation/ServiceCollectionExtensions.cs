// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

using Finbuckle.Html5Validation.Internal;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Finbuckle.Html5Validation;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to add HTML5 validation support.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds HTML5 client-side validation support to the application by registering the
    /// <see cref="IValidationAttributeAdapterProvider"/> service.
    /// </summary>
    /// <param name="serviceCollection">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddHtml5Validation(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IValidationAttributeAdapterProvider, Html5ValidationAttributeAdapterProvider>();
    }
}