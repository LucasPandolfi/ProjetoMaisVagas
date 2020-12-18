import React from 'react';
import Header from '../../components/header';
import './style.css';
import '../../assets/styles/global.css'
import Button from '../../components/button/index';
import Button_Maior from '../../components/button_maior';
import Users from '../../assets/images/users.png';
import Predio from '../../assets/images/predio (1).png'
import Planilha from '../../assets/images/planilha (2).png'
import Estagio from '../../assets/images/estagio.png'
import { Link } from 'react-router-dom';
import Menu from '../../components/menu';
import Select from '../../components/select';
import Card from '../../components/card/Index'
import Input from '../../components/input/index'


function HomeAdministrador() {
    return (
        <div>
            <Header />

            <div className='menu_adm'>
                <Menu title='' />
                <div className="principal_home_adm">
                    <h1 className='H1'>Área administrativa</h1>
                    <div className="body_adm">

                        <Link to='/login'><Button_Maior img={Users} value='Visualizar candidatos cadastrados' /></Link>

                        <Link to='/login'><Button_Maior img={Predio} value='Visualizar empresas cadastradas' /></Link>

                        <Link to='/login'><Button_Maior img={Planilha} value='Visualizar vagas cadastradas' /></Link>

                        <Link to='/login'><Button_Maior img={Estagio} value='Visualizar estágios' /></Link>
                    </div>
                    <div className='btn_pendente_adm'>
                        <Button value='Pendentes' name='btn_pendentes' />
                    </div>
                </div>
            </div>
        </div>
    );
}

export default HomeAdministrador;