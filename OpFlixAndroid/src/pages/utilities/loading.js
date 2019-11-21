import { Text, View, StyleSheet, StatusBar, Button, AsyncStorage, Image } from 'react-native';
import React, { Component, Fragment } from 'react';


class Splash extends Component {


    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            data: null
        }
    }

    componentDidMount() {
        this.recuperarFilme();
    }

    
    
    recuperarFilme = async () => {
        await fetch('http://192.168.3.192:5000/api/lancamento')
            .then(response => response.json())
            .then(async () => {
                // caso tenha conexao com api, redirecionar para a home
                (await AsyncStorage.getItem('@opflix:token') !== null) ? 

                (
                    this.props.navigation.navigate("Liststack")
                ) 
                : 
                (
                    this.props.navigation.navigate("user")
                )   
                
            })
            .catch(() => {
                // caso contrario, nao carregar e mostrar warning
            })
    }


    render() {
        return (
            <Fragment>
                <StatusBar backgroundColor="black" />
                <View style={styles.background}>
                    <StatusBar hidden />
                    <View>
                        <Image source={require('../../assets/opflix.png')} style={styles.logo} />
                        <Image
                            source={require('../../assets/loader.gif')}
                            style={styles.logo}
                        />
                    </View>
                </View>
            </Fragment>

        );
    }
}


const styles = StyleSheet.create({
    background: {
        flex: 1,
        backgroundColor: "black",
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center'
    },
    logo: {
        width: 150,
        height: 150
    },
    texto: {
        color: "white"
    }
});


export default Splash;