import React, { useState } from 'react';
import '../../assets/styles/global.css'
import './style.css';
import Header from '../../components/header/index';
import Menu from '../../components/menu/index';
import Input from '../../components/input';
import Button from '../../components/button/index';
import { Link } from 'react-router-dom';
import LogoPrincipal from '../../assets/images/logomaisvagas.jpg';
import LogoSenai from '../../assets/images/logosenaiver.jpg';
import { useHistory } from 'react-router-dom';
import { parseJwt } from '../../auth'

function Login() {
    let history = useHistory();

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const login = () => {
        const infoLogin = {
            email: email,
            senha: senha
        };

        fetch('http://localhost:5000/api/login', {
            method: 'POST',
            body: JSON.stringify(infoLogin),
            headers: {
                'content-type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(dados => {
                if (dados.token != undefined) {
                    localStorage.setItem('token', dados.token)

                    if(parseJwt().Role === 'Empresa'){
                        history.push('/homeEmpresa');
                    }

                    if(parseJwt().Role === 'Candidato'){
                        history.push('/telaHomeLogado');
                    }

                    if(parseJwt().Role === 'Administrador'){
                        history.push('/homeAdministrador');
                    }
                }
                else {
                    alert('Senha ou Email invalidos');
                }
            })
            .catch(error => console.error(error));
    }


    return (
        <div>
            <div className="principal_login">

                <div className="esquerda_vermelha">
                    <h2>Encontre o emprego dos seus sonhos de forma rápida e gratuita. Mais vagas feito para você!</h2>
                </div>
                <div className="body_login">
                    <div className="logo_login">
                        <img src={LogoPrincipal} alt="" width='190px' height='70px' />
                    </div>
                    <form className='forms' onSubmit={e => {
                        e.preventDefault();
                        login();
                    }}>
                        <div className="input_login">
                            <Input type='email' name='email' namePlaceholder='Email' label='' MinLengh='2' MaxLengh='60' onChange={e => setEmail(e.target.value)} />
                            <br /><br />
                            <Input type='password' name='senha' namePlaceholder='Senha' label='' MinLengh='2' MaxLengh='25'onChange={e => setSenha(e.target.value)} />
                        </div>

                        <div className="btn_login">
                            <Button name='' value='Login' />
                        </div>


                    </form>
                    <Link to='/cadastro' className='nao_possui_cadastro'><h3>Não possui cadastro? Click aqui para se cadastrar!</h3></Link>
                    <div className="logo_senai_login">
                        <img src={LogoSenai} alt="" width='220px' height='55px' />
                    </div>
                </div>


            </div>
        </div>
    )
}

export default Login;