using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public sealed class Document : Resource
{
    private Document()
    {
    }

    private Document(string title, Resource parent) : base(title, parent)
    {
    }

    public static async Task<Document> CreateInstance(IFormFile file, Resource parent)
    {
        var document = new Document(file.FileName, parent);

        await using var stream = File.Create(document.Route);

        await file.CopyToAsync(stream);

        return document;
    }
}