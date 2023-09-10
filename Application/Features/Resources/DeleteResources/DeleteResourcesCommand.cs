using MediatR;

namespace Application.Features.Resources.DeleteResources;

public sealed class DeleteResourcesCommand : IRequest
{
    public required DeleteResourcesRequestDto Dto { get; init; }
}