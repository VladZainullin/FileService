namespace Application.Features.Resources.DeleteResources;

public sealed class DeleteResourcesRequestDto
{
    public required IEnumerable<Guid> ResourcesIds { get; init; }
}