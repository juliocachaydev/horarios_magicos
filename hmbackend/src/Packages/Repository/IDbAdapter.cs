namespace Packages.Repository;

public interface IDbAdapter
{
    Task CommitChangesAsync();
}