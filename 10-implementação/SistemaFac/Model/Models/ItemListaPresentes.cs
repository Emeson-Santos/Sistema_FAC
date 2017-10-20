
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model.Models {
    public class ItemListaPresentes
    {

        private int id;
        private string descricao;
       
        public ItemListaPresentes(string descricao,int id)
        {
            this.descricao = descricao;
            this.id = id;
        }
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



    }
}
