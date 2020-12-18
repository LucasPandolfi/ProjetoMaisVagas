import React, {ButtonHTMLAttributes} from 'react';
import './style.css'

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement>{
    value: string;
    name: string;
}

const Button:React.FC<ButtonProps> = ({value, name}) =>{
    return(
        <div>
           <input className=' btnPadrao' type='submit' value={value} id={name}/>           
        </div>
    );
}

export default Button;