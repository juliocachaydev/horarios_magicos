import {useEffect, useRef, useState} from "react";
import {ProjectModel} from "@/pages/organizations/OrganizationViewModel.ts";
import {ProjectCardForm, ProjectCardRead} from "@/pages/organizations/components/ProjectCardMarkup.tsx";
import ConfirmDeleteDialog from "@/components/custom/dialogs/ConfirmDeleteDialog.tsx";

export type ProjectCardProps = {
    model: ProjectModel;
    forbiddenNames: string[];
    owner: string;
    progress: number;
    onOpen: (projectId: string) => Promise<void>;
    onUpdate: (model: ProjectModel) => Promise<void>;
    onDelete: (projectId: string) => Promise<void>;
}

const ProjectCard = (props: ProjectCardProps) => {
    const [currentState, setCurrentState] = useState<'read'|'edit'|'delete'>('read');
   // const [isEditMode, setIsEditMode] = useState(false);

    const ref = useRef<HTMLDivElement>(null);

    const isEditMode = currentState === 'edit';
    const deleteDialogOpened = currentState === 'delete';

    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (ref.current && !ref.current.contains(event.target as Node)) {
                setCurrentState('read');
            }
        }
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        }
    }, [ref]);

    const handleConfirmDelete = async () => {
        await props.onDelete(props.model.id);
        setCurrentState('read');
    }

    const handleMenuDeleteClick = async () =>{
        setCurrentState('delete');
    }

    const deleteDialogTitle = 'Confirmar borrar';

    const confirmDeleteDescription = '¿Estás seguro de que quieres borrar este proyecto? Esta acción no se puede deshacer.' +
        'para confirmar, escribe el nombre del proyecto: ' + props.model.name;

    if (!isEditMode)
    {
        return (
            <>
                <ProjectCardRead model={props.model} onOpen={async () => {}} onEnterEditMode={()=>
                    setCurrentState('edit')} onDelete={handleMenuDeleteClick}/>
                <ConfirmDeleteDialog onConfirm={handleConfirmDelete}
                                     open={deleteDialogOpened}
                                     confirmKeyword={props.model.name}
                                     onCancel={()=>setCurrentState('read')}
                                     title={deleteDialogTitle} description={confirmDeleteDescription}/>
            </>
        )
    }
    return (
        <>
            <ProjectCardForm model={props.model}
                             forbiddenNames={props.forbiddenNames}
                             onUpdate={async (m)=>{
                                 await props.onUpdate(m);
                             }} exitEditMode={()=>setCurrentState('read')}
                             onDelete={handleConfirmDelete}/>
            <ConfirmDeleteDialog onConfirm={handleConfirmDelete}
                                 open={deleteDialogOpened}
                                 onCancel={()=>setCurrentState('read')}
                                 confirmKeyword={props.model.name}
                                 title={deleteDialogTitle} description={confirmDeleteDescription}/>
        </>
    )
}

export default ProjectCard;