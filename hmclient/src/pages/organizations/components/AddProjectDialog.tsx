import {ProjectModel} from "@/pages/organizations/OrganizationViewModel.ts";
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import {Plus} from "lucide-react";
import {HmButtonSolid} from "@/components/custom/HmButton.tsx";
import {ProjectCardForm} from "@/pages/organizations/components/ProjectCardMarkup.tsx";
import {useEffect, useMemo, useState} from "react";
import generateUuid from "@/common/generateUuid.ts";
import { Button } from "@/components/ui/button"

export type AddProjectDialogProps = {
    onProjectAdded: (project: ProjectModel)=>Promise<void>;
    forbiddenNames: string[];
}

export default function AddProjectDialog(
    props: AddProjectDialogProps
)
{
    const [model, setModel] = useState<ProjectModel | null>(null);

    const onNewClick = async () =>{
        setModel({
            id: generateUuid(),
            name: '',
            description: '',
            owner: '',
            progressPercentage: 0
        })
    }

    const onCancelClick = () => setModel(null);

    const nonEmptyModel = model ?? {
        id: '',
        name: '',
        description: '',
        owner: '',
        progressPercentage: 0,
        isArchived: false,
    }

    return (
        <Dialog>
            <DialogTrigger asChild>
                <Button onClick={onNewClick}
                        className='inline-flex'>
                    <Plus/>
                    Crear Proyecto
                </Button>
            </DialogTrigger>
            <DialogContent className="sm:max-w-[425px]">
                <DialogHeader>
                    <DialogTitle>Agregar un proyecto</DialogTitle>
                    <DialogDescription>
                        Usa este diálogo para agregar un proyecto nuevo.
                    </DialogDescription>
                </DialogHeader>
                <ProjectCardForm model={nonEmptyModel} forbiddenNames={props.forbiddenNames}
                                 onUpdate={props.onProjectAdded}
                                 exitEditMode={onCancelClick}
                createMode/>
            </DialogContent>
        </Dialog>
    );
}