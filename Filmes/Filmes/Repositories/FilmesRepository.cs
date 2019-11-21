using Filmes.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Filmes.Repositories
{
    public class FilmesRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Filmes2;User Id=sa;Pwd=132;";



        public List<FilmesDomain> Listar()
        {
            List<FilmesDomain> filmes = new List<FilmesDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "Select Filmes.Id_Filmes, Genero.Id_Genero, Filmes.NomeFilme, Genero.NomeGenero from Filmes join Genero on Genero.Id_Genero = Filmes.Id_Genero";
                con.Open();

                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FilmesDomain filme = new FilmesDomain
                        {
                            Id_Filme = Convert.ToInt32(sdr["Id_Filmes"]),
                            NomeFilme = Convert.ToString(sdr["NomeFilme"]),
                            Genero = new GeneroDomain
                            {
                                Id_Genero = Convert.ToInt32(sdr["Id_Genero"]),
                                NomeGenero = Convert.ToString(sdr["NomeGenero"])
                            }
                            
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }      

        public FilmesDomain BuscarId(int id)
        {
            FilmesDomain filmes = new FilmesDomain();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "Select Filmes.Id_Filmes, Genero.Id_Genero, Filmes.NomeFilme, Genero.NomeGenero from Filmes join Genero on Genero.Id_Genero = Filmes.Id_Genero WHERE Id_Filmes = @Id_Filmes";
                con.Open();

                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Filmes", id);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {

                    while (sdr.Read())
                    {
                        FilmesDomain filme = new FilmesDomain
                        {
                            Id_Filme = Convert.ToInt32(sdr["Id_Filmes"]),
                            NomeFilme = Convert.ToString(sdr["NomeFilme"]),
                            Genero = new GeneroDomain
                            {
                                Id_Genero = Convert.ToInt32(sdr["Id_Genero"]),
                                NomeGenero = Convert.ToString(sdr["NomeGenero"])
                            }

                        };
                    return filme;
                    }
                    }
                    return null;
                }
            }
        }
    }
}
