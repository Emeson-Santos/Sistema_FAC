using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Percistencia.Persistencia;

namespace Negocio.business
{
    public class GerenciadorDestinatario
    {
        private RepositorioDestinatario persistencia;

        public GerenciadorDestinatario()
        {
            persistencia = new RepositorioDestinatario();
        }

        public Destinatario Adicionar(Destinatario destinatario)
        {
            persistencia.Adicionar(destinatario);
            return destinatario;
        }

        public void Editar(Destinatario destinatario)
        {
            persistencia.Editar(destinatario);
        }

        public void Remover(Destinatario destinatario)
        {
            persistencia.Remover(destinatario);
        }

        public Destinatario Obter(int id)
        {
            return persistencia.Obter(e => e.Id == id);
        }

        public List<Destinatario> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
    }
}
