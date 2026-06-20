# Finbuckle.Html5Validation

## Introduction
Client side form validation in ASP.NET Core stinks.

Specifically, tag helpers and `HTMLHelper` methods
generate [non-standard validation attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-10.0#client-side-validation)
and require the use of the `jquery.validate` and `jquery.validate.unobtrusive` libraries.

This library overrides this behavior to generate standard HTML5 validation attributes.

## Documentation
See the [documentation](https://github.com/Finbuckle/Finbuckle.Html5Validation/) for usage instructions and examples.

## Changes

See the [changelog](CHANGELOG.md) for a list of all release updates.

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit). See [LICENSE](LICENSE) file for
license information.
