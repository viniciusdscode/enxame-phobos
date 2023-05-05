using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnxamePhobos.DAL;//
using EnxamePhobos.DDO;

namespace EnxamePhobos.BLL
{
    public class UsuarioBLL
    {
        //objeto para acessar todos os metodos da DAL
        UsuarioDAL objBLL = new UsuarioDAL();

        //autenticar
        public UsuarioDTO AutenticarUsuario(string objNome, string objSenha)
        {
            UsuarioDTO user = objBLL.Autenticar(objNome, objSenha);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Usuário não cadastradoBLL !");
            }
        }


        //Listar
        public List<UsuarioDTO> ListarUsuario()
        {
            return objBLL.Listar();
        }

        //carrega ddl
        public List<TipoUsuarioDTO> CarregaDDList()
        {
            return objBLL.CarregaDDL();
        }

        //busca nome
        public UsuarioDTO SearchByName(string objSearch)
        {
            return objBLL.SearchName(objSearch);
        }

        //busca id
        public UsuarioDTO SearchById(int objSearch)
        {
            return objBLL.SearchId(objSearch);
        }

        //cadastrar
        public void CadastrarUsuario(UsuarioDTO objCad)
        {
            objBLL.Cadastrar(objCad);
        }

        //update
        public void UpdateUser(UsuarioDTO objUpdt)
        {
            objBLL.Update(objUpdt);
        }

        //delete
        public void DeleteUser(int objDel)
        {
            objBLL.Delete(objDel);
        }        


    }
}
