import React, { InputHTMLAttributes, SelectHTMLAttributes } from 'react';
import Button from '../button';
import './style.css';

interface CardProps extends InputHTMLAttributes<HTMLInputElement> {
    titulo: any;
    sub_titulo: any;
    sub_titulo2: any;
    value: string;
    Onclick?: any; 
}

const Card: React.FC<CardProps> = ({ titulo, sub_titulo, sub_titulo2, value, Onclick,...rest }) => {
    return (
        <div className="pai">
            <div className="cardnormal">
                <h4><b>{titulo}</b></h4>
                <p>{sub_titulo}</p>
                <p>{sub_titulo2}</p>

                <div className="btn_card">
                    <Button value={value} name='name' onClick={Onclick}/>
                </div>
            </div>
        </div>
    )
}

export default Card;

