# Finbuckle.Html5Validation

1. [Introduction](#introduction)
2. [What's New in v<span class="_version">10.0.0</span>](#whats-new)
3. [Installation](#installation)
4. [Supported Data Annotations](#supported-data-annotations)
5. [FAQ](#faq)
6. [License](#license)

## Introduction
Client side form validation in ASP.NET Core stinks.

Specifically, tag helpers and `HTMLHelper` methods
generate [non-standard validation attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-10.0#client-side-validation)
and require the use of the `jquery.validate` and `jquery.validate.unobtrusive` libraries.

This library overrides this behavior to generate standard HTML5 validation attributes.

## <a name="whats-new"></a> What's New in v<span class="_version">10.0.0</span>

> This section only lists release update details specific to v<span class="_version">10.0.0</span>. See
> the [changelog file](CHANGELOG.md) for all release update details.
<!--_release-notes-->

### ⚠ BREAKING CHANGES

* The library now targets net10.0 only. .NET 8 and .NET 9
are no longer supported.

### Features

* Add title attribute containing error message to validated inputs ([#3](https://github.com/Finbuckle/Finbuckle.Html5Validation/issues/3)) ([b285611](https://github.com/Finbuckle/Finbuckle.Html5Validation/commit/b2856113be523d196a7b849cd7b3e86a949ea7d6))
* drop .NET 8 and .NET 9 support, target .NET 10 only ([#9](https://github.com/Finbuckle/Finbuckle.Html5Validation/issues/9)) ([14580d1](https://github.com/Finbuckle/Finbuckle.Html5Validation/commit/14580d1f95aa878502b9d5474a201e64b953099c))
* Update to .NET 10 ([13d0ce8](https://github.com/Finbuckle/Finbuckle.Html5Validation/commit/13d0ce8248f8675b1ea696a0f46963b88dd7234c))
<!--_release-notes-->

## Installation

1. Add the `Finbuckle.Html5Validation` NuGet package to your project.

2. Add the `Html5Validation` service to your app:
```csharp
using Finbuckle.Html5Validation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHtml5Validation();

// Rest of app code omitted.
```

## Supported Data Annotations

The following data annotations are supported:

| Attribute                    | ASP.NET Core                                                                                                                                                                                                                        | Finbuckle.Html5Validation                                              |
|------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------|
| `[Required]`                 | - `data-val=true`<br> - `data-val-required="{message}"`                                                                                                                                                                             | - `required`<br> - `title="{message}"` †                               |
| `[MinLength]`                | - `minlength="{min}"`<br> - `data-val=true`<br> - `data-val-minlength="{message}"` <br>- `data-val-maxlength-min="{min}"`                                                                                                           | - `minlength="{min}"`<br> - `title="{message}"` †                      |
| `[MaxLength]`                | - `maxlength="{max}"`<br> - `data-val=true`<br> - `data-val-maxlength="{message}"` <br>- `data-val-maxlength-max="{max}"`                                                                                                           | - `maxlength="{max}"`<br> - `title="{message}"` †                      |
| `[StringLength]`             | - `minlength="{min}"`<br> - `maxlength="{max}"`<br> - `data-val=true`<br> - `data-val-maxlength="{message}"` <br>- `data-val-maxlength-max="{max}"` <br> - `data-val-minlength="{message}"` <br> - `data-val-maxlength-min="{min}"` | - `minlength="{min}"`<br> - `maxlength="{max}"`<br> - `title="{message}"` † |
| `[Range]`                    | - `data-val=true`<br> - `data-val-range="{message}"`<br> - `data-val-range-min="{min}"` <br>- `data-val-range-max="{max}"`                                                                                                          | - `min="{min}"`<br> - `max="{max}"`<br> - `title="{message}"` †        |
| `[RegularExpression]`        | - `data-val=true`<br> - `data-val-regex="{message}"`<br> - `data-val-regex-pattern="{regex}"`                                                                                                                                       | - `pattern="{regex}"`<br> - `title="{message}"` †                      |
| `[DataType(DataType.{type}]` | - `type="{type}"`<br> - `data-val=true`<br> - `data-val-{type}="{message}"`                                                                                                                                                         | - `type="{type}"`<br> - `title="{message}"` †                          |
| `[EmailAddress]`             | - `type="email"`<br> - `data-val=true`<br> - `data-val-email="{message}"`                                                                                                                                                           | - `type="email"`<br> - `title="{message}"` †                           |
| `[Phone]`                    | - `type="tel"`<br> - `data-val=true`<br> - `data-val-phone="{message}"`                                                                                                                                                             | - `type="tel"`<br> - `title="{message}"` †                             |
| `[Url]`                      | - `type="url"`<br> - `data-val=true`<br> - `data-val-url="{message}"`                                                                                                                                                               | - `type="url"`<br> - `title="{message}"` †                             |

> Note that `[DataType(DataType.{type})]` only supports simple types such as email, phone, and url.

> † The `title` attribute is only added when a custom `ErrorMessage` or `ErrorMessageResourceName` is explicitly set on the annotation, e.g. `[Required(ErrorMessage = "This field is required.")]`. Browsers display the `title` value as a tooltip on the input and in the built-in validation popover, giving users a clear, customized error message.

## Installation

1. Add the `Finbuckle.Html5Validation` NuGet package to your project.

2. In your app configuration add the `Html5Validation` service:
```csharp
using Finbuckle.Html5Validation;

var builder = WebApplication.CreateBuilder(args);

// ... Add normal services.

// Add Finbuclke.Html5Validation.
builder.Services.AddHtml5Validation();

// ... rest of file omitted.
```
## FAQ

- **Why not just use the `jquery.validate` and `jquery.validate.unobtrusive` libraries?**

  *These libraries are not standard HTML5 validation attributes and require additional JavaScript libraries to work. 
  This library generates standard HTML5 validation attributes that work out of the box with modern browsers.*


- **Does it have any imapct on server side validation?**

  *No, this library only affects client-side validation.*


- **Does this library work with Blazor?**

  *No, this library only works with ASP.NET Core MVC Razor Pages and MVC apps that use tag helpers and `HTMLHelper` 
  form input methods.*

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit). See [LICENSE](LICENSE) file for
license information.
