using System;
using System.Collections.Generic;
using Model.Models;
using Model.Models.Exceptions;
using Persistencia.Persistence;

namespace Negocio.Business
{
  public  class GerenciadorUsuario
    {
        private RepositorioUsuarios persistencia;

        public GerenciadorUsuario()
        {
            persistencia = new RepositorioUsuarios();
        }

        public Usuario  Adicionar(Usuario usuario)
        {
            persistencia.Adicionar(usuario);
            return usuario;
        }

        public void Editar(Usuario usuario)
        {
            persistencia.editar(usuario);
            
        }

        public void Remover(Usuario usuario)
        {
            persistencia.remover(usuario);
        }
        public Usuario ObterByLoginSenha(string login, string senha)
        {
            return persistencia.Obter(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
        }

        public bool BuscarPreCadastro(int? id, string email)
        {
            if (persistencia.Obter(e => e.Email.ToLowerInvariant().Equals(email.ToLowerInvariant()) &&
                 e.Id == id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Usuario Obter(int? id)
        {
            return persistencia.Obter(u => u.Id == id);
        }

        public List<Usuario> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
    }
}
