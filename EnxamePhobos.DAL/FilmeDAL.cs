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
                cmd = new MySqlCommand("SELECT filme.id,titulo,produtora,urlimg,genero.Genero,classificacao.Classificacao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON classificacao_id = classificacao.id ORDER BY filme.id ASC; ", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();//ListaVazia
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero"].ToString();
                    obj.Classificacao_Id = dr["Classificacao"].ToString();
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

        //busca filme
        public FilmeDTO SearchFilm(string objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM filme WHERE titulo = @Titulo;", conn);
                cmd.Parameters.AddWithValue("@Titulo", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
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



    }
}
