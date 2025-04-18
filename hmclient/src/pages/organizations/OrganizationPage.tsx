import {Route} from '../../routes/organizations/$organizationId';
import HmAlert from "@/components/custom/HmAlert.tsx";
import {HmButtonSolid} from "@/components/custom/HmButton.tsx";
import {Plus} from "lucide-react";
import { Separator } from "@/components/ui/separator.tsx";
import ProjectCard from "@/pages/organizations/components/ProjectCard.tsx";


export default function OrganizationPage()
{
    const model = Route.useLoaderData();

    const handleClick = () => {
        alert('clicked');
    }

    return (<div>
        <h1>Proyectos</h1>
        <HmAlert message='bla bla'/>
        <HmButtonSolid disabled={false} variant='default' onClick={handleClick} text='click me' icon={<Plus/>}/>
        <Separator/>
        {model.projects.map(p=>(
            <ProjectCard
                projectId={p.id}
                name={p.name}
                description={p.description}
                owner={p.owner}
                progress={p.progressPercentage}
                onOpen={async ()=>{}}
                onUpdate={async () => {}}
            />))}
    </div>)
}