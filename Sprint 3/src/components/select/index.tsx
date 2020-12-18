import React, { InputHTMLAttributes, SelectHTMLAttributes } from 'react';
import './style.css';

interface SelectProps extends InputHTMLAttributes<HTMLInputElement> {
    label: any;
    name: any;
    nameOpcao: any;
    nameOpcao1: any;
    nameOpcao2: any;
}

const Select: React.FC<SelectProps> = ({label,name, nameOpcao, nameOpcao1, nameOpcao2, ...rest }) => {
    return (
        <div>
            <label htmlFor={name}>{label}</label><br/>
            <select name='' id="default">
                <option value=''>{nameOpcao2}</option>
                <option value="Renan">{nameOpcao}</option>
                <option value="Gabi">{nameOpcao1}</option>
                
            </select>
        </div>
    )
}
export default Select;