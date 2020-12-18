import React, { InputHTMLAttributes, SelectHTMLAttributes } from 'react';
import Button from '../button';
import './style.css';

interface CardProps extends InputHTMLAttributes<HTMLInputElement> {
    NomeEmpresa: any;
    NomeVaga: any;
    DescricaoVaga: any;
    HardSkills: any;
    SoftSkills: any;
    QualificacaoProfissional: any;
    NumeroVagaDisponiveis: any;
    NivelExperiencia: any;
    Jornada: any;
    Setor: any;
    Salario: any;
    Beneficios: any;
    value: string;
}

const CardGrandeVaga: React.FC<CardProps> = ({ NomeEmpresa, NomeVaga, DescricaoVaga, HardSkills, SoftSkills, QualificacaoProfissional, NumeroVagaDisponiveis, NivelExperiencia, Jornada, Setor, Salario, Beneficios, value, ...rest }) => {
    return (
        <div>
            <div className="pai_">
                <div className="card_VisualizarDetalhesVaga">

                    <h3><b>{NomeEmpresa}</b></h3>
                    <h3><b>{NomeVaga}</b></h3>
                    <div className="titulo_descricao_cardGrande">
                        <h4>Descrição</h4>
                        <p>{DescricaoVaga}</p>
                    </div>

                    <div className='colunas_Principais'>
                        <div className='coluna_Esquerda'>
                            <div className="HardSkill_">
                                <h4>HardSkills</h4>
                                <p>{HardSkills}</p>
                            </div>
                            <div className="SoftSkill_">
                                <h4>SoftSkills</h4>
                                <p>{SoftSkills}</p>
                            </div>
                            <div className="QualificacaoProfissional_">
                                <h4>Qualificações Profissionais</h4>
                                <p>{QualificacaoProfissional}</p>
                            </div>
                            <div className="NumeroVagasDisponiveis_">
                                <h4>Número de vagas disponíveis</h4>
                                <p>{NumeroVagaDisponiveis}</p>
                            </div>
                            <div className="NivelExperiencia_">
                                <h4>Nível de experiência</h4>
                                <p>{NivelExperiencia}</p>
                            </div>
                        </div>

                        <div className='coluna_Direita'>
                        <div className="Jornada_">
                                <h4>Jornada</h4>
                                <p>{Jornada}</p>
                            </div>
                            <div className="Setor_">
                                <h4>Setor</h4>
                                <p>{Setor}</p>
                            </div>
                            <div className="Salário_">
                                <h4>Salario</h4>
                                <p>{Salario}</p>
                            </div>
                            <div className="Beneficio_">
                                <h4>Benefícios</h4>
                                <p>{Beneficios}</p>
                            </div>
                        </div>
                    </div>

                    <div className="btn_card_">
                        <Button value={value} name='name' />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CardGrandeVaga;
