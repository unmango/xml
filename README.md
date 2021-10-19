# UnMango XML

[![GitHub release (latest by date)](https://img.shields.io/github/v/release/unmango/xml?include_prereleases)](https://github.com/unmango/xml/releases/latest)
[![Codecov](https://img.shields.io/codecov/c/github/unmango/xml)](https://app.codecov.io/gh/unmango/xml)
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/unmango/xml/NuGet%20Publish)](https://github.com/unmango/xml/actions/workflows/nuget_publish.yml)
[![Libraries.io dependency status for GitHub repo](https://img.shields.io/librariesio/github/unmango/xml)](https://libraries.io/github/unmango/xml)

Just another XML serializer.

I'm primarily using this to practice writing a serializer using lower-level C# APIs.

This API is loosely modeled after [`System.Text.Json`](https://github.com/dotnet/runtime/tree/main/src/libraries/System.Text.Json) and [`Utf8Json`](https://github.com/neuecc/Utf8Json/).

## Conventions

High-level rules I try to follow.

### Reader

- All operations validate the current offset **
- Validation failures throw `XmlParsingException`s **
- `Try*` methods do not increment the offset
- `Try*` methods follow the .NET convention of returning a bool and accepting an `out` param

** I may re-visit the validation strategy

## Development

### Lint Hooks

The easiest way to setup dotnet format to run on commit is to run `git config core.hooksPath .githooks`.

## References

[W3C Extensible Markup Language (XML) 1.0 (Fifth Edition)](https://www.w3.org/TR/2008/REC-xml-20081126/)

For Reference: [W3C Canonical XML Version 2.0](https://www.w3.org/TR/2013/NOTE-xml-c14n2-20130411/)

## License

GNU General Public License v3.0 or later

See [COPYING](COPYING) to see the full text.
