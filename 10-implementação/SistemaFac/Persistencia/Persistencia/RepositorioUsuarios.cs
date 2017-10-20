using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
   public class RepositorioUsuarios
    {
        private static List<Usuario> listaUsuario;

        static RepositorioUsuarios()
        {
            listaUsuario = new List<Usuario>();
        }

        public Usuario Adicionar( Usuario usuario)
        {
            usuario.Id = listaUsuario.Count + 1;
            listaUsuario.Add(usuario);
            return usuario;
        }

        public void remover(Usuario usuario)
        {
            int posicao = listaUsuario.FindIndex(e => e.Id == usuario.Id);
            listaUsuario.RemoveAt(posicao);
        }

        public void editar(Usuario usuario)
        {
            int posicao = listaUsuario.FindIndex(e => e.Id == usuario.Id);
          
            listaUsuario[posicao] = usuario;
        }

        public Usuario Obter(Func<Usuario, bool> where)
        {
            return listaUsuario.Where(where).FirstOrDefault();
        }

        public List<Usuario> ObterTodos()
        {
            return listaUsuario;
        }
    }


}
