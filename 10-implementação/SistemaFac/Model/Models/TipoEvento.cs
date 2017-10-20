
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Model.Models
{
    public class TipoEvento
    {

        private int id;
        private string descricao;
        private List<Servico> servicosAssociados;
        

        public TipoEvento(int id,string descricao, List<Servico> servicosAssociados)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.ServicosAssociados = ServicosAssociados;
        }

        public TipoEvento(string descricao)
        {
            this.Descricao = descricao;
            servicosAssociados = new List<Servico>();
        }

        public TipoEvento() : this(0,null, null) { }

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descricao
        {
          get { return descricao; }
          set { descricao = value; }
        }

        public List<Servico> ServicosAssociados
        {
            get { return servicosAssociados; }
            set { servicosAssociados = value; }
        }
    }
}