# GetVSTSBuildUsage

This is a code sample that shows how to get information about builds run under a Visual Studio Team Services (VSTS) account or TFS collection.

## Legacy platform context

This repository contains a legacy C# console application:

- Solution: `GetVSTSBuildUsage.sln`
- Application project: `GetVSTSBuildUsage/GetVSTSBuildUsage.csproj`
- Target framework: .NET Framework 4.5.2
- Package management: `packages.config`

The project is intentionally kept on its original .NET Framework and VSTS/TFS client libraries. The build and test workflows validate compilation and deterministic unit tests; they do not prove runtime compatibility with every supported VSTS/TFS server or account configuration.

## Prerequisites

Use a Windows environment with:

- Visual Studio or Build Tools with MSBuild for .NET Framework projects.
- NuGet CLI.
- .NET Framework 4.5.2 targeting support.
- Visual Studio Test Platform when running tests locally.

## Restore and build

Restore packages:

```powershell
nuget restore GetVSTSBuildUsage.sln -NonInteractive
```

Build the solution:

```powershell
msbuild GetVSTSBuildUsage.sln /m /p:Configuration=Release /p:Platform="Any CPU"
```

## Run tests

The test project is `GetVSTSBuildUsage.Tests/GetVSTSBuildUsage.Tests.csproj` and uses MSTest. The tests cover command-line argument validation and date clamping behavior without using live VSTS/TFS credentials, network access, or external services.

After restore and build, run:

```powershell
vstest.console.exe GetVSTSBuildUsage.Tests\bin\Release\GetVSTSBuildUsage.Tests.dll /TestAdapterPath:packages\MSTest.TestAdapter.2.2.10\build\_common
```

## Command-line usage

```text
GetVSTSBuildUsage [account url and collection] [min build finish date] [max build finish date]
```

Example:

```text
GetVSTSBuildUsage http://myaccount.visualstudio.com/DefaultCollection 1/1/2016 1/31/2016
```

The first argument is the VSTS account or TFS collection URL. The second and third arguments define the minimum and maximum build finish dates.

## Authentication and configuration

The application uses the legacy Visual Studio Services client libraries and interactive Azure Active Directory credentials. You must have permission to read projects and build information in the target VSTS/TFS account or collection.

Do not commit real credentials, personal access tokens, service-bus connection strings, or account-specific secrets. Use local-only configuration or secure secret storage for any sensitive values.

## CI, Dependabot, and CodeQL

Repository automation is defined in:

- `.github/workflows/build.yml` for Windows restore, build, and tests.
- `.github/workflows/codeql.yml` for C# CodeQL analysis.
- `.github/dependabot.yml` for NuGet and GitHub Actions update checks.

These files add repository automation but do not enable repository settings such as branch protection, secret scanning, push protection, Dependabot alerts, or CodeQL availability.

## Troubleshooting

- If restore fails, confirm NuGet CLI can reach nuget.org and that `packages.config` is intact.
- If build fails with missing .NET Framework targeting packs, install .NET Framework 4.5.2 developer/targeting support or use a compatible Windows build environment.
- If tests are not discovered, confirm `MSTest.TestAdapter` packages were restored and pass the adapter path shown above to `vstest.console.exe`.
- If authentication fails at runtime, verify the account URL, current signed-in identity, and permissions for the VSTS/TFS collection.

## Contributing and security

See `CONTRIBUTING.md` for development guidance and `SECURITY.md` for vulnerability reporting and secret-handling expectations.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
