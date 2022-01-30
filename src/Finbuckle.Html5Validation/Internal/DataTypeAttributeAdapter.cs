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
/// A validation adapter that is used to map <see cref="DataTypeAttribute"/>'s to a single client side validation
/// rule.
/// </summary>
public class DataTypeAttributeAdapter : AttributeAdapterBase<DataTypeAttribute>
{
    public DataTypeAttributeAdapter(DataTypeAttribute attribute, IStringLocalizer? stringLocalizer)
        : base(attribute, stringLocalizer)
    {
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        
        // No need to add attributes -- type already present.
    }

    /// <inheritdoc/>
    public override string GetErrorMessage(ModelValidationContextBase validationContext)
    {
        if (validationContext == null)
        {
            throw new ArgumentNullException(nameof(validationContext));
        }

        return GetErrorMessage(
            validationContext.ModelMetadata,
            validationContext.ModelMetadata.GetDisplayName(),
            Attribute.GetDataTypeName());
    }
}