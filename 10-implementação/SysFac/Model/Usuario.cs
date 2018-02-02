using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Usuario
    {
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

        public Usuario() { }
        public Usuario(int id, string nome, string rua, int cep, string bairro, string numero, DateTime datanascimento, string email, char sexo, string cpf, int rg, string uf, string login, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Rua = rua;
            this.Cep = cep;
            this.Bairro = bairro;
            this.Numero = numero;
            this.Datanascimento = datanascimento;
            this.Email = email;
            this.Sexo = sexo;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Uf = uf;
            this.Login = login;
            this.Senha = senha;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Rua { get => rua; set => rua = value; }
        public int Cep { get => cep; set => cep = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Numero { get => numero; set => numero = value; }
        public DateTime Datanascimento { get => datanascimento; set => datanascimento = value; }
        public string Email { get => email; set => email = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public int Rg { get => rg; set => rg = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}