import React, { InputHTMLAttributes, SelectHTMLAttributes } from 'react';
import Button from '../button';
import './style.css';

interface CardProps extends InputHTMLAttributes<HTMLInputElement> {
    titulo: any;
    sub_titulo: any;
    value: string;
    value1: string;
    value2: string;
}

const Card3b: React.FC<CardProps> = ({ titulo, sub_titulo, value, value1, value2, ...rest }) => {
    return (
        <div className="pai">
            <div className="card3b">
                <h4><b>{titulo}</b></h4>
                <p>{sub_titulo}</p>
                <div className="btn_card">
                    <div className="button1">
                    <Button value={value} name='name' />
                    </div>
                    <div className="btn_card2">
                        <Button value={value1} name="name" />
                        <Button value={value2} name="name" />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Card3b;

