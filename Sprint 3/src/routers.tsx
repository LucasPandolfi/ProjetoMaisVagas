import React from 'react';
import {BrowserRouter, Route, Redirect} from 'react-router-dom';
import HomeUsuarioLogado from './pages/homeUsuarioCandidato/index';
import CadastroCandidato from './pages/cadastro/index';
import CadastroEmpresa from './pages/cadastroEmpresa';
import HomeEmpresa from './pages/homeEmpresa';
import TelaHomeNaoLogado from './pages/telaHomeNaoLogado/index';
import VizualizarDetalhesDaVaga from './pages/visualizarDetalhesDaVaga';
import CandidatoVaga from './pages/vagasDoCandidato';
import Login from './pages/login/index';
import CadastroVaga from './pages/cadastroVaga/index';

function Routers() {

    const RotaPrivada = ({Component, ...rest}: any) => (
        <Route
        {...rest}
        render={props=>
        localStorage.getItem('token') !==null ? (
            <Component {...props}/>
        ):(
            <Redirect
            to={{pathname:'/login', state:{from:props.location}}}
            />
        )
        }
        />
    )

    return(
        <BrowserRouter>
            <Route path='/' exact component={TelaHomeNaoLogado}/>
            <RotaPrivada path='/telaHomeLogado' component={HomeUsuarioLogado} /> 
            <Route path='/cadastro' component={CadastroCandidato} />
            <Route path='/cadastroEmpresa' component={CadastroEmpresa} />
            <RotaPrivada path='/homeEmpresa' component={HomeEmpresa} />
            <RotaPrivada path= '/visualizarDetalhesDaVaga' component= {VizualizarDetalhesDaVaga} />
            <RotaPrivada path= '/candidatoVaga' component={CandidatoVaga} />
            <RotaPrivada path= '/cadastroVaga' component={CadastroVaga} />
            <Route path= '/login' component={Login} />
        </BrowserRouter>
    )
}

export default Routers;