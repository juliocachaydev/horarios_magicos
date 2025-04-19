import {
    AlertDialog,
    AlertDialogAction,
    AlertDialogCancel,
    AlertDialogContent,
    AlertDialogDescription,
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogTitle
} from "@/components/ui/alert-dialog"
import {useState} from "react";

import {Input} from "@/components/ui/input.tsx";

export type ConfirmDeleteDialogProps = {
    onConfirm: () => Promise<void>;
    onCancel?: () => void;
    confirmKeyword?: string;
    open: boolean;
    title: string;
    description: string;
}

export default function ConfirmDeleteDialog(
    props: ConfirmDeleteDialogProps)
{
    const [confirmKeywordValue, setConfirmKeywordValue] = useState<string>('');

    const confirmDisabled = (props.confirmKeyword != undefined &&
        props.confirmKeyword !== confirmKeywordValue) ?? false;

    return (
        <AlertDialog open={props.open}>
            <AlertDialogContent>
                <AlertDialogHeader>
                    <AlertDialogTitle>{props.title}</AlertDialogTitle>
                    <AlertDialogDescription>
                        {props.description}
                    </AlertDialogDescription>
                    {props.confirmKeyword && <Input value={confirmKeywordValue} onChange={e=>
                    setConfirmKeywordValue(e.target.value)}/>}
                </AlertDialogHeader>
                <AlertDialogFooter>
                    <AlertDialogCancel onClick={props.onCancel}>Cancel</AlertDialogCancel>
                    <AlertDialogAction className={'bg-red-500 text-white'}
                    onClick={props.onConfirm}
                    disabled={confirmDisabled}
                    >Borrar</AlertDialogAction>
                </AlertDialogFooter>
            </AlertDialogContent>
        </AlertDialog>
    );
}