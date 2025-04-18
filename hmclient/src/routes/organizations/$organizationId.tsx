import {createFileRoute} from '@tanstack/react-router'
import OrganizationPage from "@/pages/organizations/OrganizationPage.tsx";
import {upfetch} from "@/common/upfetch.ts";
import {OrganizationViewModel, OrganizationViewModelSchema} from "@/pages/organizations/OrganizationViewModel.ts";

export const Route = createFileRoute('/organizations/$organizationId')({
  component: OrganizationPage,
  loader: loader
})

async function loader({ params }: { params: { organizationId: string } })
: Promise<OrganizationViewModel> {
  const { organizationId } = params;
  const result = await upfetch(`/api/organizations/${organizationId}`, {
      schema: OrganizationViewModelSchema
    });
  return result;
}

