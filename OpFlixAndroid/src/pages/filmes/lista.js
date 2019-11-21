import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, AsyncStorage, Image, ScrollView, ActivityIndicator, TouchableHighlight } from 'react-native';
import { FlatList, TouchableOpacity, } from 'react-native-gesture-handler';
import { Button } from 'react-native-paper';


class Lista extends Component {


    static navigationOptions = {
        header: null
    }

    constructor() {
        super();
        this.state = {
            data: [],
            loading: 0,
            top5: [],
            usuario: '',
            email: ''
        }
    }

    componentDidMount = async () => {
        this.recuperarFilme()
        this.state.usuario = await AsyncStorage.getItem("@opflix:token")
        this.state.email = await AsyncStorage.getItem("@nome")
    }

    _logout = () => {

        AsyncStorage.removeItem("@opflix:token")
        this.props.navigation.navigate("Splashscreen")
    }

    recuperarFilme = () => {
        this._loadingstart();
        fetch('http://192.168.3.192:5000/api/lancamento')
            .then(response => response.json())
            .then(response => {
                this.setState({ top5: response.slice(0, 5) })
                this.setState({ data: response })
                this._loadingend()

            })

    }

    _loadingstart = () => {
        this.setState({ loading: 1 })
    }

    _loadingend = () => {
        this.setState({ loading: 0 })
    }




    render() {
        return (
            <Fragment>
                <StatusBar backgroundColor="#800000" />
                <View style={{ borderColor: 'black', borderBottomWidth: 1, flexDirection: "row", alignSelf: "center", justifyContent: "space-between", backgroundColor: "#800000", width: "100%" }}>
                    <Text style={{ marginTop: 15, fontFamily: 'BebasNeue-Regular', marginLeft: 30, color: "white", fontSize: 25, shadowColor: "black", shadowOffset: { height: 5 } }}>{this.state.email}</Text>
                    <Button mode="contained" color="black" style={{ marginTop: 10, fontFamily: 'BebasNeue-Regular', marginRight: 5, marginBottom: 5 }} onPress={this._logout}>Logout</Button>
                </View>
                <View style={{ flex: 1, backgroundColor: "black" }}>
                    <ScrollView>

                        {
                            (this.state.loading === 1) ?
                                (
                                    <View style={{ marginTop: "60%" }}>
                                        <ActivityIndicator size="large" color="red" />
                                    </View>
                                )
                                :
                                (
                                    <View style={{ backgroundColor: "black" }}>
                                        <View style={{ flexDirection: "row", flexWrap: "wrap", justifyContent: "center" }}>
                                            {this.state.data.map((Element) => {
                                                return (
                                                    <View style={{ marginLeft: 5, marginRight: 5, marginBottom: 5, marginTop: 5 }}>
                                                        <TouchableHighlight onPress={() => this.props.navigation.navigate("Filme", {
                                                            imagem: Element.imagem, nome: Element.nomeLancamento
                                                        })}>
                                                            <Image style={{ width: 120, height: 180 }} source={{ uri: Element.imagem }} />
                                                        </TouchableHighlight>
                                                    </View>
                                                )
                                            })}
                                        </View>
                                    </View>
                                )
                        }
                    </ScrollView>
                </View>
            </Fragment>

        );
    }
}




export default Lista;

