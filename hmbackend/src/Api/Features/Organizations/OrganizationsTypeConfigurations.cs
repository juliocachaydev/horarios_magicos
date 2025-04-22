using Domain.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Features.Organizations;

public static class OrganizationsTypeConfigurations
{
    class ProjectTypeConfiguration : IEntityTypeConfiguration<ProjectState>
    {
        public void Configure(EntityTypeBuilder<ProjectState> builder)
        {
            // nothing
        }
    }
}