using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Percistencia.Persistencia;
using Persistencia.Persistence;
using Model.Models;
namespace Negocio.Business
{
    public class GerenciadorListaPresentes
    {
        private RepositorioListaPresente persistencia;

        public GerenciadorListaPresentes()
        {
            persistencia = new RepositorioListaPresente();
        }

        public ListaPresentes Adicionar(ListaPresentes listaPresentes)
        {
            persistencia.Adicionar(listaPresentes);
            return listaPresentes;
        }
        /*
        public void Editar(ListaPresentes listaPresentes)
        {
            persistencia.Editar(listaPresentes);
        }

        public void Remover(ListaPresentes listaPresentes)
        {
            persistencia.Remover(listaPresentes);
        }

        public ListaPresentes Obter(int? id)
        {
            return persistencia.Obter(e => e.Id == id);
        }

        public List<ListaPresentes> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
        */
    }
}
