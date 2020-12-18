import React, { useState, useEffect } from 'react';
import Input from '../../components/input';
import Button from '../../components/button/index'
import LogoSenaiVer from '../../assets/images/logosenaiver.jpg';
import LogoMaisVagas from '../../assets/images/logomaisvagas.jpg';
import voltar from '../../assets/images/voltar.png';
import Select from '../../components/select/index';
import './style.css';
import { Link } from 'react-router-dom'
import { parseJwt } from '../../auth';

function CadastroVaga() {

    const [vaga, setVaga] = useState('');
    const [idVaga, setIdVaga] = useState(0);

    const [empresa, setEmpresa] = useState('');
    const [idEmpresa, setIdEmpresa] = useState(0);

    const [usuario, setUsuario] = useState('');
    const [idUsuario, setIdUsuario] = useState(0);

    const [tipoContrato, setTipoContrato] = useState('');
    const [idTipoContrato, setIdTipoContrato] = useState('');
    const [tipoContratos, setTipoContratos] = useState([])

    //variaveis 
    const [nomeVaga, setNomeVaga] = useState('');
    const [descricaoVaga, setDescricaoVaga] = useState('');
    const [softSkills, setSoftSkills] = useState('');
    const [hardSkills, setHardSkills] = useState('');
    const [qualificacaoProfissional, setQualificacaoProfissional] = useState('');
    const [numeroVagaDisponiveis, setNumeroVagaDisponiveis] = useState('');
    const [nivelExperiencia, setNivelExperiencia] = useState('');
    const [jornada, setJornada] = useState('');
    const [setor, setSetor] = useState('');
    const [salario, setSalario] = useState('');
    const [beneficios, setBeneficios] = useState('');
    //preciso apagar as vagas cadastradas no sistema para deletar os tipos contrato e adicionar de forma decente


    let tokenDecode = parseJwt();
    useEffect(() => {
        ListarTipoContratos()
    }, [])

    const CadastrarVaga = () => {
        const form = {
            idEmpresa: parseInt(tokenDecode.jti),
            nomeVaga: nomeVaga,
            descricaoVaga: descricaoVaga,
            softSkills: softSkills,
            hardSkills: hardSkills,
            qualificacaoProfissional: qualificacaoProfissional,
            numeroVagaDisponiveis: numeroVagaDisponiveis,
            nivelExperiencia: nivelExperiencia,
            jornada: jornada,
            setor: setor,
            salario: parseInt(salario),
            beneficios: beneficios,
            idTipoContrato: parseInt(tipoContrato),
            IdNavigationTipoContrato: {
                idTipoContrato: parseInt(tipoContrato)
            }
        };
        console.log(form)
        fetch("http://localhost:5000/api/Vaga", {
            method: 'POST',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                // mudar o token
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(() => {
                setIdEmpresa(0);
                setNomeVaga('');
                setDescricaoVaga('');
                setSoftSkills('');
                setHardSkills('');
                setQualificacaoProfissional('');
                setNumeroVagaDisponiveis('');
                setNivelExperiencia('');
                setJornada('');
                setSetor('');
                setSalario('');
                setBeneficios('');
                alert('Vaga Cadastrada Com Sucesso!');
            })
            .catch(err => console.error(err));
    }

    const ListarTipoContratos = () => {
        fetch('http://localhost:5000/api/TipoContrato', {
            method: 'GET',
            headers: {

                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setTipoContratos(dados);
                console.log(dados)
            })
            .catch(err => console.error(err));
    }

    return (
        <div>
            <div className="voltar1">
                <Link to='/homeEmpresa'><img src={voltar} alt="voltar" width="40" height="40" /></Link>
            </div>
            <div className="imggus1">
                <img src={LogoMaisVagas} alt="logo do senai" width="150" height="67" />
            </div>
            <div className="texto1">
                <h3>Cadastro de Vagas</h3>
            </div>
            <form onSubmit={event => {
                event.preventDefault();
                CadastrarVaga();
            }}>
                <div className="caixapai1">
                    <div className="caixa5">
                        <Input name="Nome vaga" namePlaceholder="Nome da vaga" label="" MinLengh='2' MaxLengh='110' value={nomeVaga} onChange={e => setNomeVaga(e.target.value)} />
                        <Input name="Qualificações Profissionais" namePlaceholder="Qualificações Profissionais" label="" MinLengh='2' MaxLengh='100' value={qualificacaoProfissional} onChange={e => setQualificacaoProfissional(e.target.value)} />
                        <Input name="Numero de Vagas Disponiveis" namePlaceholder="Numero de Vagas Disponiveis" label="" MinLengh='2' MaxLengh='11' value={numeroVagaDisponiveis} onChange={e => setNumeroVagaDisponiveis(e.target.value)} />
                        <Input name="Descrição Vaga" namePlaceholder="Descrição Da Vaga" label="" MinLengh='2' MaxLengh='255' value={descricaoVaga} onChange={e => setDescricaoVaga(e.target.value)} />
                        <Input name="Setor" namePlaceholder="Setor" label="" MinLengh='2' MaxLengh='100' value={setor} onChange={e => setSetor(e.target.value)} />
                        <Input name="Nivel experiencia" namePlaceholder="Nível experiência" label="" MinLengh='2' MaxLengh='15' value={nivelExperiencia} onChange={e => setNivelExperiencia(e.target.value)} />
                    </div>
                    <div className="caixa6">
                        <Input name="SoftSkills Desejadas" namePlaceholder="SoftSkills Desejadas" label="" MinLengh='2' MaxLengh='60' value={softSkills} onChange={e => setSoftSkills(e.target.value)} />
                        <Input name="HardSkills Desejadas" namePlaceholder="HardSkills Desejadas" label="" MinLengh='2' MaxLengh='60' value={hardSkills} onChange={e => setHardSkills(e.target.value)} />
                        <br />
                        <select name="tipo contrato" onChange={e => setTipoContrato(e.target.value)} value={tipoContrato}>
                            <option value="0">Tipo de Contrato:</option>
                            {
                                tipoContratos.map((item: any) => {
                                    return <option value={item.idTipoContrato}>{item.nome}</option>
                                })
                            }
                        </select>
                        <Input name="Salario" namePlaceholder="Salario" label="" MinLengh='2' MaxLengh='15' value={salario} onChange={e => setSalario(e.target.value)} />
                        <Input name="Beneficios" namePlaceholder="Beneficios" label="" MinLengh='2' MaxLengh='100' value={beneficios} onChange={e => setBeneficios(e.target.value)} />
                        <Input name="jornada" namePlaceholder="Jornada" label="" MinLengh='2' MaxLengh='15' value={jornada} onChange={e => setJornada(e.target.value)} />
                    </div>
                </div>
                <div className="botao6">
                    {
                        <Button value="Cadastrar" name="Cadastrar" />
                    }
                </div>
            </form>
            <div className="logosenai6">
                <img src={LogoSenaiVer} alt="logo do senai" width="200" height="70" />
            </div>
        </div>
    )
}

export default CadastroVaga