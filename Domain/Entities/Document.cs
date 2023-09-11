namespace Domain.Entities;

public sealed class Document : Resource
{
    private Document()
    {
    }

    public Document(string title, Resource parent) : base(title, parent)
    {
    }
}