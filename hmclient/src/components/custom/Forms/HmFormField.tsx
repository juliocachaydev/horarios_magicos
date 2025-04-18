import {ReactNode} from "react";

export type HmFormFieldProps = {
    errors?: string;
    children: ReactNode;
}

const HmFormField = (props: HmFormFieldProps) => {
    return (
        <div className='flex flex-col gap-1'>
            {props.children}
            {props.errors && <em role="alert"
            className='text-red-700'>{props.errors}</em>}
    </div>)
}

export default HmFormField;