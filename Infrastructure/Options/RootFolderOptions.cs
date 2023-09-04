namespace Infrastructure.Options;

public sealed class RootFolderOptions
{
    public required string Path { get; init; }

    public required Guid Id { get; init; }
}