using Filmes.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Filmes.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Filmes2;User Id=sa;Pwd=132;";

        public List<GeneroDomain> Listar()
        {

            List<GeneroDomain> generos = new List<GeneroDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "Select * From Genero";
                con.Open();

                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            Id_Genero = Convert.ToInt32(sdr["Id_Genero"]),
                            NomeGenero = Convert.ToString(sdr["NomeGenero"]),
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public GeneroDomain BuscarId(int id)
        {
            GeneroDomain generoDomain = new GeneroDomain();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "Select * from Genero WHERE Id_Genero = @Id_Genero";
                con.Open();

                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Genero", id);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {

                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain
                            {
                                Id_Genero = Convert.ToInt32(sdr["Id_Genero"]),
                                NomeGenero = Convert.ToString(sdr["NomeGenero"]),
                            };
                            return genero;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(GeneroDomain generoDomain)
        {
            string Query = "INSERT INTO Genero (NomeGenero) VALUES (@NomeGenero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@NomeGenero", generoDomain.NomeGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
