using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Percistencia.Persistencia
{
    public class RepositorioFeedback
    {
        private static List<Feedback> listaFeedback;

        static RepositorioFeedback()
        {
            listaFeedback = new List<Feedback>();
        }

        public Feedback Adicionar(Feedback feedback)
        {
            feedback.Id = listaFeedback.Count + 1;
            listaFeedback.Add(feedback);
            return feedback;
        }
        public void Editar(Feedback feedback)
        {
            int posicao = listaFeedback.FindIndex(e => e.Id == feedback.Id);
            listaFeedback[posicao] = feedback;
        }
        public void Remover(Feedback feedback)
        {
            int posicao = listaFeedback.FindIndex(e => e.Id == feedback.Id);
            listaFeedback.RemoveAt(posicao);
        }
        public Feedback Obter(Func<Feedback, bool> where)
        {
            return listaFeedback.Where(where).FirstOrDefault();
        }

        public List<Feedback> ObterTodos()
        {
            return listaFeedback;
        }
    }
}