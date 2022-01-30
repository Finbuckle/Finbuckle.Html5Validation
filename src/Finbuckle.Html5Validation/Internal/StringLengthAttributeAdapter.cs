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

public class StringLengthAttributeAdapter : AttributeAdapterBase<StringLengthAttribute>
{
    private readonly string _max;
    private readonly string _min;

    public StringLengthAttributeAdapter(StringLengthAttribute attribute, IStringLocalizer? stringLocalizer)
        : base(attribute, stringLocalizer)
    {
        _max = Attribute.MaximumLength.ToString(CultureInfo.InvariantCulture);
        _min = Attribute.MinimumLength.ToString(CultureInfo.InvariantCulture);
    }

    /// <inheritdoc />
    public override void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }


        if (Attribute.MaximumLength != int.MaxValue)
        {
            MergeAttribute(context.Attributes, "maxlength", _max);
        }

        if (Attribute.MinimumLength != 0)
        {
            MergeAttribute(context.Attributes, "minlength", _min);
        }
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
            Attribute.MaximumLength,
            Attribute.MinimumLength);
    }
}