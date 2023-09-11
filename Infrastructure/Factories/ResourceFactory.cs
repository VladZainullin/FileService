using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Factories;

internal sealed class ResourceFactory : IResourceFactory
{
    public Folder CreateFolder(string title, Resource parent)
    {
        var folder = new Folder(title, parent);

        if (!Directory.Exists(folder.Route)) Directory.CreateDirectory(folder.Route);

        return folder;
    }

    public async Task<Document> CreateDocumentAsync(
        IFormFile file,
        Resource parent,
        CancellationToken cancellationToken)
    {
        var document = new Document(file.FileName, parent);

        await using var stream = new FileStream(
            document.Route,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            8192,
            true);;

        await file.CopyToAsync(stream, cancellationToken);

        return document;
    }
}