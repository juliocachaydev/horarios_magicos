import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
} from "@/components/ui/card"
import {
    Progress
} from "@/components/ui/progress"
import {
    DropdownMenu, DropdownMenuContent,
    DropdownMenuTrigger,
    DropdownMenuGroup,
    DropdownMenuItem
} from "@/components/ui/dropdown-menu.tsx";
import { Badge } from "@/components/ui/badge";
import { Menu, User } from "lucide-react"

import { Button } from "@/components/ui/button"
import {useEffect, useState, useRef} from "react";
import {Textarea} from "@/components/ui/textarea.tsx";
import { Input } from "@/components/ui/input"

export type ProjectCardProps = {
    projectId: string;
    name: string;
    description: string;
    owner: string;
    progress: number;
    onOpen: (projectId: string) => Promise<void>;
    onUpdate: (projectId: string, name: string) => Promise<void>;
}

const ProjectCard = (props: ProjectCardProps) => {
    const [editMode, setEditMode] = useState(false);
    const ref = useRef<HTMLDivElement>(null);

    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (ref.current && !ref.current.contains(event.target as Node)) {
                setEditMode(false);
            }
        }
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        }
    }, [ref]);

    const progressValue = (() =>{
        if (props.progress < 5)
        {
            return 5;
        }
        if (props.progress >=99)
        {
            return 100;
        }
        return props.progress;
    })();

    const enterEditMode = () => {
        setEditMode(true);
    }

    if (!editMode)
    {
        return (
            <Card className='w-[350px]'>
                <CardHeader>
                    <CardTitle className='flex justify-between items-center-safe'>
                        {props.name}
                        <ProjectMenu OnUpdate={() => {}} OnArchive={() => {}} OnDelete={() => {}}/></CardTitle>
                    <CardDescription onClick={enterEditMode}>{props.description}</CardDescription>
                </CardHeader>
                <CardContent>
                    <UserTag name={props.owner}/>
                    <Progress value={progressValue}></Progress>
                </CardContent>
            </Card>
        )
    }
    return (
        <Card ref={ref} className='w-[350px]'>
            <CardHeader>
                <CardTitle className='flex justify-between items-center-safe'>
                    <Input value={props.name}/><ProjectMenu disabled OnUpdate={() => {}} OnArchive={() => {}} OnDelete={() => {}}/></CardTitle>
                <Textarea placeholder='descripcion...'>{props.description}</Textarea>
            </CardHeader>
            <CardContent>
                <UserTag name={props.owner}/>
                <Progress value={progressValue}></Progress>
            </CardContent>
        </Card>
    )
}

const UserTag = (props: {name: string}) => {
    return (
        <Badge className='flex gap-2' variant='secondary'>
            <User/>
            {props.name}
        </Badge>
    );
}

type ProjectMenuProps = {
    disabled: boolean;
    OnUpdate: () => void;
    OnArchive: () => void;
    OnDelete: () => void;
}

const ProjectMenu = (props: ProjectMenuProps) => {
    return (
        <DropdownMenu>
            <DropdownMenuTrigger asChild>
                <Button variant="outline" size="icon" disabled={props.disabled}>
                    <Menu />
                </Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent>
                <DropdownMenuGroup>
                    <DropdownMenuItem onClick={props.OnUpdate}>
                        Modificar
                    </DropdownMenuItem>
                    <DropdownMenuItem onClick={props.OnArchive}>
                        Archivar
                    </DropdownMenuItem>
                    <DropdownMenuItem className="text-destructive" onClick={props.OnDelete}>
                        Borrar
                    </DropdownMenuItem>
                </DropdownMenuGroup>
            </DropdownMenuContent>
        </DropdownMenu>
    );
}

export default ProjectCard;