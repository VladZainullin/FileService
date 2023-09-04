// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

using Domain.Enums;

namespace Domain.Entities;

public abstract class Resource
{
#pragma warning disable CS8618
    protected Resource()
#pragma warning restore CS8618
    {
        Id = Guid.NewGuid();
    }

    protected Resource(string title, Folder parent) : this()
    {
        Title = title;
        Parent = parent;
    }

    public Guid Id { get; protected set; }

    public ResourceType TypeId { get; private set; }

    public string Title { get; protected set; } = default!;

    public Guid ParentId { get; protected set; }
    public Resource Parent { get; private set; } = default!;

    public string Route => ReferenceEquals(Parent, this) ? Title : Parent.Route + '/';
}