using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorConvite
    {
        private RepositorioConvite persistencia;

        public GerenciadorConvite()
        {
            persistencia = new Persistencia.Persistence.RepositorioConvite();
        }

        public Convite Adicionar(Convite convite)
        {
            persistencia.Adicionar(convite);
            return convite;
        }

      

    }
}
