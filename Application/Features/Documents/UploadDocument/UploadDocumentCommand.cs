using MediatR;

namespace Application.Features.Documents.UploadDocument;

public sealed class UploadDocumentCommand : IRequest
{
    public UploadDocumentCommand(UploadDocumentRequestDto dto)
    {
        Dto = dto;
    }

    public UploadDocumentRequestDto Dto { get; }
}