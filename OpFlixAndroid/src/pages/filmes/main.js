import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, AsyncStorage, Image, ScrollView, ActivityIndicator, TouchableHighlight } from 'react-native';
import { FlatList, TouchableOpacity, } from 'react-native-gesture-handler';
import { Button } from 'react-native-paper';
import { AutoScrollFlatList} from  'react-native-autoscroll-flatlist'

class Main extends Component {


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

    irFilmes = () => {
        this.props.navigation.navigate('Lista')
    }



    render() {
        return (
            <Fragment>
                <StatusBar backgroundColor="#800000" />
                <View style={{ flex: 1, backgroundColor: "black" }}>
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
                                    <View>
                                        <View style={{ borderBottomWidth: 2, backgroundColor: "white", color: "black", width: "100%", }}>
                                            <Text style={{ marginTop: 10, marginBottom: 10, fontFamily: 'BebasNeue-Regular', textAlign: "center", fontSize: 30 }} >ÚLTIMOS LANÇAMENTOS</Text>
                                        </View>
                                        <FlatList
                                            horizontal={true}
                                            data={this.state.top5}
                                            keyExtractor={item => item.IdLancamento}
                                            renderItem={({ item }) => (
                                                <View>
                                                    <TouchableHighlight onPress={() => console.warn(item.nomeLancamento)}>
                                                        <Image style={{ width: 412, height: "95%" }} source={{ uri: item.imagem }} />
                                                    </TouchableHighlight>
                                                </View>
                                            )
                                            } />
                                    </View>
                                    <View>
                                        <Button mode="contained" color="#800000" style={{ position: "relative", padding: 10, top: -200, fontFamily: 'BebasNeue-Regular', width: "50%", alignSelf: "center" }} onPress={this.irFilmes}>IR PARA FILMES</Button>
                                    </View>
                                </View>
                            )
                    }
                </View>
            </Fragment>

        );
    }
}




export default Main;