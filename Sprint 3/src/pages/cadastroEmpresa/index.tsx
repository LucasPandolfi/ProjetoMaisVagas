import React, { useState } from 'react';
import Input from '../../components/input';
import Button from '../../components/button/index'
import LogoSenaiVer from '../../assets/images/logosenaiver.jpg';
import LogoMaisVagas from '../../assets/images/logomaisvagas.jpg';
import voltar from '../../assets/images/voltar.png';
import './style.css';
import { Link } from 'react-router-dom';

function CadastroEmpresa() {

    const [empresa, setEmpresa] = useState('');
    const [idEmpresa, setIdEmpresa] = useState(0);

    const [usuario, setUsuario] = useState('');
    const [idUsuario, setIdUsuario] = useState(0);

    //variaveis
    const [cnpj, setCnpj] = useState('');
    const [cnae, setCnae] = useState('');
    const [numeroEmpregados, setNumeroEmpregados] = useState('');
    const [nomeParaContato, setNomeParaContato] = useState('');
    const [nome, setUsuarioNome] = useState('');
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [telefone, setTelefone] = useState('');
    const [cep, setCep] = useState('');
    const [estado, setEstado] = useState('');
    const [cidade, setCidade] = useState('');
    const [bairro, setBairro] = useState('');
    const [idTipoUsuario, setIdTipoUsuario] = useState(3);

    const cadastrarEmpresa = () => {
        const form = {
            cnpj: cnpj,
            cnae: cnae,
            numeroEmpregados: numeroEmpregados,
            nomeParaContato: nomeParaContato,
            idUsuarioNavigation: {
                nome: nome,
                email: email,
                senha: senha,
                telefone: telefone,
                cep: cep,
                estado: estado,
                cidade: cidade,
                bairro: bairro,
                IdTipoUsuario: idTipoUsuario
            }
        };

        fetch('http://localhost:5000/api/empresa', {
            method: 'POST',
            body: JSON.stringify(form),
            headers: {
                'Content-Type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(() => {
                alert('Empresa cadastrada com sucesso!');
                setEmpresa('');
                setUsuario('');
                setCnpj('');
                setCnae('');
                setNumeroEmpregados('');
                setNomeParaContato('');
                setUsuarioNome('');
                setEmail('');
                setSenha('');
                setTelefone('');
                setCep('');
                setEstado('');
                setCidade('');
                setBairro('');
                setIdTipoUsuario(3);
            })
            .catch(err => console.error(err));
    }


    return (
        <div>
            <div className="voltar">
                <Link to='/cadastro'><img src={voltar} alt="voltar" width="40" height="35" /></Link>
            </div>
            <div className="imggus">
                <img src={LogoMaisVagas} alt="logo do senai" width="150" height="67" />
            </div>
            <div className="texto">
                <h3>Cadastro de Empresas</h3>
            </div>

            <form onSubmit={event => {
                event.preventDefault();
                cadastrarEmpresa();
            }}>
                <div className="caixapai">
                    <div className="caixa">
                        <Input name="Razão Social" namePlaceholder="Razão Social" label="" MinLengh='2' MaxLengh='25' value={nome} onChange={e => setUsuarioNome(e.target.value)} />
                        <Input name="CNPJ" namePlaceholder="CNPJ" label="" MinLengh='2' MaxLengh='17' value={cnpj} onChange={e => setCnpj(e.target.value)} />
                        <Input name="CNAE" namePlaceholder="CNAE" label="" MinLengh='2' MaxLengh='10' value={cnae} onChange={e => setCnae(e.target.value)} />
                        <Input name="Empregados Registrados" namePlaceholder="Empregados Registrados" label="" MinLengh='2' MaxLengh='20' value={numeroEmpregados} onChange={e => setNumeroEmpregados(e.target.value)} />
                        <Input name="Nome p Contato" namePlaceholder="Nome Para Contato" label="" MinLengh='2' MaxLengh='20' value={nomeParaContato} onChange={e => setNomeParaContato(e.target.value)} />
                        <Input name="Telefone" namePlaceholder="Telefone" label="" MinLengh='2' MaxLengh='15' value={telefone}  onChange={e => setTelefone(e.target.value)}/>
                    </div>
                    <div className="caixa2">
                        <Input name="Estado" namePlaceholder="Estado" label="" MinLengh='2' MaxLengh='20' value={estado} onChange={e => setEstado(e.target.value)} />
                        <Input name="Endereço" namePlaceholder="Cidade" label="" MinLengh='2' MaxLengh='20' value={cidade} onChange={e => setCidade(e.target.value)} />
                        <Input name="Bairro" namePlaceholder="Bairro" label="" MinLengh='2' MaxLengh='20' value={bairro} onChange={e => setBairro(e.target.value)} />
                        <Input name="CEP" namePlaceholder="CEP" label="" MinLengh='2' MaxLengh='11' value={cep} onChange={e => setCep(e.target.value)} />
                        <Input name="email" namePlaceholder="E-Mail" label="" MinLengh='2' MaxLengh='60' value={email} onChange={e => setEmail(e.target.value)} />
                        <Input name="Senha" namePlaceholder="Senha" type="password" label="" MinLengh='2' MaxLengh='20' value={senha} onChange={e => setSenha(e.target.value)} />
                    </div>
                </div>
                <div className="butao">
                    {
                        <Button value="Cadastrar" name="Cadastrar" />
                    }
                </div>
            </form>
            <div className="logosenai">
                <img src={LogoSenaiVer} alt="logo do senai" width="200" height="60" />
            </div>
        </div>
    )
}

export default CadastroEmpresa