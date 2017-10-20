using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    public class RepositorioTipoEvento
    {
        private static List<TipoEvento> ListaTipoEvento;

        static RepositorioTipoEvento()
        {
          ListaTipoEvento = new List<TipoEvento>();
        }

        public TipoEvento Adicionar(TipoEvento tipoevento)
        {
            tipoevento.Id = ListaTipoEvento.Count + 1;
            ListaTipoEvento.Add(tipoevento);
            return tipoevento;
        }

        public void Editar(TipoEvento tipoevento)
        {
            int posicao = ListaTipoEvento.FindIndex(e => e.Id == tipoevento.Id);
            ListaTipoEvento[posicao] = tipoevento;
        }

        public void Remover(TipoEvento tipoevento)
        {
            int posicao = ListaTipoEvento.FindIndex(e => e.Id == tipoevento.Id);
            ListaTipoEvento.RemoveAt(posicao);
        }

        public TipoEvento Obter(Func<TipoEvento, bool> where)
        {
            return ListaTipoEvento.Where(where).FirstOrDefault();
        }

        public List<TipoEvento> ObterTodos()
        {
            return ListaTipoEvento;
        }

    }
}
