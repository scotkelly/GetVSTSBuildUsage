# Contributing

Thank you for helping improve this VSTS/TFS build-usage sample.

## Development setup

This is a legacy .NET Framework solution. Use a Windows development environment with:

- Visual Studio or Build Tools with MSBuild for .NET Framework projects.
- NuGet CLI.
- .NET Framework 4.5.2 targeting support.

Restore packages before building:

```powershell
nuget restore GetVSTSBuildUsage.sln -NonInteractive
```

Build the solution:

```powershell
msbuild GetVSTSBuildUsage.sln /m /p:Configuration=Release /p:Platform="Any CPU"
```

## Tests

Unit tests live in `GetVSTSBuildUsage.Tests/` and use MSTest. Tests should cover deterministic behavior only. Do not require live VSTS/TFS credentials, network access, or external services in unit tests.

After restoring packages and building, run tests with Visual Studio Test Platform:

```powershell
vstest.console.exe GetVSTSBuildUsage.Tests\bin\Release\GetVSTSBuildUsage.Tests.dll /TestAdapterPath:packages\MSTest.TestAdapter.2.2.10\build\_common
```

## Branches and pull requests

- Create focused branches for each change.
- Keep pull requests small and limited to the stated scope.
- Include validation results in the pull request description.
- Update documentation when behavior, setup, or supported commands change.

## Security and credentials

Never commit credentials, access tokens, service-bus connection strings, or account-specific configuration. Use placeholders in documentation and local-only settings for development.
