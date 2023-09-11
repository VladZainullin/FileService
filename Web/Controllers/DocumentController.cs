using Application.Features.Documents.UploadDocument;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("documents")]
public sealed class DocumentController : BaseController
{
    [HttpPost]
    [RequestSizeLimit(100_000_000_000)]
    public async Task<NoContentResult> UploadFileAsync(
        [FromForm] UploadDocumentRequestDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new UploadDocumentCommand(dto), cancellationToken);

        return NoContent();
    }
}