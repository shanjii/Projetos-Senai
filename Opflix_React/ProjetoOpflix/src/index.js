import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { parseJwt } from './services/auth';


//pages
import Home from './Pages/Home/Home';
import Login from './Pages/Login/Login';
import Admin from './Pages/Admin/Admin';
import Filmes from './Pages/Filmes/Filmes';
//routes
import { Route, Link, BrowserRouter as Router, Switch, Redirect} from "react-router-dom";
import * as serviceWorker from './serviceWorker';

const RotaCliente = ({component: Component}) => (
    <Route 
        render={ props =>

           localStorage.getItem("usuario-opflix") !== null && parseJwt().Permissao === "CLIENTE" || localStorage.getItem("usuario-opflix") !== null && parseJwt().Permissao === "ADMINISTRADOR" ?
            (
                <Component {...props}/>
            ) : (
                <Redirect 
                    to={{pathname: "/login", state: {from: props.location}}}
                />
            )
        }
    />
)

const RotaAdmin = ({component: Component}) => (
    <Route 
        render={ props =>

           localStorage.getItem("usuario-opflix") !== null && parseJwt().Permissao === "ADMINISTRADOR"?
            (
                <Component {...props}/>
            ) : (
                <Redirect 
                    to={{pathname: "/login", state: {from: props.location}}}
                />
            )
        }
    />
)


const routing = (
    <Router>
        <div>
            <Switch>
                <Route exact path='/' component={Login} />
                <RotaCliente path='/home' component={Home} /> 
                <RotaAdmin path='/admin' component={Admin} />
                <Route path='/login' component={Login} />
                <Route path='/filmes' component={Filmes}/>
            </Switch>
        </div>
    </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();