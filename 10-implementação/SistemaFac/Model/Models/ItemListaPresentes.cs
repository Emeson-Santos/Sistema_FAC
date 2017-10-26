
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "Por favor, Informe o item da Lista!")]
        [Display(Name = "presente:")]
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }



    }
}
