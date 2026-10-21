# Audit-only fixtures

These are **test inputs, not application projects**. They are intentionally not included in the Visual Studio solution and must not be installed, restored, built or remediated.

Use them only if you want to verify that your Playbook can:
- recognise a package manifest,
- report package versions,
- separate test fixtures from production application projects,
- avoid accidentally running package installation against arbitrary JSON/XML files.

The sample fixture below uses illustrative older versions. Whether a current scanner flags them depends on current advisory data and package-manager behaviour. Do not interpret this fixture as a definitive list of vulnerable versions.
