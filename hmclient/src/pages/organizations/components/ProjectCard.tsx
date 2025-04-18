import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
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
    return (
        <Card className='w-[350px]'>
            <CardHeader>
                <CardTitle className='flex justify-between items-center-safe'>{props.name}<ProjectMenu OnUpdate={() => {}} OnArchive={() => {}} OnDelete={() => {}}/></CardTitle>
                <CardDescription>{props.description}</CardDescription>
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
    OnUpdate: () => void;
    OnArchive: () => void;
    OnDelete: () => void;
}

const ProjectMenu = (props: ProjectMenuProps) => {
    return (
        <DropdownMenu>
            <DropdownMenuTrigger asChild>
                <Button variant="outline" size="icon">
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