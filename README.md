# Finbuckle.Html5Validation

1. [Introduction](#introduction)
2. [Supported Data Annotations](#supported-data-annotations)
3. [Installation](#installation)
4. [License](#license)

## Introduction
Client form validation in ASP.NET Core sucks.

Specifically, tag helpers and `HTMLHelper` methods
generate [non-standard validation attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-8.0#client-side-validation)
and require the use of the `jquery.validate` and `jquery.validate.unobtrusive` libraries.

This library overrides this behavior to generate standard HTML5 validation attributes.

> If you like this library, check out our main
> project [Finbuckle.MultiTenant](https://github.com/Finbuckle/Finbuckle.MultiTenant) and consider becoming a sponsor.

## Supported Data Annotations

The following data annotations are supported:

| Attribute                    | ASP.NET Core                                                                                                                                                                                              | Finbuckle.Html5Validation                       |
|------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------|
| `[Required]`                 | - `data-val=true`<br> - `data-val-required="{message}"`                                                                                                                                                   | - `required`                                    |
| `[MinLength]`                | - `minlength="{min}"`<br> - `data-val=true`<br> - `data-val-minlength="{message}"` <br>- `data-val-maxlength-min="{min}"`                                                                                 | - `minlength="{min}"`                           | 
| `[MaxLength]`                | - `maxlength="{max}"`<br> - `data-val=true`<br> - `data-val-maxlength="{message}"` <br>- `data-val-maxlength-max="{max}"`                                                                                 | - `maxlength="{max}"`                           |                                                                          |
| `[StringLength]`             | - `maxlength="{max}"`<br> - `data-val=true`<br> - `data-val-maxlength="{message}"` <br>- `data-val-maxlength-max="{max}"` <br> - `data-val-minlength="{message}"` <br> - `data-val-maxlength-min="{min}"` | - `minlength="{min}"`<br> - `maxlength="{max}"` |
| `[Range]`                    | - `data-val=true`<br> - `data-val-range="{message}"`<br> - `data-val-range-min="{min}"` <br>- `data-val-range-max="{max}"`                                                                                | - `min="{min}"`<br> - `max="{max}"`             |
| `[RegularExpression]`        | - `data-val=true`<br> - `data-val-regex="{message}"`<br> - `data-val-regex-pattern="{regex}"`                                                                                                             | - `pattern="{regex}"`                           |
| `[DataType(DataType.{type}]` | - `type="{type}"`<br> - `data-val-{type}="{message}"`                                                                                                                                                     | - `type="{type}"`                               |
| `[EmailAddress]`             | - `type="email"`<br> - `data-val-email="{message}"`                                                                                                                                                       | - `type="email"`                                |
| `[Phone]`                    | - `type="tel"`<br> - `data-val-phone="{message}"`                                                                                                                                                         | - `type="tel"`                                  |
| `[Url]`                      | - `type="url"`<br> - `data-val-url="{message}"`                                                                                                                                                           | - `type="url"`                                  |

> Note that `[DataType(DataType.{type})]` only supports simple types such as email, phone, and url.`

## Installation

1. Add the `Finbuckle.Html5Validation` NuGet package to your project.

```bash
2. In your app service configuration 
```csharp
using Finbuckle.Html5Validation;

var builder = WebApplication.CreateBuilder(args);

// ... Add normal services.

// Add Finbuclke.Html5Validation.
builder.Services.AddHtml5Validation();

// ... rest of file omitted.
```

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit). See [LICENSE](LICENSE) file for
license information.