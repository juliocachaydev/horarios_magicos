import { createFileRoute } from '@tanstack/react-router'
import OrganizationPage from "@/pages/organizations/OrganizationPage.tsx";

export const Route = createFileRoute('/organizations/$organizationId')({
  component: OrganizationPage,
})

