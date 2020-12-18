import React, { ButtonHTMLAttributes } from 'react';
import './style.css';

interface ButtonMaiorProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    value: string;
    img: any;
}

const Button_Maior: React.FC<ButtonMaiorProps> = ({ value, img }) => {
    return (
        <div>
            <div className='card_btn'>
                <img src={img} />
                <h1 className='btn_maior'>{value}</h1>
            </div>
        </div>
    );
}

export default Button_Maior;