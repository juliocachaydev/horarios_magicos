import {OrganizationViewModel, ProjectModel} from "@/pages/organizations/OrganizationViewModel.ts";
import {Route} from "@/routes/organizations/$organizationId.tsx";
import {useEffect, useState} from "react";

export type OrganizationServices = {
    model: OrganizationViewModel;
    onProjectUpdated: (project: ProjectModel) => Promise<void>;
    onAddProject: (project: ProjectModel) => Promise<void>;
    deleteProject: (projectId: string) => Promise<void>;
}

export default function useOrganizationServices() : OrganizationServices{
    const model = Route.useLoaderData();
    const [localModel, setLocalModel] = useState(model);

    useEffect(()=>{
        setLocalModel(model)
    }, [model])

    const handleProjectUpdated = async (updatedProject: ProjectModel)=>{
        setLocalModel((prev) => ({
            ...prev,
            projects: prev.projects.map((p) => p.id === updatedProject.id ? updatedProject : p)
        }));
    }

    const handleAddProject = async (newProject: ProjectModel) => {
        setLocalModel((prev) => ({
            ...prev,
            projects: [newProject, ...prev.projects]
        }));
    }

    const handleDeleteProject = async (projectId: string) => {
        setLocalModel((prev) => ({
            ...prev,
            projects: prev.projects.filter((p) => p.id !== projectId)
        }));
    }

    return {
        model: localModel,
        onProjectUpdated: handleProjectUpdated,
        onAddProject: handleAddProject,
        deleteProject: handleDeleteProject
        }

}