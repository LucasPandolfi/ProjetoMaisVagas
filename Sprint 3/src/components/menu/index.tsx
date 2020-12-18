import React from 'react';
import Home from '../../assets/images/ImgHouse.png';
import Planilha from '../../assets/images/Planilha.png';
import Favorita from '../../assets/images/Favorita.png';
import Usuario from '../../assets/images/User1.png';
import Configuracoes from '../../assets/images/Configuracoes.png';
import Logar from '../../assets/images/Logout.png';
import Deslogar from '../../assets/images/deslogar.png';
import iconeCadastrarVaga from '../../assets/images/cadastrarVaga.png';
import CadastrarUsuario from '../../assets/images/cadastrarUsuario.png'
import Avatar from '../../assets/images/avatar.png'
import './style.css';
import '../../assets/styles/global.css';
import { Link, useHistory } from 'react-router-dom';
import { parseJwt } from '../../auth';



interface HomeProps {
    title: string;
    text?: string;
}

const Menu: React.FunctionComponent<HomeProps> = (props) => {

    let history = useHistory();

    let tokeDecode: any = parseJwt();

    const logout = () => {
        localStorage.removeItem('token');
        history.push('/');
    }
    const menu = () => {
        const token = localStorage.getItem('token');

        if (token === undefined || token === null) {
            return (
                <ul className="menuNav">
                    <h4>Principal</h4>
                    <Link className="link" to="/"><li><img src={Home} width='30px' height='30px' /><p className='menu_link'>Home</p></li></Link>
                    <Link className="link" to="/login"><li><img src={Logar} width='30px' height='30px' /><p className='menu_link'>Login</p></li></Link>
                    <Link className="link" to="/cadastro"><li><img src={CadastrarUsuario} width='37px' height='37px' /><p className='menu_link'>Cadastro</p></li></Link>
                </ul>
            );
        }
        else {
            if (parseJwt().Role === 'Candidato') {
                return (
                    <ul className="menuNav">
                         <div className="imgEstatica_">
                            <img src={Avatar} width='70px' height='70px' />
                        </div>
                        <div className="nomeUser_">
                            <p>{tokeDecode.nomeUsuario}</p>
                        </div>
                        <h4>Principal</h4>
                        <Link to='telaHomeLogado'><li><img src={Home} width='30px' height='30px' /><p className='menu_link'>Home</p></li></Link>
                        <Link to='candidatoVaga'><li><img src={Planilha} width='30px' height='30px' /><p className='menu_link'>Candidaturas</p></li></Link>
                        <h4>Conta</h4>
                        <Link to=''><li><img src={Usuario} width='30px' height='30px' /><p className='menu_link'>Perfil</p></li></Link>
                        <Link to=''><li><img src={Configuracoes} width='30px' height='30px' /><p className='menu_link'>Configurações</p></li></Link>

                        <Link to='/'><li><img src={Deslogar} width='30px' height='30px' /><p className='menu_link' onClick={(event) => {
                            event.preventDefault();
                            logout();
                        }}>Sair</p></li></Link>
                    </ul>
                )
            }
            if (parseJwt().Role === 'Empresa')
                return (
                    <ul className="menuNav">
                        <div className="imgEstatica_">
                            <img src={Avatar} width='70px' height='70px' />
                        </div>
                        <div className="nomeUser_">
                            <p>{tokeDecode.nomeUsuario}</p>
                        </div>
                        <h4>Principal</h4>
                        <Link to='/homeEmpresa'><li><img src={Home} width='30px' height='30px' /><p className='menu_link'>Home</p></li></Link>
                        <Link to='cadastroVaga'><li><img src={iconeCadastrarVaga} width='30px' height='30px' /><p className='menu_link'>Cadastrar vaga</p></li></Link>
                        <h4>Conta</h4>
                        <Link to=''><li><img src={Usuario} width='30px' height='30px' /><p className='menu_link'>Perfil</p></li></Link>
                        <Link to=''><li><img src={Configuracoes} width='30px' height='30px' /><p className='menu_link'>Configurações</p></li></Link>

                        <Link to='/'><li><img src={Deslogar} width='30px' height='30px' /><p className='menu_link' onClick={(event) => {
                            event.preventDefault();
                            logout();
                        }}>Sair</p></li></Link>
                    </ul>
                )
        }
    }
    return (
        <div>
            <div className="menu">
                <nav>
                    {menu()}
                </nav>
            </div>
        </div>
    )
}

export default Menu;