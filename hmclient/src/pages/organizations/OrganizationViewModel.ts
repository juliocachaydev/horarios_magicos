import {z} from 'zod';


export const OrganizationViewModelSchema =
    z.object({
        organizationId: z.string(),
        projects: z.array(
            z.object({
                id: z.string(),
                name: z.string(),
                description: z.string(),
                owner: z.string(),
                progressPercentage: z.number()
            })
        )
    })

export type OrganizationViewModel = z.infer<typeof OrganizationViewModelSchema>;
