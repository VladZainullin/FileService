using MediatR;

namespace Application.Features.Folders.Commands.CreateFolder;

public sealed record CreateFolderCommand(CreateFolderRequestDto Dto) : IRequest;