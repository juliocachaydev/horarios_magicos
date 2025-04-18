import {ReactNode} from "react";

export type HmButtonWrapperProps = {
    onClick?: () => void;
    onClickAsync?: () => Promise<void>;
    children: ReactNode;
    disabled: boolean;
}

const HmButtonWrapper = (props: HmButtonWrapperProps) => {

    const className = () => {
        const result : string[] = [];
        if (props.disabled)
        {
            result.push('cursor-not-allowed');
        } else
        {
            result.push('cursor-pointer');
        }
        result.push('inline-block')
        return result.join(' ');
    }
    const handleClick = async () => {
        if (props.disabled)
        {
            return;
        }
        if (props.onClickAsync)
        {
            await props.onClickAsync();
        }
        else if (props.onClick)
        {
            props.onClick();
        }
    }
    return (
        <div onClick={handleClick} className={className()}>
            {props.children}
        </div>
    )
}

export default HmButtonWrapper;