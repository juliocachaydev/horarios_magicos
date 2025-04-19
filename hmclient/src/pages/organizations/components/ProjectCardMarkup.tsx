import {ProjectModel} from "@/pages/organizations/OrganizationViewModel.ts";
import {Card, CardContent, CardDescription, CardHeader, CardTitle} from "@/components/ui/card.tsx";
import {Progress} from "@/components/ui/progress.tsx";
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuGroup, DropdownMenuItem,
    DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import {Button} from "@/components/ui/button.tsx";
import {Menu, User} from "lucide-react";
import {Badge} from "@/components/ui/badge.tsx";
import {useForm} from "@tanstack/react-form";
import {Input} from "@/components/ui/input.tsx";
import {Textarea} from "@/components/ui/textarea.tsx";
import {useEffect, useRef} from "react";
import {HmButtonSolid} from "@/components/custom/HmButton.tsx";
import HmFormField from "@/components/custom/Forms/HmFormField.tsx";
import {Separator} from "@/components/ui/separator.tsx";

export type ProjectCardReadProps = {
    model: ProjectModel;
    onOpen: (projectId: string) => Promise<void>;
    onDelete: (projectId: string) => Promise<void>;
    onEnterEditMode: () => void;
}

export type ProjectCardFormProps = {
    model: ProjectModel;
    forbiddenNames: string[];
    onUpdate: (model: ProjectModel) => Promise<void>;
    exitEditMode: () => void;
    onDelete: (projectId: string) => Promise<void>;
    createMode?: boolean;
}

export const ProjectCardRead = (props: ProjectCardReadProps) => {
    return (
        <Card className='w-[350px]'>
            <CardHeader>
                <CardTitle onClick={props.onEnterEditMode} className='flex justify-between items-center-safe'>
                    {props.model.name}
                    <ProjectMenu disabled={false} OnArchive={() => {}} OnDelete={() => {
                        props.onDelete(props.model.id)
                    }}/></CardTitle>
                <CardDescription onClick={props.onEnterEditMode}>{props.model.description}</CardDescription>
                <Separator/>
            </CardHeader>
            <CardContent>
                <UserTag name={props.model.owner}/>
                <Progress value={props.model.progressPercentage}></Progress>
            </CardContent>
        </Card>
    )
}

export const ProjectCardForm = (props: ProjectCardFormProps) =>{
    const form = useForm({
        defaultValues: props.model,
        onSubmit: async ({value}) => {
            await props.onUpdate(value)
            props.exitEditMode();
        }
    });
    const ref = useRef<HTMLDivElement>(null);
    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (ref.current && !ref.current.contains(event.target as Node)) {
                props.exitEditMode();
            }
        }
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        }
    }, [ref, props.exitEditMode]);

    const nameValidator = (value: string):string | undefined=>{
        if (value.length == 0)
        {
            return 'Debes ingresar un nombre.'
        }
        if (props.forbiddenNames.some(x=>
        x.toUpperCase().trim() == value.toUpperCase().trim()))
        {
            return 'El nombre ya existe.';
        }
        return undefined;
    }

    const isUpdateMode = props.createMode === undefined || props!.createMode === false;

    const cardClassName = isUpdateMode ? 'w-[350px]' : 'w-[350px] border-0 shadow-none';

    return (
        <form onSubmit={async (e)=>{
            e.preventDefault();
            await form.handleSubmit();
        }}>
            <Card ref={ref} className={cardClassName}>
                <CardHeader>
                    <CardTitle className='flex justify-between items-center-safe'>
                        <form.Field name='name'
                                    validators={{
                                        onBlur: ({value}) => nameValidator(value)
                                    }}
                                    children={(field)=>(
                                        <HmFormField errors={field.state.meta.errors.join(', ')}>
                                            <Input
                                                value={field.state.value}
                                                onBlur={field.handleBlur}
                                                onChange={(e) => field.handleChange(e.target.value)}/>
                                        </HmFormField>
                                    )}/>

                        {isUpdateMode && <ProjectMenu disabled OnArchive={() => {}} OnDelete={
                            ()=> props.onDelete(props.model.id)
                        }/>}</CardTitle>
                    <form.Field name='description'
                    children={(field)=>(
                        <Textarea placeholder='descripcion...'
                                  className='mt-3'
                        value={field.state.value}
                        onBlur={field.handleBlur}
                        onChange={(e)=>field.handleChange(e.target.value)}/>
                    )}/>
                    <div className='flex gap-2 mt-3'>
                        <HmButtonSolid variant='default' text='Guardar'
                                       disabled={!form.state.isFormValid}
                                       type='submit'/>
                        <HmButtonSolid variant='secondary' text='Cancelar' onClick={props.exitEditMode}/>
                    </div>
                    {isUpdateMode && <Separator/>}
                </CardHeader>
                {isUpdateMode && <CardContent>
                    <UserTag name={props.model.owner}/>
                    <Progress value={props.model.progressPercentage}></Progress>
                </CardContent>}
            </Card>
        </form>
    )
}

type ProjectMenuProps = {
    disabled: boolean;
    OnArchive: () => void;
    OnDelete: () => void;
}

const ProjectMenu = (props: ProjectMenuProps) => {
    return (
        <div onClick={e=>e.stopPropagation()}>
            <DropdownMenu>
                <DropdownMenuTrigger asChild>
                    <Button variant="outline" size="icon" disabled={props.disabled}>
                        <Menu />
                    </Button>
                </DropdownMenuTrigger>
                <DropdownMenuContent>
                    <DropdownMenuGroup>
                        <DropdownMenuItem onClick={props.OnArchive}>
                            Archivar
                        </DropdownMenuItem>
                        <DropdownMenuItem className="text-destructive" onClick={props.OnDelete}>
                            Borrar
                        </DropdownMenuItem>
                    </DropdownMenuGroup>
                </DropdownMenuContent>
            </DropdownMenu>
        </div>
    );
}

const UserTag = (props: {name: string}) => {
    return (
        <Badge className='flex gap-2' variant='secondary'>
            <User/>
            {props.name}
        </Badge>
    );
}

