import HmAlert from "@/components/custom/HmAlert.tsx";
import {HmButtonSolid} from "@/components/custom/HmButton.tsx";
import {Plus} from "lucide-react";
import { Separator } from "@/components/ui/separator.tsx";
import ProjectCard from "@/pages/organizations/components/ProjectCard.tsx";
import useOrganizationServices from "@/pages/organizations/useOrganizationServices.ts";
import AddProjectDialog from "@/pages/organizations/components/AddProjectDialog.tsx";


export default function OrganizationPage()
{
    const {model, onProjectUpdated, onAddProject, deleteProject} = useOrganizationServices();



    return (<div className='flex flex-col gap-8'>
        <div className='
        sticky top-0 bg-white z-10'>
            <h1 className='text-5xl border-l mt-4'>Proyectos</h1>
            <HmAlert className='mt-4' message='bla bla'/>
            <div className='mt-12'>
                <AddProjectDialog onProjectAdded={onAddProject} forbiddenNames={
                    model.projects.map(p => p.name)
                }/>
            </div>
            <Separator className='mt-6'/>
        </div>

        <div className='flex flex-wrap gap-8'>
            {model.projects.map(p=>(
                <ProjectCard
                    key={p.id}
                    model={p}
                    forbiddenNames={model.projects.map(p => p.name)
                        .filter(x=> x.toUpperCase().trim() !== p.name.toUpperCase().trim())}
                    owner={p.owner}
                    progress={p.progressPercentage}
                    onOpen={async ()=>{}}
                    onUpdate={onProjectUpdated}
                    onDelete={deleteProject}

                />))}
        </div>
    </div>)
}