import StartScreen from './Pages/Start';
import MainScreen from './Pages/Main';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';
import { createBottomTabNavigator } from 'react-navigation-tabs';



const Start = createStackNavigator({
    Start: {
        screen: StartScreen
    }
});

const MainNavigator = createBottomTabNavigator({
    Main: {
        screen: MainScreen,
    }
});


export default createAppContainer(createSwitchNavigator({ Start, MainNavigator },
    {
        initialRouteName: 'Start'
    }
));