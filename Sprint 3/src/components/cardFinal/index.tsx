import React, { InputHTMLAttributes, SelectHTMLAttributes } from 'react';
import Button from '../button';
import './style.css';

interface CardProps extends InputHTMLAttributes<HTMLInputElement> {
    nomeVaga: any;
    hardSkills: any;
    softSkills: any;
    qualificacaoProfissional: any;
    nivelExperiencia: any;
    setor: any;
    salario: any;
    beneficios: any;
}

const CardFinal: React.FC<CardProps> = ({ nomeVaga, hardSkills, softSkills, qualificacaoProfissional, nivelExperiencia, setor, salario, beneficios, ...rest }) => {
    return (
        <div>
            <div className="cardFinal12">
                <h3><b>{nomeVaga}</b></h3>
                <h4>Hardskills</h4>
                <p>{hardSkills}</p>
                <h4>Softskills</h4>
                <p>{softSkills}</p>
                <h4>Qualificações Profissionais</h4>
                <p>{qualificacaoProfissional}</p>
                <h4>Nivel de experiência</h4>
                <p>{nivelExperiencia}</p>
                <h4>Setor</h4>
                <p>{setor}</p>
                <h4>Salário</h4>
                <p>{salario}</p>
                <h4>Benefícios</h4>
                <p>{beneficios}</p>
            </div>
        </div>
    )
}

export default CardFinal;