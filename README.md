# Multi-Project Dependency Security Playbook Sample

This is a **sample repository scaffold** designed to exercise a Devin dependency-security Playbook. It models a repository containing:

- 1 Angular WebUI
- 1 Gateway API (.NET 8)
- 5 Module APIs (Module1 on .NET 10, Module2-5 on .NET 8)
- 3 legacy ASP.NET Web API projects (.NET Framework 4.8)
- 2 WinForms projects (.NET Framework 4.8)
- 1 shared .NET 8 class library

The Angular app is intentionally not included in the Visual Studio solution, to demonstrate why the Playbook must scan the entire repository rather than only `.sln` projects.

## Repository layout

```text
DependencySecurityPlaybookSample/
├── DependencySecurityPlaybookSample.sln
├── src/
│   ├── WebUI/                         # Angular/npm, not in the .sln
│   ├── Gateway.Api/                   # .NET 8
│   ├── Shared.Contracts/              # .NET 8 class library
│   ├── Modules/
│   │   ├── Module1.Api/                # .NET 10
│   │   ├── Module2.Api/
│   │   ├── Module3.Api/
│   │   ├── Module4.Api/
│   │   └── Module5.Api/
│   ├── Legacy/
│   │   ├── LegacyWebApi1/              # .NET Framework 4.8
│   │   ├── LegacyWebApi2/
│   │   └── LegacyWebApi3/
│   └── Desktop/
│       ├── WinFormsApp1/               # .NET Framework 4.8
│       └── WinFormsApp2/
├── playbook/
│   ├── MASTER-PLAYBOOK.md
│   ├── PROJECT-INVENTORY.md
│   └── REPORT-TEMPLATE.md
└── fixtures/
    └── audit-only/                     # Non-buildable illustrative audit fixtures
```

## Requirements

- Visual Studio 2022 with the .NET 8 SDK, plus the .NET 10 SDK (Visual Studio 2026) for `Module1.Api` and its tests.
- On Windows, install the .NET Framework 4.8 Developer/Targeting Pack and ASP.NET workload to build legacy projects.
- Node.js and npm for the Angular project.
- Legacy .NET Framework projects may need package restore and adjustments for your installed Visual Studio/MSBuild environment.

## Try the sample

### 1. Inspect the repository
Open `DependencySecurityPlaybookSample.sln` in Visual Studio. Notice that the Angular app is not part of the solution.

### 2. Build modern .NET projects
From the repository root:

```bash
dotnet restore DependencySecurityPlaybookSample.sln
dotnet build DependencySecurityPlaybookSample.sln --no-restore
```

This may fail on non-Windows environments because the solution also contains .NET Framework 4.8 projects. Build individual modern projects if needed:

```bash
dotnet build src/Gateway.Api/Gateway.Api.csproj
dotnet build src/Modules/Module1.Api/Module1.Api.csproj
```

### 3. Scan NuGet dependencies
Use the command supported by your installed SDK:

```bash
dotnet list src/Gateway.Api/Gateway.Api.csproj package --vulnerable --include-transitive
```

Repeat for all discovered .NET projects. Newer SDKs also support `dotnet package list`; check `dotnet package list --help` for your installed SDK.

For legacy projects, inspect both `PackageReference` and `packages.config`, then use compatible NuGet tooling.

### 4. Scan the Angular app

```bash
cd src/WebUI
npm install
npm audit
```

`npm install` can update the lockfile if it is absent or inconsistent. In a real project, prefer the existing committed lockfile and `npm ci` in CI.

### 5. Apply the Playbook
Use `playbook/MASTER-PLAYBOOK.md` as the starting instructions for a Devin Playbook. The fixture files under `fixtures/audit-only` are illustrative audit inputs only; they are not referenced by the solution and must never be installed or built.

## Important notes

- This is a teaching scaffold, not production-ready application code.
- Dependency versions change over time. Run current scanners against current advisory data; do not assume a package is safe merely because it appears in this sample.
- The `fixtures/audit-only` files deliberately demonstrate how to keep test fixtures separate from buildable application projects. They may produce current scanner findings, no findings, or tool-specific warnings.
- Do not use `npm audit fix --force` or major-version upgrades automatically.
- The legacy projects are intentionally minimal. They demonstrate inventory and tooling differences, not a full production deployment setup.
