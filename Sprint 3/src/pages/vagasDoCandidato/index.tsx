import React, { useState, useEffect } from 'react';
import Header from '../../components/header/index';
import './style.css';
import '../../assets/styles/global.css'
import Menu from '../../components/menu';
import { parseJwt } from '../../auth'
import CardFinal from '../../components/cardFinal';
import '../../assets/styles/global.css'


function CandidatoVaga() {

    const [vagas, setVagas] = useState([]);

    let tokenDecode = parseJwt();

    let idCandidato = parseInt(tokenDecode.jti)

    useEffect(() => {
        ListarInscricaoPorCandidato(idCandidato);
    }, []);

    const ListarInscricaoPorCandidato = (id: number) => {
        fetch('http://localhost:5000/api/Inscricao/inscricaoCandidato/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setVagas(dados);
                console.log(vagas);
            })
            .catch(err => console.error(err));
    }

    return (
        <div>
            <Header />
            <div className='UsuarioLogado'>
                <Menu title='' />

                <div className='tela_principal_usuario_Naologado'>
                        <h2>Minhas Candidaturas</h2>
                    <div className='cardTodasVagas'>
                        {
                            vagas.map((item: any) => {
                                return <div className='CardVagas'>
                                    <CardFinal nomeVaga={item.idVagaNavigation.nomeVaga} hardSkills={item.idVagaNavigation.hardSkills} softSkills={item.idVagaNavigation.softSkills} qualificacaoProfissional={item.idVagaNavigation.qualificacaoProfissional} nivelExperiencia={item.idVagaNavigation.nivelExperiencia} setor={item.idVagaNavigation.setor} salario={item.idVagaNavigation.salario} beneficios={item.idVagaNavigation.beneficios}/>
                                </div>
                            })
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CandidatoVaga;