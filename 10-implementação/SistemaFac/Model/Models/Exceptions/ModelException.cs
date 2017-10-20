using System;
namespace Model.Models.Exceptions
{
    class ModelException : SistemaFacExceptions
    {
        public ModelException(string mensagem, Exception excecao) : base(mensagem, excecao) { }
        public ModelException(string mensagem) : base(mensagem) { }
    }
}
