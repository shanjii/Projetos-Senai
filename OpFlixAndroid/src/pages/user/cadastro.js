import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, AsyncStorage, SafeAreaView, Header, Image, ScrollView } from 'react-native';
import { TextInput } from 'react-native-gesture-handler';
import { Button } from 'react-native-paper';


class Cadastro extends Component {


    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            email: "",
            senha: "",
            permissao: "CLIENTE",
            nome: ""
        }
    }

    _cadastrar = async () => {

        if (this.state.email && this.state.senha && this.state.nome !== null) {

            //console.warn(this.state.email + this.state.senha);
            await fetch('http://192.168.3.192:5000/api/usuario', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    nomeUsuario: this.state.nome,
                    Email: this.state.email,
                    Senha: this.state.senha,
                    permissao: this.state.permissao

                })
            })
                .then(() => this._irParaLogin())
        }
    };

    _irParaLogin = () => {
        this.props.navigation.navigate('Login')
    };

    render() {
        return (
            <Fragment>
                <StatusBar backgroundColor="#800000" />
                    <View style={styles.background}>

                        <View style={{ marginTop: 50 }}>
                            <View>
                                <Text style={styles.text}>Criar conta</Text>
                            </View>
                            <View style={{ marginTop: 20 }} >
                                <TextInput style={{ color: "white", fontSize: 25, textAlign: "center", borderColor: "white", width: "80%", borderBottomWidth: 1, alignSelf: "center", }} onChangeText={(nome) => this.setState({ nome })} placeholderTextColor="white" placeholder="Nome" />
                            </View>
                            <View >
                                <TextInput style={{ color: "white", fontSize: 25, textAlign: "center", borderColor: "white", width: "80%", borderBottomWidth: 1, alignSelf: "center", }} onChangeText={(email) => this.setState({ email })} placeholderTextColor="white" placeholder="Email" />
                            </View>
                            <View  >
                                <TextInput style={{ color: "white", fontSize: 25, textAlign: "center", borderColor: "white", width: "80%", borderBottomWidth: 1, alignSelf: "center", }} onChangeText={(senha) => this.setState({ senha })} placeholderTextColor="white" placeholder="Senha" />
                            </View>
                            <View style={{ marginTop: 50 }} >
                                <Button mode="contained" color="white" style={{ width: "50%", alignSelf: "center" }} onPress={this._cadastrar}>Cadastrar</Button>

                            </View>

                        </View>
                    </View>
            </Fragment>

        );
    }
}


const styles = StyleSheet.create({
    fundo: {
        position: 'absolute',
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
    },
    background: {
        flex: 1,
        backgroundColor: "#800000"
    },
    botao: {
        marginLeft: 20,
        marginRight: 20,
        marginTop: 30,
    },
    input: {
        marginTop: 20,
        marginLeft: 20,
        marginRight: 20,
        borderBottomWidth: 1,
        borderColor: "white"
    },
    input1: {
        marginTop: 20,
        marginLeft: 20,
        marginRight: 20,
        borderBottomWidth: 1,
        borderColor: "white"
    },

    text: {
        color: "white",
        textAlign: "center",
        fontSize: 30,
    }

});


export default Cadastro;