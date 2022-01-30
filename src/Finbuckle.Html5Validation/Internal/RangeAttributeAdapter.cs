// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

// Portions of this file are derived from ASP.NET Core and are subject to the following:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Finbuckle.Html5Validation.Internal;

public class RangeAttributeAdapter : AttributeAdapterBase<RangeAttribute>
{
    private readonly string _max;
    private readonly string _min;

    public RangeAttributeAdapter(RangeAttribute attribute, IStringLocalizer? stringLocalizer)
        : base(attribute, stringLocalizer)
    {
        // This will trigger the conversion of Attribute.Minimum and Attribute.Maximum.
        // This is needed, because the attribute is stateful and will convert from a string like
        // "100m" to the decimal value 100.
        //
        // Validate a randomly selected number.
        attribute.IsValid(3);

        _max = Convert.ToString(Attribute.Maximum, CultureInfo.InvariantCulture)!;
        _min = Convert.ToString(Attribute.Minimum, CultureInfo.InvariantCulture)!;
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        
        MergeAttribute(context.Attributes, "max", _max);
        MergeAttribute(context.Attributes, "min", _min);
    }

    /// <inheritdoc />
    public override string GetErrorMessage(ModelValidationContextBase validationContext)
    {
        if (validationContext == null)
        {
            throw new ArgumentNullException(nameof(validationContext));
        }

        return GetErrorMessage(
            validationContext.ModelMetadata,
            validationContext.ModelMetadata.GetDisplayName(),
            Attribute.Minimum,
            Attribute.Maximum);
    }
}