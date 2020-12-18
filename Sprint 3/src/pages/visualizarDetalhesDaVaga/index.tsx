import React, { useState, useEffect } from 'react';
import Header from '../../components/header/index';
import './style.css';
import '../../assets/styles/global.css'
import Button from '../../components/button/index';
import Menu from '../../components/menu';
import Card3b from '../../components/card3b/index';
import CardGrandeVaga from '../../components/cardgrandevaga/index'
import './style.css'
import { useHistory } from 'react-router-dom'
import { parseJwt } from '../../auth'


function VizualizarDetalhesDaVaga() {
    const [vagas, setVagas] = useState([]);
    const [idVaga, setIdVaga] = useState(0);
    const history = useHistory();

    const [candidato, setCandidato] = useState('');
    const [idCandidato, setIdCandidato] = useState(0);

    const [idInscricao, setIdInscricao] = useState(0);


    //variaveis
    const [idEmpresa, setIdEmpresa] = useState('');
    const [nomeEmpresa, setNomeEmpresa] = useState('');
    const [nomeVaga, setNomeVaga] = useState('');
    const [descricaoVaga, setDescricaoVaga] = useState('');
    const [hardSkills, setHardSkills] = useState('');//
    const [softSkills, setSoftSkills] = useState('');//
    const [qualificacaoProfissional, setQualificacaoProfissional] = useState('');
    const [numeroVagaDisponiveis, setNumeroVagaDisponiveis] = useState('');//
    const [nivelExperiencia, setNivelExperiencia] = useState('');
    const [jornada, setJornada] = useState('');
    const [setor, setSetor] = useState('');
    const [salario, setSalario] = useState('');
    const [beneficios, setBeneficios] = useState('');

    // const [tipoEmprego, setTipoEmprego] = useState('');

    const queryString = window.location.search;

    const urlParams = new URLSearchParams(queryString);

    const id = urlParams.get('id');
    let tokenDecode = parseJwt();
    useEffect(() => {
        DetalhesVaga()
        
    }, [])

    const salvarCandidatura = () => {
        const form = {
            idCandidato: parseInt(tokenDecode.jti),
            idVaga: idVaga
            
        };
        console.log(form)
        fetch("http://localhost:5000/api/Inscricao", {
            method: 'POST',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                // mudar o token
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(() => {
                setIdCandidato(0);
                setIdVaga(0);
                setIdInscricao(0);
                alert('Candidatura Efetuada Com Sucesso');
            })
            .catch(err => console.error(err));
    }

    

    const DetalhesVaga = () => {

        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setIdVaga(dados.idVaga);
                setIdEmpresa(dados.idEmpresa);
                setNomeVaga(dados.nomeVaga);
                setDescricaoVaga(dados.descricaoVaga);
                setHardSkills(dados.hardSkills);
                setSoftSkills(dados.softSkills);
                setQualificacaoProfissional(dados.qualificacaoProfissional);
                setNumeroVagaDisponiveis(dados.numeroVagaDisponiveis);
                setNivelExperiencia(dados.nivelExperiencia);
                setJornada(dados.jornada);
                setSetor(dados.setor);
                setSalario(dados.salario);
                setBeneficios(dados.beneficios);
                console.log(dados);

                fetch('http://localhost:5000/api/Empresa/' + dados.idEmpresa, {
                    method: 'GET',
                    headers: {
                        authorization: 'Bearer ' + localStorage.getItem('token')
                    }
                })
                    .then(resp => resp.json())
                    .then(dados => {
                        setNomeEmpresa(dados.nomeEmpresa);
                    })
                    .catch(err => console.error(err));
            })
            .catch(err => console.error(err));
    }


    return (
        <div>
            <Header />

            <div className='menu_adm'>
                <Menu title='' />
                <div className='card1'>
                    <div className="detalhesvaga">
                        <form onSubmit={event => {
                            event.preventDefault();
                            salvarCandidatura();
                        }}>
                            <CardGrandeVaga
                                NomeEmpresa={nomeEmpresa}
                                NomeVaga={nomeVaga}
                                DescricaoVaga={descricaoVaga}
                                HardSkills={hardSkills}
                                SoftSkills={softSkills}
                                QualificacaoProfissional={qualificacaoProfissional}
                                NumeroVagaDisponiveis={numeroVagaDisponiveis}
                                NivelExperiencia={nivelExperiencia}
                                Jornada={jornada}
                                Setor={setor}
                                Salario={salario}
                                Beneficios={beneficios}

                                value='Candidatar-se'/> 
                                
                        </form>
                    </div>

                </div>

            </div>
        </div>
    );
}

export default VizualizarDetalhesDaVaga;