using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IResourceFactory
{
    Folder CreateFolder(string title, Resource parent);

    Task<Document> CreateDocumentAsync(
        IFormFile file,
        Resource parent,
        CancellationToken cancellationToken);
}