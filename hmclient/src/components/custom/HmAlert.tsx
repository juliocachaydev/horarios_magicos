import { X, Info } from 'lucide-react';
import {
    Alert,
    AlertDescription
} from "@/components/ui/alert.tsx";
import { useState } from 'react';
import {cn} from "@/lib/utils.ts";

export type HmAlertProps = {
    className?: string;
    message: string;
}

const HmAlert = (props: HmAlertProps) => {
    const {message} = props;
    const [open, setOpen] = useState(true);

    if (!open)
    {
        return null;
    }

    const className = cn('bg-blue-50 border-blue-200 flex justify-between', props.className);
    return (
        <Alert variant='default'
               className={className}>
            <div className='flex gap-4 items-center'>
                <Info className='text-blue-400'/>
                <AlertDescription className='text-black'>{message}</AlertDescription>
            </div>
            <X onClick={() => setOpen(false)} className='cursor-pointer'/>
        </Alert>
    )

}

export default HmAlert;