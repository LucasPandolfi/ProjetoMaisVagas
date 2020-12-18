import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, Image, TextInput, Button, TouchableOpacity, Switch, Alert } from 'react-native';
import { NavigationContainer, useNavigation } from '@react-navigation/native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import Menu from '../../components/menu';
import parseJwt  from '../../services/tokenDecoder'
import jwtDecode from 'jwt-decode';

export default function VisualizarCandidato({ navigation = useNavigation() }) {

    const [idVaga, setIdVaga] = useState(0);
    const [vaga, setVaga] = useState('');
    const [idEmpresa, setIdEmpresa] = useState(0);

    const [vagas, setVagas] = useState([]);

    React.useEffect(() => {
        // // parseJwt().then(token => {
        // listar(GetTokenUser().then());
        GetTokenUser().then(id => {
            listarVagaPorEmpresa(id!);
        })
    }, []);


    const GetTokenUser = async () => {
        const response = await AsyncStorage.getItem('token-maisVagas');

        return (parseJwt(response!)?.jti);

        // checkUserLogged(response);
    }

    const listarVagaPorEmpresa = (id: number) => {
        fetch('http://localhost:5000/api/Vaga/EmpresaVagas/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + AsyncStorage.getItem('token-maisVagas')
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
        <View style={{backgroundColor: '#EEEEEE'}}>
            <Menu navigation={navigation}/>

            <Text style={{textAlign: 'center', fontSize: 30, fontWeight: 'bold', marginVertical: 25}}>Minhas Vagas</Text>
            <Text style={{display: 'flex', flexDirection: 'column', alignItems: 'center'}}>
                {
                vagas.map((item: any) => {
                    return (
                        <View style={{
                            marginVertical: 25,
                            backgroundColor: 'white',
                            borderRadius: 20,
                            padding: 20,
                            width:340}}>
                            <View >
                                <Text style={{textAlign:'center', color: '#DA251C', fontSize: 25, marginBottom:10}}>{item.nomeVaga}</Text>
                            </View>
                            {/* <Text style={{marginTop: 10, marginBottom: 25, fontSize: 25}}>{item.idEmpresaNavigation.idUsuarioNavigation.nome}</Text> */}

                            <Text style={styles.title}>Descrição</Text>
                            <Text>{item.descricaoVaga}</Text>

                            <Text style={styles.title}>Soft Skills</Text>
                            <Text>{item.softSkills}</Text>

                            <Text style={styles.title}>Hard Skills</Text>
                            <Text>{item.hardSkills}</Text>

                            <Text style={styles.title}>Salário</Text>
                            <Text>{item.salario}</Text>

                            <Text style={styles.title}>Benefícios</Text>
                            <Text>{item.beneficios}</Text>
                        </View>
                    );
                })}
            </Text>

        </View>
    );
}

const styles = StyleSheet.create({
    title: {
        fontWeight: 'bold',
        fontSize: 16,
        color: '#DA251C',
        marginTop: 20,
        marginBottom: 5
    }
})