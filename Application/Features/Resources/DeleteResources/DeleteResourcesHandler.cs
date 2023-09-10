using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Resources.DeleteResources;

file sealed class DeleteResourcesHandler : IRequestHandler<DeleteResourcesCommand>
{
    private readonly IAppDbContext _context;

    public DeleteResourcesHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(
        DeleteResourcesCommand request,
        CancellationToken cancellationToken)
    {
        var resources = await GetResourcesAsync(request, cancellationToken);

        _context.Resources.RemoveRange(resources);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private Task<List<Resource>> GetResourcesAsync(DeleteResourcesCommand request, CancellationToken cancellationToken)
    {
        return _context.Resources
            .AsNoTracking()
            .Where(r => request.Dto.ResourcesIds.Contains(r.Id))
            .ToListAsync(cancellationToken);
    }
}