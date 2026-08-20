# Security policy

## Reporting a vulnerability

If GitHub private vulnerability reporting is enabled for this repository, please use that flow to report security issues privately. If it is not available, contact the repository owner through GitHub rather than opening a public issue with sensitive details.

Please include:

- A clear description of the issue.
- Steps to reproduce or validate the concern.
- Any affected files, dependencies, or workflows.
- Whether credentials, tokens, or other secrets may be involved.

## Secret handling

Do not commit credentials, personal access tokens, service-bus connection strings, API keys, or other secrets. Use placeholders in examples and keep real values in local developer configuration or secure secret stores.

If a secret is accidentally committed, rotate or revoke it immediately and remove it from the repository history according to the repository owner's guidance.

## Supported security scope

This project is a legacy .NET Framework 4.5.2 sample for VSTS/TFS build usage. Security fixes should avoid broad modernization unless that work is explicitly planned.
