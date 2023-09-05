using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Folders.Commands.CreateFolder;

file sealed class CreateFolderHandler : IRequestHandler<CreateFolderCommand>
{
    private readonly IAppDbContext _context;

    public CreateFolderHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateFolderCommand request, CancellationToken cancellationToken)
    {
        var parent = await GetResourceAsync(request.Dto.ParentId, cancellationToken);

        var folder = new Folder(request.Dto.Title, parent);

        await _context.Resources.AddAsync(folder, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private Task<Resource> GetResourceAsync(Guid resourceId, CancellationToken cancellationToken)
    {
        return _context.Resources
            .AsTracking()
            .SingleAsync(r => r.Id == resourceId, cancellationToken);
    }
}