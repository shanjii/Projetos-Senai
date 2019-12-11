import React, { Component } from "react";
import Logo from "../Home/xczxcz.png"
import Search from "../Home/search.png"
import Profile from "../Home/profile.png"
import { parseJwt } from '../../services/auth';
import './filme.css'

class Filmes extends Component {

    constructor() {
        super();
        this.state = {
            local: []
        }
    }

    componentDidMount = () => {
        this.recuperarFilme();
    }

    recuperarFilme = () => {
        fetch('http://192.168.3.192:5000/api/localizacao')
            .then(response => response.json())
            .then(response => {
                this.setState({ local: response[0] })
                console.log(response)
            })
            .catch(erro => console.log(erro));
    }

    removerToken = () => {
        this.props.history.push('/login');
        localStorage.removeItem("usuario-opflix");
        localStorage.removeItem("Email");
    }

    render() {
        return (
            <body>
                <header>
                    <section className="Nav">
                        <div className="flex">

                            <div className="Logo">
                                <a href="/home">
                                    <img src={Logo} width="159px" />
                                </a>
                            </div>
                            {(localStorage.getItem("usuario-opflix") !== null) ? (
                                <div className="botoesNav">
                                    <ul>
                                        <li className="botao"><a href="" onClick={this.removerToken}>LOGOUT</a></li>
                                        <li className="botao"><a href="/home">FILMES</a></li>
                                        {(localStorage.getItem("usuario-opflix") !== null && parseJwt().Permissao === "ADMINISTRADOR") ? (

                                            <li className="botao"><a href="/admin">ADMIN</a></li>

                                        ) : (
                                                <div />
                                            )
                                        }
                                    </ul>
                                </div>
                            ) : (
                                    <div />
                                )
                            }
                        </div>
                        <div>
                            <div className="Contatos">
                                <img className="profile" src={Profile} width="30px"></img>

                                <a href="">{localStorage.getItem("Email")}</a>
                            </div>
                        </div>
                    </section>
                </header>
                <div style={{ display: "flex", justifyContent: "left", marginLeft: 30, marginTop: 30, marginBottom: 30 }}>
                    <div>
                        <img className='Filmes1' width='350' style={{ borderRadius: 10 }} src={localStorage.getItem('filmeImagem')} />
                    </div>
                    <div style={{ marginLeft: '10%', marginRight: '20%' }}>
                        <p style={{ fontFamily: 'Bebas Neue', fontSize: 60 }}>{localStorage.getItem('filmeNome')}</p>
                        <p style={{ fontFamily: 'Bebas Neue', fontSize: 20, color: "#d4d4d4" }}>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ac varius nulla. Nullam ac sem accumsan ante consequat ultricies. Aenean non neque elit. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Morbi venenatis vehicula dui non volutpat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Quisque rhoncus nisi sed ex ullamcorper pellentesque. Vivamus at leo quis lacus accumsan consectetur vel vitae magna. Mauris id ipsum lectus. Sed id dapibus nunc, et finibus ipsum. Quisque laoreet purus a elit blandit volutpat. Sed cursus lacinia magna, ut aliquam mauris vehicula ut. </p>
                        <p>{this.state.local.latitude}</p>
                        <p>{this.state.local.longitude}</p>
                    </div>
                </div>
            </body>

        )
    }
}

export default Filmes