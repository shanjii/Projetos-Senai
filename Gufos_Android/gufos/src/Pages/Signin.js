import React, { Component } from 'react';

import { Text, View, TextInput, Button, AsyncStorage, StyleSheet, Image } from 'react-native';

class Signin extends Component {

    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            email: "admin@admin.com",
            senha: "123456"
        }
    }

    _realizarLogin = async () => {
        //console.warn(this.state.email + this.state.senha);
        await fetch('http://192.168.7.85:5000/api/login', {
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
        if (tokenAReceber != null) {
            try {
                await AsyncStorage.setItem('@gufos:token', tokenAReceber);
                this.props.navigation.navigate('MainNavigator')
            } catch (error) { }
        }
    };

    render() {
        return (
            <View style={styles.fundo}>
                <View >
                    <Text style={styles.nome}>Fazer Login</Text>
                    <TextInput style={styles.button} onChangeText={email => this.setState({ email })} value={this.state.email} placeholder="email" />
                    <TextInput style={styles.button} onChangeText={senha => this.setState({ senha })} value={this.state.senha} placeholder="senha" />
                    <Button onPress={this._realizarLogin}
                        title="Login"
                    />
                </View>
                <View style={styles.img}>
                    <Image 
                        source={require('../assets/img/arrive.gif')}
                        style={styles.peepo}
                    />
                </View>
            </View>
        )
    }
}
const styles = StyleSheet.create({
    nome: {
        fontSize: 50,
        textAlign: "center",
        marginBottom: 80,
        marginTop: 90
    },
    fundo: {
        backgroundColor: "lightgrey",
        flex: 1,
    },
    button: {
        backgroundColor: "white"
    },
    img:{
        marginTop: 40,
        justifyContent:"center",
        alignItems: "center",
    },
    peepo:{
    
    }

});

export default Signin;