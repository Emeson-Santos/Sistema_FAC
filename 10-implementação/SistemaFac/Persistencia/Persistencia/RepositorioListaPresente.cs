using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    public class RepositorioListaPresente
    {
        private static List<ListaPresentes> ListaConvite;

        static RepositorioListaPresente()
        {
            ListaConvite = new List<ListaPresentes>();
        }

        public ListaPresentes Adicionar(ListaPresentes listaPresentes)
        {

            ListaConvite.Add(listaPresentes);
            return listaPresentes;
        }
    }
}
