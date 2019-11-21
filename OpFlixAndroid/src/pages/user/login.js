import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, AsyncStorage, SafeAreaView, Header, Image, ScrollView } from 'react-native';
import { TextInput } from 'react-native-gesture-handler';
import { Button } from 'react-native-paper';


class Login extends Component {


    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            email: "",
            senha: ""
        }
    }


    _realizarLogin = async () => {
        //console.warn(this.state.email + this.state.senha);
        await fetch('http://192.168.3.192:5000/api/login', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                email: this.state.email,
                senha: this.state.senha

            })
        })
            .then(resposta => resposta.json())
            .then(data => this._irParaHome(data.token))
            .catch(erro => console.warn(erro));
    };

    _irParaHome = async (tokenAReceber) => {
        if (tokenAReceber !== null) {
                await AsyncStorage.setItem('@opflix:token', tokenAReceber);
                await AsyncStorage.setItem('@nome', this.state.email);
                this.props.navigation.navigate('Liststack')
           
        }
    };

    _cadastrar = () => {
        this.props.navigation.navigate('Cadastro')
    }

    render() {
        return (
            <Fragment>
                <StatusBar backgroundColor="black" />
                <View style={styles.background}>
                    <Image source={require('../../assets/movie.jpg')} style={styles.fundo} />
                    <View>
                        <View style={styles.main}>
                            <Image source={require('../../assets/opflix.png')} style={styles.logo} />
                        </View>
                        <View >
                        </View>
                        <View style={{marginTop: 70}}>
                            <TextInput style={{color: "white", borderColor: "white", fontSize: 25, width: "80%", borderBottomWidth: 1, textAlign: "center", alignSelf: "center"}} placeholder="EMAIL" placeholderTextColor="white" onChangeText={email => this.setState({ email })} value={this.state.email} />
                        </View>
                        <View>
                            <TextInput style={{color: "white", borderColor: "white", fontSize: 25, width: "80%", borderBottomWidth: 1, textAlign: "center", alignSelf: "center",}} secureTextEntry={true} placeholder="SENHA" placeholderTextColor="white"  onChangeText={senha => this.setState({ senha })} value={this.state.senha} />
                        </View>
                        <View style={styles.botao}>
                        <Button mode="contained"  color="white" onPress={this._realizarLogin}>Login</Button>

                        </View>
                        <View >
                            <Button style={styles.botao1} mode="contained" color="white" onPress={this._cadastrar}>Cadastrar</Button>
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
        backgroundColor: "black"
    },
    logo: {
        width: 150,
        height: 150,
        alignSelf: "center",
        marginTop: 80,
    },
    botao: {
        alignSelf: "center",
        width: "50%",
        marginTop: 40
        },
  
    botao1: {
        marginTop: 20,
        alignSelf: "center",
        width: "50%"
    },
    text: {
        color: "white",
        textAlign: "center",
        fontSize: 30,
        marginTop: 50
    }

});


export default Login;