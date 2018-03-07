
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Model.Models
{
    public enum TipoUsuario { USUARIO, EMPRESA, ADMINISTRADOR }

    public class Usuario
    {
        #region atributos
        private int idUsuario;
        private string nomeUsuario;
        private int matriculaUsuario;
        private int tipoUsuario;
        private string emailUsuario;
        private string senhaUsuario;
        private string nomeMae;
        private string endereco;
        private string bairro;
        private string cep;
        private string cidade;
        private DateTime dataNascimento;

        /*
         * 
        //private int NvAcesso;
        private int id;

        private string nome;
        private int tipoUsuario; //n
        private string rua;
        private int cep;
        private string bairro;
        private string numero;
        private DateTime datanascimento;
        private string email;
        private char sexo;
        private string cpf;
        private int rg;

        // private string uf;
        private string login;
        private string senha;

        // private bool isPrestadorServico;//varificar esse atributo
        //  private int contconvidadosconf;
        private List<Convite> listaconvite;

        private List<Feedback> enviarfeedback;
        private List<ListaPresentes> enviarlistapresentes;
        */
        #endregion

        #region Construtores

        public Usuario() { }

        public Usuario(string email, string senha, int tipo, int matricula, int identificador)
        {
            idUsuario = identificador;
            emailUsuario = email;
            senhaUsuario = senha;
            tipoUsuario = tipo;
            matriculaUsuario = matricula;
        }
        /*
        public Usuario(){}

        public Usuario(int id, string nome, string email, string login, string senha, int tipo)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.login = login;
            this.senha = senha;
            this.tipoUsuario = tipo;
        }*/

        #endregion

        #region Propriedades
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(300, MinimumLength = 2)]
        [Display(Name = "Nome Completo")]
        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Matricula")]
        public int MatriculaUsuario
        {
            get { return matriculaUsuario; }
            set { matriculaUsuario = value; }
        }

        [Key]
        [Display(Name = "ID Usuário")]
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        [StringLength(200, MinimumLength = 5)]
        [Display(Name = "Endereço")]
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        [StringLength(200, MinimumLength = 10)]
        [Display(Name = "Bairro")]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        [StringLength(40, MinimumLength = 6)]
        [Display(Name = "CEP")]
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        [StringLength(40, MinimumLength = 10)]
        [Display(Name = "Cidade")]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "Mãe")]
        public string NomeMae
        {
            get { return nomeMae; }
            set { nomeMae = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, MinimumLength = 10)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailUsuario
        {
            get { return emailUsuario; }
            set { emailUsuario = value; }
        }

        [Required]
        [StringLength(200, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string SenhaUsuario
        {
            get { return senhaUsuario; }
            set { senhaUsuario = value; }
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        
                [Display(Name = "Nivel de Usuário")]
                public int TipoUsuario
                {
                    get { return tipoUsuario; }
                    set { tipoUsuario = value; }
                }

       
        #endregion
    }
}