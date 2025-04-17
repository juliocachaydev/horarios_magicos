using MediatR;

namespace Api.Features.Organizations;

public class OrganizationsGet : IRequest<OrganizationViewModel>{
    public required Guid OrganizationId { get; init; }

    class Handler : IRequestHandler<OrganizationsGet, OrganizationViewModel>
    {
        public async Task<OrganizationViewModel> Handle(OrganizationsGet request, CancellationToken cancellationToken)
        {
            return new OrganizationViewModel()
            {
                OrganizationId = request.OrganizationId,
                Projects = new List<OrganizationViewModel.ProjectLookup>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 1",
                        Owner = "Owner 1",
                        ProgressPercentage = 45m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 2",
                        Owner = "Owner 2",
                        ProgressPercentage = 75m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 3",
                        Owner = "Owner 3",
                        ProgressPercentage = 6m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 4",
                        Owner = "Owner 4",
                        ProgressPercentage = 8m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 5",
                        Owner = "Owner 5",
                        ProgressPercentage = 90m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 6",
                        Owner = "Owner 6",
                        ProgressPercentage = 100m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 7",
                        Owner = "Owner 7",
                        ProgressPercentage = 80m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 8",
                        Owner = "Owner 8",
                        ProgressPercentage = 70m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 9",
                        Owner = "Owner 9",
                        ProgressPercentage = 3m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 10",
                        Owner = "Owner 10",
                        ProgressPercentage = 85m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 11",
                        Owner = "Owner 11",
                        ProgressPercentage = 65m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 12",
                        Owner = "Owner 12",
                        ProgressPercentage = 55m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 13",
                        Owner = "Owner 13",
                        ProgressPercentage = 95m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 14",
                        Owner = "Owner 14",
                        ProgressPercentage = 1m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 15",
                        Owner = "Owner 15",
                        ProgressPercentage = 25m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 16",
                        Owner = "Owner 16",
                        ProgressPercentage = 35m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 17",
                        Owner = "Owner 17",
                        ProgressPercentage = 45m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 18",
                        Owner = "Owner 18",
                        ProgressPercentage = 5m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 19",
                        Owner = "Owner 19",
                        ProgressPercentage = 6m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 20",
                        Owner = "Owner 20",
                        ProgressPercentage = 7m
                    }
                }
            };
        }
    }
}