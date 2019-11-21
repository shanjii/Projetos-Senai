using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using T_BookStore.Domains;

namespace T_BookStore.Repositories
{
    public class LivrosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<LivrosDomain> ListarTodos()
        {
            List<LivrosDomain> livrosDomains = new List<LivrosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "select Livros.IdLivro, Livros.Titulo, Autores.IdAutor, Autores.Nome, Autores.Email, Autores.Ativo, Autores.DataNascimento, Generos.IdGenero, Generos.Descricao from Livros  join Autores on Autores.IdAutor = Livros.IdAutor  join Generos on Generos.IdGenero = Livros.IdGenero";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        LivrosDomain livroDomain = new LivrosDomain
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                            Titulo = Convert.ToString(sdr["Titulo"]),
                            Autores = new AutoresDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                Nome = Convert.ToString(sdr["Nome"]),
                                Email = Convert.ToString(sdr["Email"]),
                                Ativo = Convert.ToInt32(sdr["Ativo"]),
                                DataNascimento = Convert.ToString(sdr["DataNascimento"])
                            },
                            Generos = new GenerosDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Descricao = Convert.ToString(sdr["Descricao"])
                            }
                        };
                        livrosDomains.Add(livroDomain);
                    }
                    return livrosDomains;
                }
            }
        }

        public void Cadastrar(LivrosDomain livrosDomain)
        {
            string Query = "INSERT INTO Livros (Titulo, IdAutor, IdGenero) VALUES (@Titulo, @IdAutor, @IdGenero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", livrosDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdAutor", livrosDomain.IdAutor);
                cmd.Parameters.AddWithValue("@IdGenero", livrosDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public LivrosDomain BuscarId(int id)
        {
            LivrosDomain generoDomain = new LivrosDomain();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String Query = "select Livros.IdLivro, Livros.Titulo, Autores.IdAutor, Autores.Nome, Autores.Email, Autores.Ativo, Autores.DataNascimento, Generos.IdGenero, Generos.Descricao from Livros  join Autores on Autores.IdAutor = Livros.IdAutor  join Generos on Generos.IdGenero = Livros.IdGenero WHERE IdLivro = @IdLivro";
                con.Open();

                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdLivro", id);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {

                        while (sdr.Read())
                        {
                            LivrosDomain livroDomain = new LivrosDomain
                            {
                                IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                                Titulo = Convert.ToString(sdr["Titulo"]),
                                Autores = new AutoresDomain
                                {
                                    IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                    Nome = Convert.ToString(sdr["Nome"]),
                                    Email = Convert.ToString(sdr["Email"]),
                                    Ativo = Convert.ToInt32(sdr["Ativo"]),
                                    DataNascimento = Convert.ToString(sdr["DataNascimento"])
                                },
                                Generos = new GenerosDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Descricao = Convert.ToString(sdr["Descricao"])
                                }
                            };
                            return livroDomain;
                        }
                    }
                    return null;
                }
            }
        }

        public void Atualizar(LivrosDomain livrosDomain)
        {
            string Query = "UPDATE Livros SET Titulo = @Titulo WHERE IdLivro = @IdLivro";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdLivro", livrosDomain.IdLivro);
                cmd.Parameters.AddWithValue("@Titulo", livrosDomain.Titulo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Livros WHERE IdLivro = @IdLivro";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdLivro", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
