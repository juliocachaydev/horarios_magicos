using Domain.Organizations;
using Domain.ValueObjects;

namespace Domain.Tests.Organizations;

public class ProjectTests
{
    [Fact]
    public void CanCreate()
    {
        // ***** ARRANGE *****

        var id = EntityIdentity.Random;
        var name = NonEmptyString.Random;
        

        // ***** ACT *****
        
        var sut = new Project(id, name);

        // ***** ASSERT *****
        
        Assert.Equal(id, sut.Id);
        Assert.Equal(name, sut.Name);
    }
}