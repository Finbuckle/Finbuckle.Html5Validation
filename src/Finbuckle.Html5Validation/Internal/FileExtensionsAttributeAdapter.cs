// // Copyright Finbuckle LLC, Andrew White, and Contributors.
// // Refer to the solution LICENSE file for more inforation.
//
// // Portions of this file are derived from ASP.NET Core and are subject to the following:
// // Licensed to the .NET Foundation under one or more agreements.
// // The .NET Foundation licenses this file to you under the MIT license.
//
// using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Mvc.DataAnnotations;
// using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
// using Microsoft.Extensions.Localization;
//
// namespace Finbuckle.VanillaValidation.Adapters;
//
// public class FileExtensionsAttributeAdapter : AttributeAdapterBase<FileExtensionsAttribute>
// {
//     public FileExtensionsAttributeAdapter(FileExtensionsAttribute attribute, IStringLocalizer? stringLocalizer)
//         : base(attribute, stringLocalizer)
//     {
//         // TODO
//     }
//
//     /// <inheritdoc />
//     public override void AddValidation(ClientModelValidationContext context)
//     {
//         if (context == null)
//         {
//             throw new ArgumentNullException(nameof(context));
//         }
//
//         // TODO 
//     }
//
//     /// <inheritdoc />
//     public override string GetErrorMessage(ModelValidationContextBase validationContext)
//     {
//         if (validationContext == null)
//         {
//             throw new ArgumentNullException(nameof(validationContext));
//         }
//
//         return GetErrorMessage(
//             validationContext.ModelMetadata,
//             validationContext.ModelMetadata.GetDisplayName());
//     }
// }