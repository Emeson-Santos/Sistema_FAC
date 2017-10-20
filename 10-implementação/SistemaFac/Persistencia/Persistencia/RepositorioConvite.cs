using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    public class RepositorioConvite
    {
        private static List<Convite> ListaConvite;

        static RepositorioConvite()
        {
            ListaConvite = new List<Convite>();
        }

        public Convite Adicionar (Convite convite)
        {
            
            ListaConvite.Add(convite);
            return convite;
        }
    }
}
