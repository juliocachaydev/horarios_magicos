import { createRootRoute } from '@tanstack/react-router'

import MainLayout from "@/pages/layouts/MainLayout.tsx";

export const Route = createRootRoute({
    component: MainLayout
})