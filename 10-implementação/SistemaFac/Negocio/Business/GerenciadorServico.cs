using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Percistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadorServico
    {
        private RepositorioServico persistencia;

        public GerenciadorServico()
        {
            persistencia = new RepositorioServico();
        }

        public Servico Adicionar(Servico servico)
        {
            persistencia.Adicionar(servico);
            return servico;
        }

        public void Editar(Servico servico)
        {
            persistencia.Editar(servico);
        }

        public void Remover(Servico servico)
        {
            persistencia.Remover(servico);
        }

        public Servico Obter(int? id)
        {
            return persistencia.Obter(e => e.Id == id);
        }

        public List<Servico> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
    }
}
