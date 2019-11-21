import React, {Fragment, Component } from "react";
import { Text, View, StyleSheet, StatusBar, Image } from 'react-native';
import { FlatList } from "react-native-gesture-handler";

class Main extends Component {

    constructor() {
        super();
        this.state = {
            eventos: [] //api
        };
    }

    componentDidMount() {
        this._carregarEventos();
    }

    _carregarEventos = async () => {
        // axios, fetch, xhr {xmlhttprequest}
        await fetch('http://192.168.7.85:5000/api/eventos')
            .then(resposta => resposta.json())
            .then(data => this.setState({ eventos: data }))
            .catch(erro => console.warn(erro));
    };

    render() {
        return (
            <Fragment>
                <StatusBar barStyle="dark-content" />
                <View style={styles.fundo}>
                    <FlatList
                        data={this.state.eventos}
                        keyExtractor={item => item.idEvento}
                        style={styles.list}
                        renderItem={({ item }) => (
                            <View style={styles.texto}>
                                <Text style={styles.textoItem}>{item.titulo}</Text>
                                <Text style={styles.textoSub}>{item.descricao}</Text>
                                <Text style={styles.textoData}>{item.localizacao}</Text>
                                <Text style={styles.textoData}>{item.dataEvento}</Text>
                            </View>
                        )
                        }
                    />
                </View>
            </Fragment>
        );
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