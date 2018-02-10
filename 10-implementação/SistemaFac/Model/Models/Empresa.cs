using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Empresa : Usuario
    {


        private int idEmpresa;
        private String rasaoSocial;

        public Empresa()
        {
        }

        [Required]
        [Display(Name = "ID Empresa")]
        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        [Required]
        [Display (Name = "Rasão Social")]
        public String RasaoSocial
        {
            get { return rasaoSocial; }
            set { rasaoSocial = value; }
        }
    }
}
