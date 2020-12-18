import React, {useState, useEffect} from 'react';
import Header from '../../components/header/index';
import './style.css';
import '../../assets/styles/global.css'
import Button from '../../components/button/index';
import Menu from '../../components/menu';
import Card3b from '../../components/card3b/index';
import { parseJwt } from '../../auth';
import Card3B from '../../components/card3b'


function HomeEmpresa() {

    const [vagas, setVagas] = useState([]);

    let tokenDecode = parseJwt();

    let idEmpresa = parseInt(tokenDecode.jti)
    

    useEffect(() => {
        listarVagaPorEmpresa(idEmpresa);
    }, []);


    const listarVagaPorEmpresa = (id: number) => {
        fetch('http://localhost:5000/api/Vaga/EmpresaVagas/' + id, {
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

            <div className='menu_adm'>
                <Menu title='' />
                <div className="principal_home_adm">
                    <h1 className='H1'>Suas Vagas</h1>
                    <div className='cardTodasVagas'>
                        {
                            vagas.map((item: any) => {
                                return <div className='CardVagas'>
                                    <Card3B titulo={item.nomeVaga} sub_titulo={item.qualificacaoProfissional} value='Candidatos' value1='Atualizar' value2='excluir'/>
                                </div>
                            })
                        }
                    </div>
                    <div className='btn_pendente'>
                        <Button value='Pendentes' name='btn_pendentes' />
                    </div>
                </div>
            </div>
        </div>
    );
}

export default HomeEmpresa;