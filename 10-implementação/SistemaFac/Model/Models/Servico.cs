
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.Models
{

    public class Servico
    {

        private int id;
        private string descricao;
        private string nome { get; set; }

        public Servico(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }


        public Servico(string descricao)
        {
            this.Descricao = descricao;
        }

        public Servico() : this(0, null) { }
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "Obrigatorio preencher o Campo Vasio")] //Obrigatoria
        [StringLength(45, ErrorMessage = "No maximo 45 Caracteres")] //tamanho do texto se ultrapassar aparecem a mensagem de erro
        [Display(Name = "Nome do tipo de serviço")] // é como se fosse um label pra depois vim o campo texto se não for colocado vai aparecer o nome exato do metodo 
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

    }
}
