import React, { Component } from "react";
import Logo from "./xczxcz.png"
import Search from "./search.png"
import "./Home.css"
import Profile from "../Home/profile.png"
import { parseJwt } from '../../services/auth';


class Home extends Component {

  constructor() {
    super();
    this.state = {
      data: [],
      a: ''
    }
  }

  componentDidMount() {
    this.recuperarFilme()

  }

  recuperarFilme = () => {
    fetch('http://192.168.3.192:5000/api/lancamento')
      .then(response => response.json())
      .then(response => {
        this.setState({ data: response })
        console.log(response)
      })
      .catch(erro => console.log(erro));
  }

  seila = (event) => {
    event.preventDefault();
    this.setState({ a: event.target.value });
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
                </a>
              </div>
              {(localStorage.getItem("usuario-opflix") !== null) ? (
                <div className="botoesNav">
                  <ul>
                    <li><img className="profile1" src={Profile} width="30px"></img></li>
                    <li className="botao"><a href="" onClick={this.removerToken}>LOGOUT</a></li>
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
              <div className="Pesquisar">
                <input type="text" placeholder="pesquisar filme" onChange={this.seila} />
                <a href={"#" + this.state.a}>
                  <img src={Search} width="25px" />
                </a>
              </div>
            </div>
          </section>
        </header>
        <section>
          <div className="Filmes">
            {this.state.data.map((element) => {
              if (element.nomeLancamento == this.state.a) {

                return (
                  <div className="Ativo" id={element.nomeLancamento}>
                    <a>
                      <img src={element.imagem} width="144px" />
                    </a>

                  </div>

                )
              }
              else {

                return (
                  <div className="Filme" id={element.nomeLancamento}>
                    <div className="selecI">
                      <img src={element.imagem} width="144px" />
                    </div>
                  </div>
                )
              }

            })}

          </div>
        </section>
      </body>

    )
  };
}

export default Home;
