# Description

<!-- Summarize the change and the problem it solves. -->

Related issue: <!-- e.g. Closes #123 -->

## Type of change

- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Build, CI, or repository maintenance

## Validation

<!-- Include the results of the commands you ran. -->

- [ ] `nuget restore GetVSTSBuildUsage.sln -NonInteractive`
- [ ] `msbuild GetVSTSBuildUsage.sln /m /p:Configuration=Release /p:Platform="Any CPU"`
- [ ] Tests run with Visual Studio Test Platform against `GetVSTSBuildUsage.Tests\bin\Release\GetVSTSBuildUsage.Tests.dll`

## Checklist

- [ ] The change is focused and limited to the stated scope.
- [ ] Tests were added or updated, and they remain deterministic (no live VSTS/TFS credentials, network access, or external services).
- [ ] Documentation was updated where behavior, setup, or supported commands changed.
- [ ] No credentials, access tokens, connection strings, or other secrets are included.
- [ ] The project still targets .NET Framework 4.5.2 unless modernization was explicitly requested.
