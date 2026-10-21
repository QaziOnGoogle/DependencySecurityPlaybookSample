# Devin Playbook: Multi-Project Dependency Security Audit

## Goal
Audit every application and library in the repository for vulnerable NuGet and Node.js dependencies, classify findings, and propose the smallest compatible fix. Do not merge or deploy.

## Operating modes
1. **Report-only (default):** discover, scan and report; do not edit dependency files.
2. **Remediation (only when explicitly authorised):** create a branch, make narrowly scoped changes, validate and prepare a pull request if the GitHub integration permits it.

## Phase 1 — Discover the entire repository
- Search recursively for `.sln`, `.csproj`, `package.json`, lockfiles, `packages.config`, `Directory.Packages.props`, `NuGet.config` and test projects.
- Do not assume all projects are included in a solution. The Angular WebUI in `src/WebUI` is intentionally outside the `.sln`.
- Identify project type, relative path, target framework, package manager, manifests, project references and validation commands.
- Exclude generated folders (`bin`, `obj`, `node_modules`, `.git`) from inventory.
- Treat `fixtures/audit-only/**` as test data only: do not install, restore, build or remediate these fixtures as application code. Report them separately if asked to test scanner behaviour.

## Phase 2 — Scan by project type
### npm / Angular
- Read `package.json` and the committed lockfile.
- Use the repository's actual package manager.
- Run `npm audit` when npm is the package manager and the registry is reachable.
- Do not run force fixes or silently rewrite lockfiles during report-only mode.

### Modern .NET
- Inspect `PackageReference`, central package management and lockfiles.
- Run a supported NuGet vulnerability audit including transitive dependencies.
- Record command/tooling version and whether the scan completed.

### .NET Framework 4.8
- Inspect old-style project files, `packages.config`, `PackageReference` and NuGet configuration.
- Use Windows/MSBuild/NuGet tooling compatible with the project.
- Do not claim build validation succeeded if the required targeting pack or MSBuild workload is unavailable.

### Shared libraries
- Record every project that references the library.
- When a shared dependency changes, validate the library and all affected dependants.

## Phase 3 — Consolidate
For each advisory, record package, installed version, fixed version (if known), severity, advisory/CVE, direct/transitive status, dependency path and affected project paths.
- Deduplicate the same advisory in the executive summary while retaining every affected project.
- Distinguish vulnerable packages from merely outdated packages.
- Prioritise active exploitation, severity, exposure and availability of a compatible fix.
- If scanning fails, mark the project `NOT SCANNED` and explain why; never report it as clean.

## Phase 4 — Remediate safely
- Only remediate when explicitly authorised.
- Prefer the smallest compatible patched version.
- Preserve target frameworks and package-manager conventions.
- Avoid unrelated upgrades, forced major upgrades and architectural migrations.
- Coordinate shared package changes only where compatible across all affected frameworks.
- Separate incompatible changes into separate branches/PRs.
- Ask for review when no safe compatible fix is clear.

## Phase 5 — Validate
- Restore dependencies with the repository's normal tooling.
- Build affected projects.
- Run configured tests and frontend checks.
- Re-run the vulnerability scan.
- Record each check as `PASS`, `FAIL`, `BLOCKED` or `NOT CONFIGURED`.
- Include build environment/tool versions and exact failures.

## Phase 6 — Report
Use `REPORT-TEMPLATE.md`. Include scan coverage, all project paths, severity, affected projects, proposed changes, test results, unresolved risks and next steps.
- Do not commit to the default branch.
- Do not merge or deploy.
- Never print credentials or tokens.
