using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Documents.UploadDocument;

public sealed class UploadDocumentHandler : IRequestHandler<UploadDocumentCommand>
{
    private readonly IAppDbContext _context;

    public UploadDocumentHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(
        UploadDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var parent = await _context.Resources
            .Where(r => r.Id == request.Dto.ParentId)
            .SingleAsync(cancellationToken);

        var document = await Document.CreateInstance(request.Dto.File, parent);

        await _context.Resources.AddAsync(document, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}