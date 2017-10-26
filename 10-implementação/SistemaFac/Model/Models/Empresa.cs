using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Empresa
    {

       
        private int id;
        private string razaoSocial;
        private string rua;
        private string bairro;
        private int cep;
        private int numero;
        private string cidade;
        private string uf;
        private int telefone;
        private string email;
        private byte imagem;
        private List<TipoEvento> eventosFornecidos;
        private string login;
        private string senha;
        private bool isPrestadorServico;
        private List<Feedback> receberFeedback;
        private List<ListaPresentes> receberListaPresentes;

      

        public Empresa(int id, string razaoSocial , string rua, string bairro , string cidade, string login,string senha)
        {
            this.id = id;
            this.razaoSocial = razaoSocial;
            this.rua = rua;
            this.bairro = bairro;
            this.cidade = cidade;
            this.login = login;
            this.senha = senha;
        }
        public Empresa()
        {
        }

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "Por favor, informe a sua Razão Social!!")] //Obrigatoria      
        [Display(Name = "Razão Social: ")]
        public string RazaoSocial
        {
            get { return razaoSocial; }
            set { razaoSocial = value; }
        }
        [Required(ErrorMessage = "Por favor, informe o nome da Rua!!")] //Obrigatoria      
        [Display(Name = "Rua: ")]
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }
        [Required(ErrorMessage = "Por favor, informe o nome do Bairro!!")] //Obrigatoria      
        [Display(Name = "Bairro: ")]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        [Required(ErrorMessage = "Por favor, informe o Numero do CEP!!")] //Obrigatoria
        [DataType(DataType.PostalCode)]
        [Display(Name = "Razão Social: ")]
        public int Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        [Required(ErrorMessage = "Por favor, informe o Numero da Casa!!")] //Obrigatoria      
        [Display(Name = "Numero da Casa: ")]
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        [Required(ErrorMessage = "Por favor, informe o Nome da Cidade!!")] //Obrigatoria      
        [Display(Name = "Cidade: ")]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        [Required(ErrorMessage = "Por favor, informe a UF do Estado!")] //Obrigatoria      
        [Display(Name = "UF: ")]
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }
        [Required(ErrorMessage = "Por favor, informe o Numero de Telefone!")] //Obrigatoria      
        [Display(Name = "Telefone: ")]
        public int Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        [Required(ErrorMessage = "Por favor, informe o Email!")] //Obrigatoria      
        [Display(Name = "Email: ")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [Required(ErrorMessage = "Por favor, insira uma imagem!!")] //Obrigatoria      
        [DataType(DataType.ImageUrl)]//varificar se isto aqui eta correto
        [Display(Name = "Imagem: ")]
        public byte Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }
      
        [Required(ErrorMessage = "Por favor, informe o Login!")] //Obrigatoria      
        [Display(Name = "Login: ")]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        [Required(ErrorMessage = "Por favor, informe a sua senha!")] //Obrigatoria
        [DataType(DataType.Password)]
        [Display(Name = "Senha: ")]
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        /*
        public bool IsPrestadorServico
        {
            get { return isPrestadorServico; }
            set { isPrestadorServico = value; }
        }
        */

        public List<TipoEvento> EventosFornecidos
        {
            get { return eventosFornecidos; }
            set { eventosFornecidos = value; }
        }

        public List<Feedback> ReceberFeedback
        {
            get { return receberFeedback; }
            set { receberFeedback = value; }
        }

       
        public List<ListaPresentes> ReceberListaPresentes
        {
            get { return receberListaPresentes; }
            set { receberListaPresentes = value; }
        }

        public int NvAcesso { get; set; }
    }
}
