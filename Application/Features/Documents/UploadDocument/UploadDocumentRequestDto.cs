using Microsoft.AspNetCore.Http;

namespace Application.Features.Documents.UploadDocument;

public sealed class UploadDocumentRequestDto
{
    public required IFormFile File { get; init; }
    public required Guid ParentId { get; init; }
}