import React, { useState, useEffect } from 'react'
import Header from '../../components/header/index'
import Input from '../../components/input'
import Menu from '../../components/menu/index'
import Cards from '../../components/card/Index'
import './style.css'
import '../../assets/styles/global.css'
import Select from '../../components/select'
import Card from '../../components/card/Index'
import Button from '../../components/button/index'
import { useHistory } from 'react-router-dom';


function TelaHomeNaoLogado() {
    const [idVaga, setIdVaga] = useState(0);
    const [vaga, setVaga] = useState('');

    const [vagas, setVagas] = useState([]);

    const history = useHistory();

    useEffect(() => {
        ListarVagas();
    }, []);

    const ListarVagas = () => {
        fetch('http://localhost:5000/api/Vaga', {
            method: 'GET',
            headers: {

                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setVagas(dados);
                console.log(vagas)
            })
            .catch(err => console.error(err));
    }

    const visualizarVaga = (id: number) => {

        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setIdVaga(dados.idVaga);
                console.log(id);
                // localStorage.setItem( 'IdVaga', String(idVaga))
                history.push(`/visualizarDetalhesDaVaga?id=${id}`)
            })
            .catch(err => console.error(err));
    }

    return (
        <div>
            <Header />

            <div className='UsuarioLogado'>
                <Menu title='' />

                <div className='tela_principal_usuario_logado'>
                    <div className="filtro_Select">
                        <div className='input_telausuario_logado'>
                            <Input type='text' namePlaceholder='Empresa/Profissão' label='O quê:' MinLengh='2' MaxLengh='25' />

                            <div className='select_column1'>
                                <Select name='' label='Porte da Empresa:' nameOpcao='Grande' nameOpcao1='Media' nameOpcao2='Pequena' />
                            </div>

                            <Input type='text' namePlaceholder='Cidade' label='Localização:' MinLengh='2' MaxLengh='25' />
                        </div>

                            <div className='select_usuario_logado'>
                                <Select name='' label='Area de Interesse:' nameOpcao='Desenvolvimento' nameOpcao1='Design' nameOpcao2='Redes' />
                                <Select name='' label='Ordenar Vagas Por:' nameOpcao='Mais Recente' nameOpcao1='Mais antigas' nameOpcao2='' />
                                <Select name='' label='Piso Salarial:' nameOpcao='2.000 á 3.000' nameOpcao1='3.000 á Mais' nameOpcao2='1.000 á 2.000' />
                            </div>
                    </div>

                    <div className='cardTodasVagas'>
                        {
                            vagas.map((item: any) => {
                                return <div className='CardVagas'>
                                    <button id='btn_card_' onClick={() => visualizarVaga(item.idVaga)}><Card titulo={item.nomeVaga} sub_titulo={item.qualificacaoProfissional} sub_titulo2='Brasilia, Brasil' value='Detalhes' /></button>
                                </div>
                            })
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}
export default TelaHomeNaoLogado;