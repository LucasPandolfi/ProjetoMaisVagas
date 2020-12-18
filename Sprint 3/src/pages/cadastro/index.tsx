import React, { useEffect, useState } from 'react';
import Input from '../../components/input';
import Button from '../../components/button/index'
import LogoSenaiVer from '../../assets/images/logosenaiver.jpg';
import LogoMaisVagas from '../../assets/images/logomaisvagas.jpg';
import voltar from '../../assets/images/voltar.png';
import Select from '../../components/select/index';
import './style.css';
import { Link } from 'react-router-dom';


function CadastroCandidato() {

    const [idCandidato, setIdCandidato] = useState(0);
    const [candidato, setCandidato] = useState('');

    const [usuario, setUsuario] = useState('');
    const [idUsuario, setIdUsuario] = useState(0);

    const [cursos, setCursos] = useState([])
    const [curso, setCurso] = useState('')

    //variaveis
    const [cpf, setCpf] = useState('');
    const [dataNascimento, setDataNascimento] = useState('');
    const [matricula, setMatricula] = useState('');
    const [nome, setUsuarioNome] = useState('');
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [telefone, setTelefone] = useState('');
    const [cep, setCep] = useState('');
    const [idTipoUsuario, setIdTipoUsuario] = useState(2);



    const cadastrar = () => {
        const form = {
            cpf: cpf,
            dataNascimento: dataNascimento,
            matricula: matricula,
            idCurso: curso,
            idUsuarioNavigation: {
                nome: nome,
                email: email,
                senha: senha,
                telefone: telefone,
                cep: cep,
                IdTipoUsuario: idTipoUsuario
            }
        };
        console.log(form);
        fetch('http://localhost:5000/api/candidato', {
            method: 'POST',
            body: JSON.stringify(form),
            headers: {
                'Content-Type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(() => {
                alert('Usuario cadastrado com sucesso!');
                setCandidato('');
                setUsuario('');
                setCpf('');
                setDataNascimento('');
                setMatricula('');
                setUsuarioNome('');
                setEmail('');
                setSenha('');
                setTelefone('');
                setCep('');
                setCurso('');
                setIdTipoUsuario(2);
            })
            .catch(err => console.error(err));
    }


    useEffect(() =>{
        ListarCursos()
    }, [])

    const ListarCursos = () => {
        fetch('http://localhost:5000/api/curso', {
            method: 'GET',
            headers: {
                
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setCursos(dados);
                console.log(dados)
            })
            .catch(err => console.error(err));
    }

    return (
        <div>
            <div className="voltar">
                <Link to='/'><img src={voltar} alt="voltar" width="40" height="35" /></Link>
            </div>

            <div className="imggus">
                <img src={LogoMaisVagas} alt="logo do senai" width="150" height="67" />
            </div>

            <div className="texto">
                <h3>Cadastro de Candidatos</h3>
            </div>
            <form onSubmit={event => {
                event.preventDefault();
                cadastrar();
            }}>
                <div className="inputpai">
                    <div className="input1">
                        <Input name="Nome" namePlaceholder="Nome" label="" value={nome} MinLengh='2' MaxLengh='30' onChange={e => setUsuarioNome(e.target.value)} />
                        <Input name="CPF" namePlaceholder="CPF" label="" MinLengh='2' MaxLengh='14' value={cpf} onChange={e => setCpf(e.target.value)} />
                        <Input name="Data de Nascimento" namePlaceholder="Data de Nascimento" label="" MinLengh='1' MaxLengh='12' value={dataNascimento} onChange={e => setDataNascimento(e.target.value)} />
                        <Input name="cep" namePlaceholder="Cep" label="" MinLengh='2' MaxLengh='11' value={cep} onChange={e => setCep(e.target.value)} />
                        <br/>
                        <select name="curso" onChange={e => setCurso(e.target.value)} value={curso}>
                            <option value="0">Selecione um Curso</option>
                            {
                                cursos.map((item: any) => {
                                    return <option value={item.idCurso}>{item.nome}</option>
                                })
                            }
                        </select>
                        <br />
                        <br />
                    </div>

                    <div className="input2">
                        <Input name="email" namePlaceholder="Email" label="" MinLengh='2' MaxLengh='25' value={email} onChange={e => setEmail(e.target.value)} />
                        <Input name="Numero de Inscricao" namePlaceholder="Matricula" label="" MinLengh='2' MaxLengh='8' value={matricula} onChange={e => setMatricula(e.target.value)} />
                        <Input name="Telefone" namePlaceholder="Telefone" label="" MinLengh='2' MaxLengh='15' value={telefone} onChange={e => setTelefone(e.target.value)}/>
                        <Input name="senha" namePlaceholder="Senha" type='password' label="" MinLengh='2' MaxLengh='20' value={senha} onChange={e => setSenha(e.target.value)} />
                        <br />
                        <br />
                    </div>
                </div>

                <div className="button1">
                    <Button value="Cadastrar" name="Cadastrar" />
                </div>

                <div className="opcao_cadastro">
                    <Link to='/cadastro' className='aluno_candidato'><h3>Candidato</h3></Link>
                    <Link to='/cadastroEmpresa' className='empresa_empresa'><h3>Empresa</h3></Link>
                </div>
            </form>
            <div className="logosenai">
                <img src={LogoSenaiVer} alt="logo do senai" width="200" height="60" />
            </div>
        </div>
    )
}

export default CadastroCandidato 