namespace Domain.Entities;

public class Folder : Resource
{
    protected Folder()
    {
    }

    protected Folder(string title, Folder parent) : base(title, parent)
    {
    }

    public IReadOnlyCollection<Resource> Children { get; private set; } = new List<Resource>();
}