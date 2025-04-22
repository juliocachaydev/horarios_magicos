using Moq;
using Packages.Repository;

namespace WebApi.Libraries.AbstractStorage.Testing;

public class IRepositoryMock
{
    private Mock<IRepository> _moq;

    public IRepository Object => _moq.Object;
    

    public IRepositoryMock()
    {
        _moq = new Mock<IRepository>();
    }

    public void SetupLoad<T>(Guid id, T entity) where T : class
    {
        _moq.Setup(x=>
            x.LoadAsync<T>(id))
            .ReturnsAsync(entity);
        
        _moq.Setup(x=>
                x.LoadOrThrowAsync<T>(id))
            .ReturnsAsync(entity);
    }

    public void VerifyAdd<T>(T entity) where T : class
    {
        _moq.Verify(x=>
            x.AddAsync<T>(entity));
    }

    public void VerifyLoad<T>(Guid id) where T : class
    {
        _moq.Verify(x=>
            x.LoadAsync<T>(id));
    }
    
    public void VerifyLoadOrThrow<T>(Guid id) where T : class
    {
        _moq.Verify(x=>
            x.LoadOrThrowAsync<T>(id));
    }
    
    public void VerifyAdd<T>(Func<T, bool> predicate) where T : class
    {
        _moq.Verify(x=>
            x.AddAsync<T>(It.Is<T>(y=> predicate(y))));
    }
    
    public void VerifyRemove<T>(Guid id) where T : class
    {
        _moq.Verify(x=>
            x.RemoveAsync<T>(id));
    }

    public void VerifyCommitChanges()
    {
        _moq.Verify(x=>
            x.CommitChangesAsync());
    }
    
}