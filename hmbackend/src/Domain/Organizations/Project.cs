using Domain.ValueObjects;

namespace Domain.Organizations;

public class Project
{
    private readonly ProjectState _state;

    public EntityIdentity Id => new(_state.Id);

    public NonEmptyString Name => new(_state.Name);

    public Project(ProjectState state)
    {
        _state = state;
    }

    public Project(EntityIdentity id, NonEmptyString name)
    {
        _state = new()
        {
            Id = id.Value,
            Name = name.Value
        };
    }
}