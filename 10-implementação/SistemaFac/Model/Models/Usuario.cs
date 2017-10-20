
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    
    public class Usuario
    {
        #region atributos

        public  int NvAcesso { get; set; }
        private int id;
        private string nome;
        private string rua;
        private int cep;
        private string bairro;
        private string numero;
        private DateTime datanascimento;
        private string email;
        private char sexo;
        private string cpf;
        private int rg;        
        private string uf;
        private string login;
        private string senha;
        private int contconvidadosconf;
        private List<Convite> listaconvite;
        private List<Feedback> enviarfeedback;
        private List<ListaPresentes> enviarlistapresentes;

        #endregion
        
        #region Construtores

        public Usuario(int id, string nome,string email,string login,string senha,int Tipo)
        {
            this.nome = nome;
            this.id = id;
            this.email = email;
            this.login = login;
            this.senha = senha;
        }

        public Usuario()
        {
        }

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required (ErrorMessage = "Obrigatorio Mostrar o Nome")] //Obrigatoria
        [StringLength(45, ErrorMessage = "No maximo 45 Caracteres")] //tamanho do texto se ultrapassar aparecem a mensagem de erro
        [Display (Name = "Nome Completo")] // é como se fosse um label pra depois vim o campo texto se não for colocado vai aparecer o nome exato do metodo 
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o Rua")]
        [StringLength(45, ErrorMessage = "No maximo 45 Caracteres")]
        [Display(Name = "Rua")]
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o Cep")]
        [Display(Name = "Cep")]
        [DataType(DataType.PostalCode)]
        public int Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o Bairro")]
        [StringLength(45, ErrorMessage = "No maximo 45 Caracteres")]
        [Display(Name = "Bairro")]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o Numero")]
        [StringLength(10, ErrorMessage = "No maximo 10 Caracteres")]
        [Display(Name = "Numero")]
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar a Dtata de Nascimento")]
        [DataType(DataType.Date)]
        [Display(Name = "Data  de Nascimento")]
        public DateTime DataNascimento
        {
            get { return datanascimento; }
            set { datanascimento = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o Email")]
        [StringLength(45, ErrorMessage = "No maximo 45 Caracteres")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o Sexo")]
       
        [Display(Name = "Sexo")]
        public char Sexo
        {
            //todo: fazer check box M e F 
            get { return sexo; }
            set { sexo = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o CPF")]
        [StringLength(200, ErrorMessage = "No maximo 14 Caracteres")]
        [Display(Name = "CPF")]
        public string CPF
         {
            get { return cpf; }
            set { cpf = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o RG")]//verificar converção
        [Display(Name = "RG")]
        public int Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar o UF")]
        [StringLength(2, ErrorMessage = "No maximo 2 Caracteres")]
        [Display(Name = "UF")]
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }

       // [Required(ErrorMessage = "Obrigatorio Mostrar o Login")]
        //[StringLength(45, ErrorMessage = "No maximo 45 Caracteres")]
        [Display(Name = "Login")]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
            
       // [Required(ErrorMessage = "Obrigatorio Mostrar o Senha")]
       [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        [Required(ErrorMessage = "Obrigatorio Mostrar a Quantidade de Convidados")]
        [Display(Name = "Quantidade de Convidados")]
        public int QuantConvidadosConf
        {
            get { return contconvidadosconf; }
            set { contconvidadosconf = value; }
        }

        public List<Convite> ListaConvites
        {
            get { return listaconvite; }
            set { listaconvite = value; }
        }

        public List<Feedback> EnviarFeedback
        {
            get { return enviarfeedback; }
            set { enviarfeedback = value; }
        }

        public List<ListaPresentes> EnviarListaPresentes
        {
            get { return enviarlistapresentes; }
            set { enviarlistapresentes = value; }
        }


        #endregion
    }
}