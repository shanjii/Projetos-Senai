import React, { Component } from "react";
import Logo from "../Login/xczxcz.png"
import "./Login.css"
import Axios from 'axios'
import { parseJwt } from '../../services/auth';
import Profile from "../Home/profile.png"


class Login extends Component {

  constructor() {
    super();
    this.state = {
      data: [],
      login: '',
      senha: '',
      nomeUsuario: '',
      loginC: '',
      senhaC: '',
      nomeUsuarioC: ''

    }

  }



  recuperarLogin = () => {
    fetch('http://localhost:5000/api/usuario')
      .then(response => response.json())
      .then(response => {
        this.setState({ data: response })
        console.log(response)
      })
      .catch(erro => console.log(erro));
  }

  fillLogin = (event) => {
    this.setState({ login: event.target.value });
  }

  fillSenha = (event) => {
    this.setState({ senha: event.target.value });
  }
  fillNome = (event) => {
    this.setState({ nomeUsuario: event.target.value });
    console.log(event.target.value)

  }

  fillSenhaC = (event) => {
    this.setState({ senhaC: event.target.value });
    console.log(event.target.value)

  }
  fillNomeC = (event) => {
    this.setState({ nomeUsuarioC: event.target.value });
    console.log(event.target.value)

  }
  fillLoginC = (event) => {
    this.setState({ loginC: event.target.value });
  }

  removerToken = () => {
    this.props.history.push('/login');
    localStorage.removeItem("usuario-opflix");
    localStorage.removeItem("Email");
  }


  submitFormularioLogin = (event) => {
    event.preventDefault();
    localStorage.setItem("Email", this.state.login)
    Axios.post('http://192.168.3.192:5000/api/login', {
      email: this.state.login,
      senha: this.state.senha
    })
      .then(data => {
        localStorage.setItem("usuario-opflix", data.data.token);
        if (parseJwt().Permissao === "CLIENTE") {
          this.props.history.push('/home');
        } else {
          this.props.history.push('/admin');
        }
        console.log(data.data.token)
      })
  }

  submitFormularioCadastro = (event) => {
    event.preventDefault();
    Axios.post('http://192.168.3.192:5000/api/usuario', {
      nomeUsuario: this.state.nomeUsuarioC,
      email: this.state.loginC,
      senha: this.state.senhaC,
      permissao: "CLIENTE"

    })
      .then(
        this.props.history.push('/home')
      )
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
                </a>
              </div>
              {(localStorage.getItem("usuario-opflix") !== null) ? (
                <div className="botoesNav">
                  <ul>
                    <li><img className="profile1" src={Profile} width="30px"></img></li>
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
            <div className="form">
              <form className="formnav" onSubmit={this.submitFormularioLogin}>
                <input type="user" placeholder="email" value={this.state.login} onChange={this.fillLogin} />
                <input type="password" placeholder="senha" value={this.state.senha} onChange={this.fillSenha} />
                <button className="btnlog">
                  Login
              </button>
              </form>
            </div>
          </section>
        </header>
        <section className="Login">
          <div className="box">
            <div className="desc">
              <h1>Streaming de video OP!</h1>
            </div>
            <div className="formlog">
              <h1>Cadastre-se</h1>
              <form className="detail" onSubmit={this.submitFormularioCadastro}>
                <input className="text" placeholder="Nome" value={this.state.nomeUsuarioC} onChange={this.fillNomeC} type="user" />
                <input className="text" placeholder="Email" value={this.state.emailC} onChange={this.fillLoginC} type="email" />
                <input className="text" placeholder="Senha" value={this.state.senhaC} onChange={this.fillSenhaC} type="password" />
                <button className="submit">Cadastrar</button>
              </form>
            </div>
          </div>
        </section>
      </body>
    )
  };
}
export default Login;
