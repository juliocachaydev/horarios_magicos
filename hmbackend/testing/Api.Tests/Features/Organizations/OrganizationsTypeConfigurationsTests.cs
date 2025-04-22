using Alpaca;
using Api.Tests.TestCommon.Factories;

namespace Api.Tests.Features.Organizations;

public class OrganizationsTypeConfigurationsTests : TestIntegrationTestBase
{
    [Fact]
    public async Task CanStoreAndRetrieve()
    {
        // ***** ARRANGE *****

        var state = TestProjectsFactory.CreateState();

        // ***** ACT *****
        
        DefaultApplicationFactory.AddEntitiesToDatabase(state);
        var result = DefaultApplicationFactory.GetEntity(db => db.Projects.First(x =>
            x.Id == state.Id));

        // ***** ASSERT *****
        
        Assert.Equivalent(state, result);
    }
}