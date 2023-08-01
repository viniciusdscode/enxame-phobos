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

        //carrega ddl
        public List<GeneroDTO> CarregarDDList()
        {
            return objBLL.CarregaDDL();
        }

        //insert
        public void CadastrarFilmeBLL(FilmeDTO objCad)
        {
            objBLL.CadastrarFilme(objCad);
        }

        public FilmeDTO SearchByNameFilm(string objSearch)
        {
            return objBLL.SearchByName(objSearch);
        }

        //busca id
        public FilmeDTO SearchByIdFilm(int objSearch)
        {
            return objBLL.SearchIdFilm(objSearch);
        }

        //update
        public void UpdateFilm(FilmeDTO objUpdt)
        {
            objBLL.Update(objUpdt);
        }

        //delete
        public void DeleteUser(int objDel)
        {
            objBLL.Delete(objDel);
        }

        //Filter
        public List<FilmeDTO> FiltarFilmeBLL(string objFilter)
        {
            return objBLL.FiltrarFilme(objFilter);
        }

    }
}
