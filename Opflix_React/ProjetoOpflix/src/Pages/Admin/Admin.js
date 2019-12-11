import React, { Component } from "react";
import Logo from "../Home/xczxcz.png"
import Profile from "../Home/profile.png"
import Axios from 'axios'
import './Admin.css'

class Home extends Component {

    constructor() {
        super();
        this.state = {
            data: [],
            nomeLancamento: '',
            categoria: '',
            sinopse: '',
            tipo: '',
            duracao: '',
            lancamento: '',
            imagem: ''
        }
    }



    submitFormularioCadastro = (event) => {
        event.preventDefault();
        Axios.post('http://192.168.3.192:5000/api/lancamento', {

            nomeLancamento: this.state.nomeLancamento,
            categoria: this.state.categoria,
            sinopse: this.state.sinopse,
            tipo: this.state.tipo,
            duracao: this.state.duracao,
            lancamento: this.state.lancamento,
            imagem: this.state.imagem
        })
            .then(
                this.props.history.push('/home')
            )
    }



    fillNome = (event) => {
        this.setState({ nomeLancamento: event.target.value });
        console.log(this.state.nomeLancamento)

    }

    fillCategoria = (event) => {
        this.setState({ categoria: event.target.value });
        console.log(event.target.value)

    }

    fillSinopse = (event) => {
        this.setState({ sinopse: event.target.value });
        console.log(event.target.value)

    }

    fillTipo = (event) => {
        this.setState({ tipo: event.target.value });
        console.log(event.target.value)

    }

    fillDuracao = (event) => {
        this.setState({ duracao: event.target.value });
        console.log(event.target.value)

    }

    fillLancamento = (event) => {
        this.setState({ lancamento: event.target.value });
        console.log(event.target.value)

    }

    fillImagem = (event) => {
        this.setState({ imagem: event.target.value });
        console.log(event.target.value)

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
                                <a href="/">
                                    <img src={Logo} width="159px" />
                                </a>                        </div>
                            <div className="botoesNav">
                                <ul>
                                    <li className="botao"><a href="" onClick={this.removerToken}>LOGOUT</a></li>
                                    <li className="botao"><a href="/home">FILMES</a></li>
                                </ul>
                            </div>
                        </div>
                        <div>
                            <div className="Contatos">
                                <img className="profile" src={Profile} width="30px"></img>
                                <a href="">{localStorage.getItem("Email")}</a>
                            </div>
                        </div>
                    </section>
                </header>
                <div>
                </div>
                <div className="formlog1">
                    <h1>Cadastrar Filmes</h1>
                    <form className="detail" onSubmit={this.submitFormularioCadastro}>
                        <input className="text" placeholder="Filme" value={this.state.nomeLancamento} onChange={this.fillNome} type="text" />
                        <input className="text" placeholder="Categoria" value={this.state.categoria} onChange={this.fillCategoria} type="text" />
                        <input className="text" placeholder="Sinopse" value={this.state.sinopse} onChange={this.fillSinopse} type="text" />
                        <input className="text" placeholder="Tipo" value={this.state.tipo} onChange={this.fillTipo} type="text" />
                        <input className="text" placeholder="Duração" value={this.state.duracao} onChange={this.fillDuracao} type="text" />
                        <input className="text" value={this.state.lancamento} onChange={this.fillLancamento} type="date" />
                        <input className="text" placeholder="Imagem" value={this.state.imagem} onChange={this.fillImagem} type="text" />
                        <button className="submit1">Cadastrar</button>
                    </form>
                </div>
            </body>

        )
    };
}

export default Home;
