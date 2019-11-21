import login from './pages/user/login'
import cadastro from './pages/user/cadastro'
import splash from './pages/utilities/loading'
import filmes from './pages/filmes/main'
import filme from './pages/filmes/filme'
import lista from './pages/filmes/lista'
import { createStackNavigator } from 'react-navigation-stack';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { fadeOut, fromRight, fromBottom, fadeIn, zoomOut, zoomIn, fromTop } from 'react-navigation-transitions';



const Splashscreen = createStackNavigator(
    {
        Splash: {
            screen: splash
        }
    }
)

const user = createStackNavigator({
    Login: {
        screen: login
    },
    Cadastro: {
        screen: cadastro
    }
},
    {
        initialRouteName: 'Login',
        transitionConfig: () => fromTop(1000),
        cardStyle: {
            backgroundColor: "black",
          }
       
    });

const Liststack = createStackNavigator({
    Filmes: {
        screen: filmes
    },
    Lista: {
        screen: lista
    },
    Filme: {
        screen: filme
    }
},
{
    initialRouteName: 'Filmes',
    transitionConfig: () => fromBottom(1300),
    cardStyle: {
        backgroundColor: "black",
      }
}
)




// const Filmes = createStackNavigator({
//     Home: {
//         screen: start
//     },
// });

export default createAppContainer(createSwitchNavigator({
    Splashscreen,
    user,
    Liststack

    // Filmes
},
    {
        initialRouteName: 'Splashscreen'
    }
)
);