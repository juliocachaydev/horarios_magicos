import {useEffect, useRef, useState} from "react";
import {ProjectModel} from "@/pages/organizations/OrganizationViewModel.ts";
import {ProjectCardForm, ProjectCardRead} from "@/pages/organizations/components/ProjectCardMarkup.tsx";

export type ProjectCardProps = {
    model: ProjectModel;
    forbiddenNames: string[];
    owner: string;
    progress: number;
    onOpen: (projectId: string) => Promise<void>;
    onUpdate: (model: ProjectModel) => Promise<void>;
}

const ProjectCard = (props: ProjectCardProps) => {
    const [isEditMode, setIsEditMode] = useState(false);

    const ref = useRef<HTMLDivElement>(null);

    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (ref.current && !ref.current.contains(event.target as Node)) {
                setIsEditMode(false);
            }
        }
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        }
    }, [ref]);


    if (!isEditMode)
    {
        return (
            <ProjectCardRead model={props.model} onOpen={async () => {}} onEnterEditMode={()=>
            setIsEditMode(true)}/>
        )
    }
    return (
        <ProjectCardForm model={props.model}
                         forbiddenNames={props.forbiddenNames}
                         onUpdate={async (m)=>{
                             await props.onUpdate(m);
                         }} exitEditMode={()=>setIsEditMode(false)}/>
    )
}

export default ProjectCard;