using Application.Features.Folders.Commands.CreateFolder;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("resources")]
public sealed class ResourcesController : BaseController
{
    [HttpPost]
    public async Task<NoContentResult> CreateFolderAsync(
        CreateFolderRequestDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new CreateFolderCommand(dto), cancellationToken);
        
        return NoContent();
    }
}