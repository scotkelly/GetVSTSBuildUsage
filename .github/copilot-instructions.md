# Copilot instructions

This repository contains a legacy C#/.NET Framework console sample for reporting Visual Studio Team Services (VSTS) or TFS build usage.

- Keep the application project on .NET Framework 4.5.2 unless a task explicitly requests modernization.
- Do not make broad behavioral changes in `GetVSTSBuildUsage/Program.cs` for repository-health work.
- Restore packages with `nuget restore GetVSTSBuildUsage.sln -NonInteractive`.
- Build with `msbuild GetVSTSBuildUsage.sln /m /p:Configuration=Release /p:Platform="Any CPU"`.
- Run tests with Visual Studio Test Platform against `GetVSTSBuildUsage.Tests/bin/Release/GetVSTSBuildUsage.Tests.dll`.
- Tests must be deterministic and must not require live VSTS/TFS credentials, network access, or external services.
- Never commit credentials, tokens, service-bus connection strings, personal access tokens, or other secrets.
- Validate workflow, project, solution, and documentation changes before opening a pull request.
