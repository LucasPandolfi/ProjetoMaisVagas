import React, { useState, useEffect } from 'react';
import Header from '../../components/header/index';
import Input from '../../components/input';
import Menu from '../../components/menu/index';
import Cards from '../../components/card/Index';
import './style.css';
import '../../assets/styles/global.css';
import Select from '../../components/select';
import Card from '../../components/card/Index';
import Button from '../../components/button/index';
import { useHistory } from 'react-router-dom';
import { parseJwt } from '../../auth'




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
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(dados => {
                setVagas(dados);
                console.log(vagas)
            })
            .catch(err => console.error(err));
    }

    function Alerta(){
        alert('Para visualizar os detalhes da vaga, você precisar estar logado!')
    }

    return (
        <div>
            <Header />

            <div className='UsuarioNaoLogado'>
                <Menu title='' />

                <div className='telausuarionaologado'>

                    <div className='inputtelausuarionaologado'>
                        <Input type='text' namePlaceholder='Empresa/Profissão' label='O quê:' MinLengh='2' MaxLengh='20' />

                        <div className='selectcolumn1'>
                            <Select name='' label='Porte da Empresa:' nameOpcao='Grande' nameOpcao1='Media' nameOpcao2='Pequena' />
                        </div>

                        <Input type='text' namePlaceholder='Cidade' label='Localização:' MinLengh='2' MaxLengh='20' />
                    </div>

                    <div >
                        <div className='selectusuarionaologado'>
                            <Select name='' label='Area de Interesse:' nameOpcao='Desenvolvimento' nameOpcao1='Design' nameOpcao2='Redes' />
                            <Select name='' label='Ordenar Vagas Por:' nameOpcao='Mais Recente' nameOpcao1='Mais antigas' nameOpcao2='' />
                            <Select name='' label='Piso Salarial:' nameOpcao='2.000 á 3.000' nameOpcao1='3.000 á Mais' nameOpcao2='1.000 á 2.000' />

                        </div>


                    </div>

                    <div className='cardusuarionaologado'>

                        <div className='cardTodasVagas'>
                            {
                                vagas.map((item: any) => {
                                    return <div className='CardVagas'>
                                        <button onClick={Alerta}><Card titulo={item.nomeVaga} sub_titulo={item.qualificacaoProfissional} sub_titulo2='Brasilia, Brasil' value='Detalhes' /></button>
                                    </div>
                                })
                            }
                        </div>

                    </div>


                </div>


            </div>

        </div>
    )


}
export default TelaHomeNaoLogado;