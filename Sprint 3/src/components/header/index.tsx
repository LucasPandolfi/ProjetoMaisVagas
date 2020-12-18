import React from 'react';
import logo from '../../assets/images/masvaga.png';
import menu from '../../assets/images/menus.png';
import msg from '../../assets/images/msg.png';
import senai from '../../assets/images/logosenai.png';
import './style.css';
import '../../assets/styles/global.css'

function Header() {
    return (
        <div>
            <header>
                <div className="container_principal_2">
                    <div className="principal_header">

                        <div className="logoapp12">
                            <img className="logo" src={logo} alt="logo mais vagas" />

                        </div>

                        <div className="logosenai12">
                            <img src={senai} alt="logo do senai" />
                        </div>

                    </div>
                </div>
            </header>
        </div>
    );
}
export default Header;