using System;

namespace Model.Models.Exceptions
{
    class NegocioException : SistemaFacExceptions
    {
        public NegocioException(string mensagem, Exception excecao) : base(mensagem, excecao) { }
        public NegocioException(string mensagem) : base(mensagem) { }
    }
}
