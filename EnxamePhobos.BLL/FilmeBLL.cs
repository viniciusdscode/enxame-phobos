using EnxamePhobos.DAL;
using EnxamePhobos.DDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.BLL
{
    public class FilmeBLL
    {
        //objeto para acessar todos os metodos da DAL
        FilmeDAL objBLL = new FilmeDAL();

        //Listar
        public List<FilmeDTO> ListarFilme()
        {
            return objBLL.Listar();
        }

        //busca nome
        public FilmeDTO SearchByFilm(string objSearch)
        {
            return objBLL.SearchFilm(objSearch);
        }

    }
}
