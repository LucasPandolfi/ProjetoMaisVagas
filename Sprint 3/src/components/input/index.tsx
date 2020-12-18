import React, {InputHTMLAttributes} from 'react';
import { Interface } from 'readline';
import './style.css';

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
    label:string;
    namePlaceholder:any;
    MaxLengh:any;
    MinLengh:any;
}

const Input:React.FC<InputProps> = ({name, label, MaxLengh, MinLengh ,namePlaceholder, ...rest}) =>{
    return(
        <div>
             <label htmlFor={name}>{label}</label><br/>
            <input className='inputPadrao' type='text' minLength={MinLengh} maxLength={MaxLengh} placeholder={namePlaceholder} id={name}{...rest}/>
        </div>
    )
}

export default Input;