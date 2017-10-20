using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Percistencia.Persistencia
{
    public class RepositorioDestinatario
    {
        private static List<Destinatario> listaDestinatario;

            static RepositorioDestinatario()
            {
                 listaDestinatario = new List<Destinatario>();
            }

            public Destinatario Adicionar(Destinatario destinatario)
            {
                destinatario.Id = listaDestinatario.Count + 1;
                listaDestinatario.Add(destinatario);
                return destinatario;
            }
            public void Editar(Destinatario destinatario)
            {
                int posicao = listaDestinatario.FindIndex(e => e.Id == destinatario.Id);
                listaDestinatario[posicao] = destinatario;
            }
            public void Remover(Destinatario destinatario)
            {
                int posicao = listaDestinatario.FindIndex(e => e.Id == destinatario.Id);
                listaDestinatario.RemoveAt(posicao);
            }
            public Destinatario Obter(Func<Destinatario, bool> where)
            {
                return listaDestinatario.Where(where).FirstOrDefault();
            }

            public List<Destinatario> ObterTodos()
            {
                return listaDestinatario;
            }

    }
}
