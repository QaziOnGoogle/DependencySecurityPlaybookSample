namespace Shared.Contracts;

public sealed record ServiceStatus(string Application, string Status, DateTimeOffset CheckedAtUtc);
