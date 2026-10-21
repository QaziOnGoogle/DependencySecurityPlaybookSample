# Project inventory template

The Playbook should generate or refresh this inventory from repository files; do not rely on this static example as the source of truth.

| Project path | Project type | Target framework | Manifest(s) | Scanner / validation |
|---|---|---|---|---|
| `src/WebUI` | Angular frontend | Check `package.json` | `package.json`, npm lockfile | `npm audit`, frontend build |
| `src/Gateway.Api` | ASP.NET Core API | .NET 8 | `.csproj` | NuGet audit, `dotnet build` |
| `src/Shared.Contracts` | Class library | .NET 8 | `.csproj` | NuGet audit, build dependants |
| `src/Modules/Module1.Api` | ASP.NET Core API | .NET 8 | `.csproj` | NuGet audit, build/tests |
| `src/Modules/Module2.Api` | ASP.NET Core API | .NET 8 | `.csproj` | NuGet audit, build/tests |
| `src/Modules/Module3.Api` | ASP.NET Core API | .NET 8 | `.csproj` | NuGet audit, build/tests |
| `src/Modules/Module4.Api` | ASP.NET Core API | .NET 8 | `.csproj` | NuGet audit, build/tests |
| `src/Modules/Module5.Api` | ASP.NET Core API | .NET 8 | `.csproj` | NuGet audit, build/tests |
| `src/Legacy/LegacyWebApi1` | ASP.NET Web API | .NET Framework 4.8 | `.csproj`, `packages.config` | NuGet/MSBuild, tests if configured |
| `src/Legacy/LegacyWebApi2` | ASP.NET Web API | .NET Framework 4.8 | `.csproj`, `packages.config` | NuGet/MSBuild, tests if configured |
| `src/Legacy/LegacyWebApi3` | ASP.NET Web API | .NET Framework 4.8 | `.csproj`, `packages.config` | NuGet/MSBuild, tests if configured |
| `src/Desktop/WinFormsApp1` | WinForms | .NET Framework 4.8 | `.csproj`, `packages.config` | NuGet/MSBuild, desktop build |
| `src/Desktop/WinFormsApp2` | WinForms | .NET Framework 4.8 | `.csproj`, `packages.config` | NuGet/MSBuild, desktop build |

## Required generated fields
Add project references, package manager, scan timestamp, scanner version, scan status, build status, test status, finding count and report location.
