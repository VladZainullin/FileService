namespace Domain.Entities;

public class Folder : Resource
{
    protected Folder()
    {
    }

    public Folder(string title, Resource parent) : base(title, parent)
    {
    }

    public IReadOnlyCollection<Resource> Children { get; private set; } = new List<Resource>();
}