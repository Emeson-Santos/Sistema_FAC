using System;


namespace Model.Models.Exceptions
{
    class ControllerException : SistemaFacExceptions
    {
        public ControllerException(string mensagem, Exception excecao) : base(mensagem, excecao) { }
        public ControllerException(string mensagem) : base(mensagem) { }
    }
}
