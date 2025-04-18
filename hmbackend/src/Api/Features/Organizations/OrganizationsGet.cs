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
                        Description = "Alternativa 2, solo si falta profesor de matematicas",
                        Owner = "Owner 1",
                        ProgressPercentage = 45m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 2",
                        Description = "Proyecto para practicar y entrenamiento. No usar.",
                        Owner = "Owner 2",
                        ProgressPercentage = 75m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 3",
                        Description = "No pude resolver el cruce de matematicas en II A y III A, hable con Maria y decidimos contratar a un nuevo profesor.",
                        Owner = "Owner 3",
                        ProgressPercentage = 6m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 4",
                        Description = "",
                        Owner = "Owner 4",
                        ProgressPercentage = 8m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 5",
                        Description = "",
                        Owner = "Owner 5",
                        ProgressPercentage = 90m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 6",
                        Description = "",
                        Owner = "Owner 6",
                        ProgressPercentage = 100m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 7",
                        Description = "",
                        Owner = "Owner 7",
                        ProgressPercentage = 80m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 8",
                        Description = "Canchita esta de licencia asi que creamos este horarios solo para mover las clases de 2do A y 3ero A",
                        Owner = "Owner 8",
                        ProgressPercentage = 70m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 9",
                        Description = "No pude resolver el cruce de matematicas en II A y III A, hable con Maria y decidimos contratar a un nuevo profesor.",
                        Owner = "Owner 9",
                        ProgressPercentage = 3m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 10",
                        Description = "No pude resolver el cruce de Geo.",
                        Owner = "Owner 10",
                        ProgressPercentage = 85m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 11",
                        Description = "",
                        Owner = "Owner 11",
                        ProgressPercentage = 65m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 12",
                        Description = "Borrador de Julio. No usar.",
                        Owner = "Owner 12",
                        ProgressPercentage = 55m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 13",
                        Description = "",
                        Owner = "Owner 13",
                        ProgressPercentage = 95m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 14",
                        Description = "",
                        Owner = "Owner 14",
                        ProgressPercentage = 1m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 15",
                        Description = "",
                        Owner = "Owner 15",
                        ProgressPercentage = 25m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 16",
                        Description = "",
                        Owner = "Owner 16",
                        ProgressPercentage = 35m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 17",
                        Description = "",
                        Owner = "Owner 17",
                        ProgressPercentage = 45m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 18",
                        Description = "",
                        Owner = "Owner 18",
                        ProgressPercentage = 5m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 19",
                        Description = "",
                        Owner = "Owner 19",
                        ProgressPercentage = 6m
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Project 20",
                        Description = "",
                        Owner = "Owner 20",
                        ProgressPercentage = 7m
                    }
                }
            };
        }
    }
}