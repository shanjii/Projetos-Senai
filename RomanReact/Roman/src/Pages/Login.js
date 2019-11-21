import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, Button, AsyncStorage } from 'react-native';
import Video from 'react-native-video';
import { TextInput } from 'react-native-gesture-handler';


class Login extends Component {


    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            email: "Lari@.com",
            senha: "111"
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
        if (tokenAReceber != null) {
            try {
                await AsyncStorage.setItem('@roman:token', tokenAReceber);
                this.props.navigation.navigate('Liststack')
            } catch (error) { }
        }
    };

    render() {
        return (

            <Fragment>
                <View>
                    <StatusBar
                        hidden={true}
                    />
                </View>

                <View style={styles.background}>
                    <Video
                        source={require('../Assets/background.mp4')}
                        rate={1.0}
                        muted={true}
                        resizeMode={"cover"}
                        repeat
                        style={styles.video}
                    />
                    <View style={styles.background}>

                        <View style={styles.title}>
                            <Text style={styles.titleText}>ROMAN</Text>
                        </View>
                        <View>
                            <TextInput style={styles.input} placeholder="Email" onChangeText={email => this.setState({ email })} value={this.state.email} placeholder="email"/>
                        </View>
                        <View>
                            <TextInput style={styles.input2} placeholder="Senha" onChangeText={senha => this.setState({ senha })} value={this.state.senha} placeholder="senha"/>
                        </View>
                        <View style={styles.botoes}>
                            <Button style={styles.botao}
                                title="Fazer Login"
                                onPress={this._realizarLogin} />
                        </View>
                    </View>
                </View>
            </Fragment>

        )
    }
}

const styles = StyleSheet.create({
    titleText: {
        fontSize: 60,
        textAlign: "center",
        color: "white"
    },
    title: {
        marginTop: 40
    },
    video: {
        position: 'absolute',
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
    },
    background: {
        backgroundColor: 'rgba(255, 255, 255, 0)',
        flex: 1
    },
    botoes: {
        marginTop: 200,
        marginLeft: 20,
        marginRight: 20,
    },
    botao: {
    },
    input: {
        marginTop: 140,
        marginLeft: 20,
        marginRight: 20,
        backgroundColor: "white"
    },
    input2: {
        marginTop: 20,
        marginLeft: 20,
        marginRight: 20,
        backgroundColor: "white"
    }
    
});


export default Login;