
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Destinatario
    {

        private int id;
        private string email;

        
        public Destinatario(string email, int id)
        {
            this.email = email;
            this.id = id;

        }

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        [Required(ErrorMessage = "É Obrigatorio Giditar o email")] //Obrigatoria
        [StringLength(45, ErrorMessage = "No maximo 45 Caracteres")] //tamanho do texto se ultrapassar aparecem a mensagem de erro
        [Display(Name = "Email")] // é como se fosse um label pra depois vim o campo texto se não for colocado vai aparecer o nome exato do metodo 
        public string Email
        {
            get { return email; }
            set { email = value; }
        }


    }
}
