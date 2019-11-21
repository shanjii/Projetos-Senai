import MainScreen from './Pages/Main';
import ProfileScreen from './Pages/Profile';
import SigninScreen from './Pages/Signin';
import CategoriaScreen from './Pages/Categorias';
import { createBottomTabNavigator } from 'react-navigation-tabs';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';

const Authstack = createStackNavigator({
    Sign: {
        screen: SigninScreen
    }
});

const MainNavigator = createBottomTabNavigator({
    Main: {
        screen: MainScreen,
    },
    Profile: {
        screen: ProfileScreen,
    },
    Categoria: {
        screen: CategoriaScreen,
    }
},
    {
        tabBarOptions: {
            activeBackgroundColor: "grey",
            inactiveBackgroundColor: "darkgrey",
            labelStyle: {
                color: "white",
                fontSize: 20,
                marginBottom: 10
            }
        }
    });

export default createAppContainer(createSwitchNavigator({
    MainNavigator,
    Authstack
},
    {
        initialRouteName: 'Authstack'
    }
)
);