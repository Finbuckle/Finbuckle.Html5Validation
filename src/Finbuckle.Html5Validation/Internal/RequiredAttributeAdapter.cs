// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

// Portions of this file are derived from ASP.NET Core and are subject to the following:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Finbuckle.Html5Validation.Internal;

/// <summary>
/// <see cref="AttributeAdapterBase{TAttribute}"/> for <see cref="RequiredAttribute"/>.
/// </summary>
public class RequiredAttributeAdapter : AttributeAdapterBase<RequiredAttribute>
{
    /// <summary>
    /// Initializes a new instance of <see cref="RequiredAttributeAdapter"/>.
    /// </summary>
    /// <param name="attribute">The <see cref="RequiredAttribute"/>.</param>
    /// <param name="stringLocalizer">The <see cref="IStringLocalizer"/>.</param>
    public RequiredAttributeAdapter(RequiredAttribute attribute, IStringLocalizer? stringLocalizer)
        : base(attribute, stringLocalizer)
    {
    }

    /// <inheritdoc />
    public override void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        MergeAttribute(context.Attributes, "required", "");
    }

    /// <inheritdoc />
    public override string GetErrorMessage(ModelValidationContextBase validationContext)
    {
        if (validationContext == null)
        {
            throw new ArgumentNullException(nameof(validationContext));
        }

        return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
    }
}
