using System;


namespace Model.Models.Exceptions
{
    class SistemaFacExceptions :Exception
    {
        public SistemaFacExceptions(string mensagem, Exception excecao) : base(mensagem, excecao) { }
        public SistemaFacExceptions(string mensagem) : base(mensagem) { }
    }
}
