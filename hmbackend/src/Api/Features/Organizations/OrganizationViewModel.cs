namespace Api.Features.Organizations;

public class OrganizationViewModel
{
    public required Guid OrganizationId { get; init; }

    public required IEnumerable<ProjectLookup> Projects { get; init; }

    public class ProjectLookup
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required string Owner { get; init; }

        public required decimal ProgressPercentage { get; init; }
    }
}