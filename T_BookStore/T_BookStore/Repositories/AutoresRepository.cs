using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using T_BookStore.Domains;

namespace T_BookStore.Repositories
{
    public class AutoresRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<AutoresDomain> ListarTodos()
        {
            List<AutoresDomain> autoresDomains = new List<AutoresDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "select * from Autores";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        AutoresDomain autoresDomain = new AutoresDomain
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = Convert.ToString(sdr["Nome"]),
                            Email = Convert.ToString(sdr["Email"]),
                            Ativo = Convert.ToInt32(sdr["Ativo"]),
                            DataNascimento = Convert.ToString(sdr["DataNascimento"])                            
                        };
                        autoresDomains.Add(autoresDomain);
                    }
                    return autoresDomains;
                }
            }
        }

        public void Cadastrar(AutoresDomain autoresDomain)
        {
            string Query = "INSERT INTO Autores (Nome,Email,Ativo,DataNascimento) VALUES (@Nome,@Email,@Ativo,@DataNascimento)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autoresDomain.Nome);
                cmd.Parameters.AddWithValue("@Email", autoresDomain.Email);
                cmd.Parameters.AddWithValue("@Ativo", autoresDomain.Ativo);
                cmd.Parameters.AddWithValue("@DataNascimento", autoresDomain.DataNascimento);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
