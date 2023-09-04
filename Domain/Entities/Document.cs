namespace Domain.Entities;

public sealed class Document : Resource
{
    private Document()
    {
    }

    public Document(string title, Folder parent) : base(title, parent)
    {
    }
}