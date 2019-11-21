import Main from './Pages/Main';
import Login from './Pages/Login';
import { createStackNavigator } from 'react-navigation-stack';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';

const Authstack = createStackNavigator({
    Sign: {
        screen: Login
    }
});
const Liststack = createStackNavigator({
    List: {
        screen: Main
    }
});

export default createAppContainer(createSwitchNavigator({
    Authstack,
    Liststack
},
    {
        initialRouteName: 'Authstack'
    }
)
);