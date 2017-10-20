using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    class repositorioItemListaPresentes
    {

        private static List<ItemListaPresentes> listapresentes;

        static repositorioItemListaPresentes()
        {
            listapresentes = new List<ItemListaPresentes>();
        }

        public ItemListaPresentes Adicionar(ItemListaPresentes presente)
        {
            presente.Id = listapresentes.Count + 1;
            listapresentes.Add(presente);
            return presente;
        }

        public void Editar(ItemListaPresentes presente)
        {
            int posicao = listapresentes.FindIndex(e => e.Id == presente.Id);
            listapresentes[posicao] = presente;
        }

        public void Remover(ItemListaPresentes presente)
        {
            int posicao = listapresentes.FindIndex(e => e.Id == presente.Id);
            listapresentes.RemoveAt(posicao);
        }

        public ItemListaPresentes Obter(Func<ItemListaPresentes, bool> where)
        {
            return listapresentes.Where(where).FirstOrDefault();
        }

        public List<ItemListaPresentes> ObterTodos()
        {
            return listapresentes;
        }
    }
}
