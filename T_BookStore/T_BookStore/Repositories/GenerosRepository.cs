using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using T_BookStore.Domains;

namespace T_BookStore.Repositories
{
    public class GenerosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<GenerosDomain> ListarTodos()
        {
            List<GenerosDomain> generosDomains = new List<GenerosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "select * from Generos";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        GenerosDomain generosDomain = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Descricao = Convert.ToString(sdr["Descricao"])
                        };
                        generosDomains.Add(generosDomain);
                    }
                    return generosDomains;
                }
            }
        }

        public void Cadastrar(GenerosDomain generosDomain)
        {
            string Query = "INSERT INTO Generos (Descricao) VALUES (@Genero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Genero", generosDomain.Descricao);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
