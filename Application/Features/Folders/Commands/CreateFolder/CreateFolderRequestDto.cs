namespace Application.Features.Folders.Commands.CreateFolder;

public sealed class CreateFolderRequestDto
{
    public required string Title { get; init; }

    public required Guid ParentId { get; init; }
}