import {Route} from '../../routes/organizations/$organizationId';
import HmAlert from "@/components/custom/HmAlert.tsx";
import {HmButtonSolid} from "@/components/custom/HmButton.tsx";
import {Plus} from "lucide-react";
import { Separator } from "@/components/ui/separator.tsx";
import ProjectCard from "@/pages/organizations/components/ProjectCard.tsx";
import {useState} from "react";
import {ProjectModel} from "@/pages/organizations/OrganizationViewModel.ts";
import generateUuid from "@/common/generateUuid.ts";


export default function OrganizationPage()
{
    const model = Route.useLoaderData();


    return (<div className='flex flex-col gap-8'>
        <div className='flex flex-col gap-4
        sticky top-0 bg-white z-10'>
            <h1 className='text-3xl'>Proyectos</h1>
            <HmAlert message='bla bla'/>
            <HmButtonSolid disabled={false} variant='default' onClick={()=>{}} text='Otro Proyecto' icon={<Plus/>}/>
            <Separator className='mt-3'/>
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
                    onUpdate={async () => {}}
                />))}
        </div>
    </div>)
}