import { X, Info } from 'lucide-react';
import {
    Alert,
    AlertDescription
} from "@/components/ui/alert.tsx";
import { useState } from 'react';

export type HmAlertProps = {
    message: string;
}

const HmAlert = (props: HmAlertProps) => {
    const {message} = props;
    const [open, setOpen] = useState(true);

    if (!open)
    {
        return null;
    }
    return (
        <Alert variant='default'
               className='bg-blue-50 border-blue-200 flex justify-between'>
            <div className='flex gap-4 items-center'>
                <Info className='text-blue-400'/>
                <AlertDescription className='text-black'>{message}</AlertDescription>
            </div>
            <X onClick={() => setOpen(false)} className='cursor-pointer'/>
        </Alert>
    )

}

export default HmAlert;