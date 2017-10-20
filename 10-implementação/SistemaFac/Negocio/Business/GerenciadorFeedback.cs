using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Percistencia.Persistencia;

namespace Negocio.business
{
    public class GerenciadorFeedback
    {
        private RepositorioFeedback persistencia;

        public GerenciadorFeedback()
        {
            persistencia = new RepositorioFeedback();
        }

        public Feedback Adicionar(Feedback feedback)
        {
            persistencia.Adicionar(feedback);
            return feedback;
        }

        public void Editar(Feedback feedback)
        {
            persistencia.Editar(feedback);
        }

        public void Remover(Feedback feedback)
        {
            persistencia.Remover(feedback);
        }

        public Feedback Obter(int id)
        {
            return persistencia.Obter(F => F.Id == id);
        }

        public List<Feedback> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
    }
}
