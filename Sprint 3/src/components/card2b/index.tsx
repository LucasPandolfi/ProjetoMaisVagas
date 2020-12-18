import React, { InputHTMLAttributes, SelectHTMLAttributes } from 'react';
import Button from '../button';
import './style.css';

interface CardProps extends InputHTMLAttributes<HTMLInputElement> {
    titulo: any;
    value1: any;
    value2: any;

}

const Card2b: React.FC<CardProps> = ({ titulo,  value1, value2, ...rest }) => {
    return (
        <div className="pai">
            <div className="card2b">
                <h4><b>{titulo}</b></h4>
                <div className="btn_card">

                    <div className="btn_card2">
                        <Button value={value1} name="name" />
                        <Button value={value2} name="name" />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Card2b;

