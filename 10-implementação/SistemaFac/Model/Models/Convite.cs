
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Model.Models
{
    public class Convite
    {
        private bool confirmado;
        private string endereco;
        private List<Destinatario> destinatarios;
        private string linkLocalizacao;
    
        public Convite(string endereco = null, string linkLocalizacao = null)
        {
            this.Endereco = Endereco;
            this.LinkLocalização = LinkLocalização;
            this.Confirmado = Confirmado;
            this.Destinatarios = Destinatarios;
        }

        public bool Confirmado
        {
            get { return confirmado; }
            set { confirmado = value; }
        }

        public List<Destinatario> Destinatarios
        {
            get { return destinatarios; }
            set { destinatarios = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string LinkLocalização
        {
            get { return linkLocalizacao; }
            set { linkLocalizacao = value; }
        }
    }
}