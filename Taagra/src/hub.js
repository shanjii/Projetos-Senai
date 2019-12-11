import home from '../src/assets/pages/home'
import { createStackNavigator } from 'react-navigation-stack';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';



const main = createStackNavigator({
    Home: {
        screen: home
    }
});


export default createAppContainer(createSwitchNavigator({
    main
}));