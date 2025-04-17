import {createFileRoute} from '@tanstack/react-router'
import OrganizationPage from "@/pages/organizations/OrganizationPage.tsx";
import {upfetch} from "@/common/upfetch.ts";
import {z} from 'zod';

export const Route = createFileRoute('/organizations/$organizationId')({
  component: OrganizationPage,
  loader: loader
})

async function loader({ params }: { params: { organizationId: string } }) {
  const { organizationId } = params;
  return await upfetch(`/api/organizations/${organizationId}`, {
    schema: z.object({
      id: z.string(),
      projects: z.array(
          z.object({
            id: z.string(),
            name: z.string(),
            owner: z.string(),
            progress: z.number()
          })
      )
    })
  });
}

