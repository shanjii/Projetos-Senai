import React, { Fragment, Component } from "react";
import { Text, View, StyleSheet, StatusBar, Image } from 'react-native';
import { FlatList } from "react-native-gesture-handler";

class Main extends Component {

    static navigationOptions = {
        header: null
    }


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
        await fetch('http://192.168.3.192:5000/api/projetos')
            .then(resposta => resposta.json())
            .then(data => this.setState({ eventos: data }))
    };

    render() {
        return (
            <Fragment>
                <StatusBar
                    hidden={true} />
                <View style={styles.fundo}>
                    <FlatList
                        data={this.state.eventos}
                        keyExtractor={item => item.IdProjeto}
                        style={styles.list}
                        renderItem={({ item }) => (
                            <View style={styles.texto}>
                                <Text style={styles.textoItem}>{item.nomeProjeto}</Text>
                                <Text style={styles.textoData}>{item.professor}</Text>
                                <Text style={styles.textoData}>{item.tema}</Text>
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
        backgroundColor: "lightgray",
        marginLeft: 30,
        marginRight: 30,
        borderRadius: 10,
        textAlign: "center",
        marginBottom: 10,
        padding: 10
    },
    textoItem: {
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
    fundo: {
        backgroundColor: "black",
        flex: 1
    },
    textoSub: {
        fontSize: 20,
        textAlign: "center"

    }

});


export default Main;