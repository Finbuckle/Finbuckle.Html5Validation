// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

// Portions of this file are derived from ASP.NET Core and are subject to the following:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace Finbuckle.Html5Validation.Internal;

/// <summary>
/// Creates an <see cref="IAttributeAdapter"/> for the given attribute.
/// </summary>
public class Html5ValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
{
    /// <summary>
    /// Creates an <see cref="IAttributeAdapter"/> for the given attribute.
    /// </summary>
    /// <param name="attribute">The attribute to create an adapter for.</param>
    /// <param name="stringLocalizer">The localizer to provide to the adapter.</param>
    /// <returns>An <see cref="IAttributeAdapter"/> for the given attribute.</returns>
    public IAttributeAdapter? GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer? stringLocalizer)
    {
        if (attribute == null)
        {
            throw new ArgumentNullException(nameof(attribute));
        }

        var type = attribute.GetType();

        if (typeof(RegularExpressionAttribute).IsAssignableFrom(type))
        {
            return new RegularExpressionAttributeAdapter((RegularExpressionAttribute)attribute, stringLocalizer);
        }
        else if (typeof(MaxLengthAttribute).IsAssignableFrom(type))
        {
            return new MaxLengthAttributeAdapter((MaxLengthAttribute)attribute, stringLocalizer);
        }
        else if (typeof(RequiredAttribute).IsAssignableFrom(type))
        {
            return new RequiredAttributeAdapter((RequiredAttribute)attribute, stringLocalizer);
        }
        else if (typeof(MinLengthAttribute).IsAssignableFrom(type))
        {
            return new MinLengthAttributeAdapter((MinLengthAttribute)attribute, stringLocalizer);
        }
        else if (typeof(StringLengthAttribute).IsAssignableFrom(type))
        {
            return new StringLengthAttributeAdapter((StringLengthAttribute)attribute, stringLocalizer);
        }
        else if (typeof(RangeAttribute).IsAssignableFrom(type))
        {
            return new RangeAttributeAdapter((RangeAttribute)attribute, stringLocalizer);
        }
        else if (typeof(DataTypeAttribute).IsAssignableFrom(type))
        {
            return new DataTypeAttributeAdapter((DataTypeAttribute)attribute, stringLocalizer);
        }
        else
        {
            return null;
        }
    }
};