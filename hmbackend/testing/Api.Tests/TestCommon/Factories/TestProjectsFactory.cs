using AutoFixture;
using Domain.Organizations;

namespace Api.Tests.TestCommon.Factories;

public static class TestProjectsFactory
{
    public static ProjectState CreateState()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };
    }
}