import {z} from 'zod';

export const ProjectModelSchema =
    z.object({
        id: z.string(),
        name: z.string(),
        description: z.string(),
        owner: z.string(),
        progressPercentage: z.number()
    })

export const OrganizationViewModelSchema =
    z.object({
        organizationId: z.string(),
        projects: z.array(
            ProjectModelSchema)

    })

export type OrganizationViewModel = z.infer<typeof OrganizationViewModelSchema>;

export type ProjectModel = z.infer<typeof ProjectModelSchema>;
