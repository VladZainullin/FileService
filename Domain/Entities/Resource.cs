// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Domain.Entities;

public abstract class Resource
{
    protected string _title;

#pragma warning disable CS8618
    protected Resource()
#pragma warning restore CS8618
    {
        Id = Guid.NewGuid();
    }

    protected Resource(string title, Folder parent) : this()
    {
        _title = title;
        Parent = parent;
        
    }

    public Guid Id { get; protected set; }

    public Guid ParentId { get; protected set; }
    public Resource Parent { get; private set; } = default!;

    public string Route => ReferenceEquals(Parent, default) ? _title : Parent.Route + '/';
}