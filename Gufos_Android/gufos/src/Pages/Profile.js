import React, { Fragment, Component } from "react";
import { Text, View, Image, StyleSheet, AsyncStorage } from 'react-native';



class Profile extends Component {
    constructor() {
        super();
        this.state = {
            tokenLocal: ''
        }
    }


    componentDidMount() {
        this._buscarDadosStorage();
    }

    _buscarDadosStorage = async () => {
        try {
            const tokenDoStorage = await AsyncStorage.getItem('@gufos:token');
            var jwtDecode = require('jwt-decode');
            var decoded = jwtDecode(tokenDoStorage);
            if (decoded != null) {
                this.setState({ tokenLocal: decoded })
            }
        } catch (error) { }
    };

    render() {
        return (
            <Fragment >
                <View style={styles.fundo}>
                    <View>
                        <Text style={styles.nome}>{this.state.tokenLocal.email}</Text>
                    </View>
                    <View style={styles.img}>
                        <Image source={require('../assets/img/leave.gif')} />
                    </View>
                </View>
            </Fragment>
        );
    }
}
const styles = StyleSheet.create({
    nome: {
        fontSize: 30,
        textAlign: "center"
    },
    img: {
        justifyContent: "center",
        alignItems: "center"

    },
    fundo: {
        backgroundColor: "lightgrey",
        flex: 1
    }

});

export default Profile;