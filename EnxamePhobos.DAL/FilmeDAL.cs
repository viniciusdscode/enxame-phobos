using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//
using EnxamePhobos.DDO;//

namespace EnxamePhobos.DAL
{
    public class FilmeDAL : Conexao
    {
        //CRUD
        //List
        public List<FilmeDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.id,titulo,produtora,urlimg,genero.DescricaoGenero,classificacao.DescricaoClassificacao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON classificacao_id = classificacao.id ORDER BY filme.id ASC; ", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();//ListaVazia
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["DescricaoGenero"].ToString();
                    obj.Classificacao_Id = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(obj);


                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda aqui !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        } 

        //insert
        public void CadastrarFilme(FilmeDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO filme (Titulo,Produtora,UrlImg,Genero_Id,Classificacao_Id) Values (@Titulo,@Produtora,@UrlImg,@Genero_Id,@Classificacao_Id)", conn);
                cmd.Parameters.AddWithValue("@Titulo", objCad.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", objCad.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objCad.UrlImg);
                cmd.Parameters.AddWithValue("@Genero_Id", objCad.Genero_Id);
                cmd.Parameters.AddWithValue("@Classificacao_Id", objCad.Classificacao_Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao cadastrar !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //carrega ddl
        public List<GeneroDTO> CarregaDDL()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>();
                while (dr.Read()) 
                {
                    GeneroDTO obj = new GeneroDTO();
                    obj.ID = Convert.ToInt32(dr["ID"]);
                    obj.DescricaoGenero = dr["DescricaoGenero"].ToString();
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //carrega ddl
        public List<ClassificacaoDTO> CarregaDDLClassif()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Classificacao;", conn);
                dr = cmd.ExecuteReader();
                List<ClassificacaoDTO> Lista = new List<ClassificacaoDTO>();
                while (dr.Read())
                {
                    ClassificacaoDTO obj = new ClassificacaoDTO();  
                    obj.ID = Convert.ToInt32(dr["ID"]);
                    obj.DescricaoClassificacao = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //busca por nome
        public FilmeDTO SearchByName(string objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.id,Titulo,produtora,UrlImg,genero_id, DescricaoClassificacao FROM filme INNER JOIN classificacao ON classificacao_id = classificacao.id WHERE filme.Titulo = @Titulo;", conn);
                cmd.Parameters.AddWithValue("@Titulo", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["ID"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero_Id"].ToString();
                    obj.Classificacao_Id = dr["DescricaoClassificacao"].ToString();

                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !!" + ex.Message);
            }
            finally
            {
                Desconectar() ;
            }


        }

        //busca por id
        public FilmeDTO SearchIdFilm(int objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM filme WHERE filme.id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["ID"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero_Id"].ToString();
                    obj.Classificacao_Id = dr["Classificacao_Id"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //update
        public void Update(FilmeDTO objUpdt)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE filme SET Titulo=@Titulo, Produtora=@Produtora, UrlImg=@UrlImg, Genero_Id=@DescricaoGenero, Classificacao_Id=@DescricaoClassificacao WHERE filme.Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objUpdt.Id);
                cmd.Parameters.AddWithValue("@Titulo", objUpdt.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", objUpdt.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objUpdt.UrlImg);
                cmd.Parameters.AddWithValue("@DescricaoGenero", objUpdt.Genero_Id);
                cmd.Parameters.AddWithValue("@DescricaoClassificacao", objUpdt.Classificacao_Id); 
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //delete
        public void Delete(int objDel)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM filme WHERE filme.Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", objDel);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //filtro genero
        public List<FilmeDTO> FiltrarFilme(string objFilter)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.id,Titulo,Produtora,UrlImg,DescricaoGenero,DescricaoClassificacao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON classificacao_Id = classificacao.id WHERE DescricaoGenero = @genero;", conn);
                cmd.Parameters.AddWithValue("@genero", objFilter);
                dr = cmd.ExecuteReader();
                //lista vazia
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                while (dr.Read()) 
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["ID"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["DescricaoGenero"].ToString();
                    obj.Classificacao_Id = dr["DescricaoClassificacao"].ToString();

                    //add lista
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar registros !!" + ex.Message);

            }
            finally 
            {
                Desconectar();
            }
        }
    }
}
