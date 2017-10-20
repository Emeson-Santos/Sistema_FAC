using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Percistencia.Persistencia
{
    public class RepositorioServico
    {
        private static List<Servico> listaServico;

        static RepositorioServico()
        {
            listaServico = new List<Servico>();
        }

        public Servico Adicionar(Servico servico)
        {
            servico.Id = listaServico.Count + 1;
            listaServico.Add(servico);
            return servico;
        }
        public void Editar(Servico servico)
        {
            int posicao = listaServico.FindIndex(e => e.Id == servico.Id);
            listaServico[posicao] = servico;
        }
        public void Remover(Servico servico)
        {
            int posicao = listaServico.FindIndex(e => e.Id == servico.Id);
            listaServico.RemoveAt(posicao);
        }
        public Servico Obter(Func<Servico, bool> where)
        {
            return listaServico.Where(where).FirstOrDefault();
        }

        public List<Servico> ObterTodos()
        {
            return listaServico;
        }
    }
}
