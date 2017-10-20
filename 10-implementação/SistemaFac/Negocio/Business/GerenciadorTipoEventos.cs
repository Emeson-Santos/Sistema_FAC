using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
   public class GerenciadorTipoEventos
    {
        private RepositorioTipoEvento persistencia;

        public GerenciadorTipoEventos()
        {
            persistencia = new RepositorioTipoEvento();
        }

        public TipoEvento Adicionar(TipoEvento tipoevento)
        {
            persistencia.Adicionar(tipoevento);
            return tipoevento;
        }

        public void Editar(TipoEvento tipoevento)
        {
            persistencia.Editar(tipoevento);
        }

        public void Remover(TipoEvento tipoevento)
        {
            persistencia.Remover(tipoevento);
        }

        public TipoEvento Obter(int? id)
        {
            return persistencia.Obter(e => e.Id == id);
        }

        public List<TipoEvento> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
    }
}
