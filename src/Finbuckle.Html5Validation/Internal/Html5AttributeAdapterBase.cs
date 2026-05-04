// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Finbuckle.Html5Validation.Internal;

public abstract class Html5AttributeAdapterBase<TAttribute> : AttributeAdapterBase<TAttribute>
    where TAttribute : ValidationAttribute
{
    protected Html5AttributeAdapterBase(TAttribute attribute, IStringLocalizer? stringLocalizer)
        : base(attribute, stringLocalizer)
    {
    }

    protected void MergeErrorMessageTitle(ClientModelValidationContext context)
    {
        if (Attribute.ErrorMessage != null || Attribute.ErrorMessageResourceName != null)
        {
            MergeAttribute(context.Attributes, "title", GetErrorMessage(context));
        }
    }
}
