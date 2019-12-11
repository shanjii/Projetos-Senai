import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, SafeAreaView, StatusBar, Header, Image, ScrollView, Dimensions, TouchableWithoutFeedback, TouchableOpacity, ActivityIndicator, ImageBackground } from 'react-native';
import data from '../dictionary/dictionary.json'


class Home extends Component {

    static navigationOptions = {
        header: null
    }


    constructor() {
        super();
        this.state = {
            loading: 0
        }
    }

    



    render() {
        return (
            <ScrollView>
                {data.map(a => {
                    return (
                        <View style={{ justifyContent: "space-between" }}>
                            <Text style={{fontSize: 30}}>{a.ENGLISH}: {a.TAAGRA}</Text>
                        </View>
                    )
                }
                )}
            </ScrollView>
        );
    }
}

export default Home;