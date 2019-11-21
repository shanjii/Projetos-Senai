using ProjetoFuncionarios.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFuncionarios.Repositories
{
    public class FuncionariosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        //--------------------------------------------------------------------------------------------------------//


        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "Select * FROM Funcionarios";
                con.Open();

                SqlDataReader sdr;


                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            Id_Funcionario = Convert.ToInt32(sdr["Id_Funcionario"]),
                            Nome = Convert.ToString(sdr["Nome"]),
                            Sobrenome = Convert.ToString(sdr["Sobrenome"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public FuncionariosDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "Select * FROM Funcionarios WHERE Id_Funcionario = @Id_Funcionario";
                con.Open();

                SqlDataReader sdr;


                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Funcionario", id);
                    sdr = cmd.ExecuteReader();
                    if(sdr.HasRows)
                    {
                        while (sdr.Read())
                        {

                            FuncionariosDomain funcionario = new FuncionariosDomain
                            {
                                Id_Funcionario = Convert.ToInt32(sdr["Id_Funcionario"]),
                                Nome = Convert.ToString(sdr["Nome"]),
                                Sobrenome = Convert.ToString(sdr["Sobrenome"])
                            };
                        return funcionario;
                        }
                    }
                    return null;
                }
            }
        
        }

        public void Cadastrar(FuncionariosDomain funcionariosDomain)
        {
            string Query = "INSERT INTO Funcionarios VALUES (@Nome , @Sobrenome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionariosDomain.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE Id_Funcionario = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id",id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void Atualizar (FuncionariosDomain funcionariosDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome , Sobrenome = @Sobrenome WHERE Id_Funcionario = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", funcionariosDomain.Id_Funcionario);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionariosDomain.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
