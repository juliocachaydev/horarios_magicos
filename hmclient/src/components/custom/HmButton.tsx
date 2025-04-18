import HmButtonWrapper from "@/components/custom/button/HmButtonWrapper.tsx";
import { Button } from "@/components/ui/button"

export type HmButtonProps = {
    disabled?: boolean;
    onClick?: () => void;
    onClickAsync?: () => Promise<void>;
}

export type HmButtonSolidProps = HmButtonProps & {
    variant: 'default' | 'secondary'
    text: string;
    icon?: React.ReactNode;
}



export const HmButtonSolid = (props: HmButtonSolidProps) =>{

    const variant = props.variant == 'default' ? 'default' : 'secondary'

    return (
        <HmButtonWrapper disabled={props.disabled ?? false}
                         onClick={props.onClick}
                         onClickAsync={props.onClickAsync}>
            <Button variant={variant} disabled={props.disabled ?? false}>
                {props.icon}
                {props.text}</Button>
        </HmButtonWrapper>
    )
}