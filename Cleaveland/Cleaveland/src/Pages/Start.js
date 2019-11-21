import React, { Component, Fragment } from 'react';
import { Text, View, StyleSheet, StatusBar, Button } from 'react-native';
import Video from 'react-native-video';


class Start extends Component {

    acessarHome = () => {
        this.props.navigation.navigate('MainNavigator')
    }

    static navigationOptions = {
        header: null
    }

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
                            <Text style={styles.titleText}>Cleaveland</Text>
                        </View>
                        <View style={styles.botoes}>
                            <Button style={styles.botao}
                                title="Ver médicos"
                                onPress={this.acessarHome} />
                        </View>
                    </View>
                </View>
            </Fragment>

        )
    }
}

const styles = StyleSheet.create({
    titleText: {
        fontSize: 40,
        textAlign: "center",
        color: "white"
    },
    title: {
        marginTop: 60
    },
    video: {
        position: 'absolute',
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
    },
    background: {
        backgroundColor: 'rgba(0, 0, 0, 0.3)',
        flex: 1
    },
    botoes: {
        marginTop: 300,
        marginLeft: 70,
        marginRight: 70,
    },
    botao: {
    }
    
});


export default Start;