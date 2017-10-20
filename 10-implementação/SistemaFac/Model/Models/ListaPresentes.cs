
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Models {
    public class ListaPresentes
    {

        private int id;
        private List<Empresa> empresa;
        private List<ItemListaPresentes> itens;


        public ListaPresentes(int id, List<Empresa> empresa,List<ItemListaPresentes> itens)
        {
            this.id = id;
            this.empresa = empresa;
            this.itens = itens;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public List<Empresa> Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public List<ItemListaPresentes> Itens
        {
           get { return itens; }
            set { itens = value; }
        }

    }

}