import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, FlatList } from 'react-native';


class Main extends Component {

    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            medicos: [] //api
        };
    }

    componentDidMount() {
        this._carregarEventos();
    }

    _carregarEventos = async () => {
        // axios, fetch, xhr {xmlhttprequest}
        await fetch('http://192.168.3.192:5000/api/medicos')
            .then(resposta => resposta.json())
            .then(data => this.setState({ medicos: data }))
            .catch(erro => console.warn(erro));
    };

    render() {
        return (

            <Fragment>
                <StatusBar
                    hidden={true}
                />
                <View style={styles.fundo}>
                    <FlatList
                        data={this.state.medicos}
                        keyExtractor={item => item.idMedicos}
                        style={styles.list}
                        renderItem={({ item }) => (
                            <View style={styles.texto}>
                                <Text style={styles.textoItem}>{item.nome}</Text>
                                <Text style={styles.textoSub}>{item.dataNascimento}</Text>
                                <Text style={styles.textoData}>{item.crm}</Text>
                            </View>
                        )
                        }
                    />
                </View>

            </Fragment>

        )
    }
}

const styles = StyleSheet.create({
    texto: {
        backgroundColor: "gray",
        marginLeft: 30,
        marginRight: 30,
        borderRadius: 10,
        textAlign: "center",
        marginBottom: 10,
        padding: 10
    },
    textoItem:{
        fontSize: 30,
        textAlign: "center"

    },
    textoData: {
        fontSize: 15,
        textAlign: "center"
    },
    list: {
        padding: 10
    },
    fundo:{
        backgroundColor: "lightgrey",
        flex: 1
    },
    textoSub: {
        fontSize: 20,
        textAlign: "center"

    }

});




export default Main;