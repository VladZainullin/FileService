using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Documents.UploadDocument;

public sealed class UploadDocumentHandler : IRequestHandler<UploadDocumentCommand>
{
    private readonly IAppDbContext _context;
    private readonly IResourceFactory _resourceFactory;

    public UploadDocumentHandler(IAppDbContext context, IResourceFactory resourceFactory)
    {
        _context = context;
        _resourceFactory = resourceFactory;
    }

    public async Task Handle(
        UploadDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var parent = await GetResourceAsync(request, cancellationToken);

        var document = await _resourceFactory.CreateDocumentAsync(request.Dto.File, parent, cancellationToken);

        await _context.Resources.AddAsync(document, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private Task<Resource> GetResourceAsync(UploadDocumentCommand request, CancellationToken cancellationToken)
    {
        return _context.Resources
            .Where(r => r.Id == request.Dto.ParentId)
            .SingleAsync(cancellationToken);
    }
}