using Domain.Entities;
using Infrastructure.Options;

namespace Infrastructure.Entities;

internal sealed class RootFolder : Folder
{
    private static RootFolder? _rootFolder;

    private RootFolder()
    {
    }

    private RootFolder(string title, Folder parent) : base(title, parent)
    {
    }

    public static RootFolder CreateInstance(RootFolderOptions rootFolderOptions)
    {
        try
        {
            _rootFolder ??= new RootFolder
            {
                Title = rootFolderOptions.Path,
                Id = rootFolderOptions.Id,
                ParentId = rootFolderOptions.Id
            };

            Directory.CreateDirectory(rootFolderOptions.Path);

            return _rootFolder;
        }
        catch
        {
            if (!Directory.Exists(rootFolderOptions.Path)) Directory.Delete(rootFolderOptions.Path);
            throw;
        }
    }

    public override string Route => Title;
}