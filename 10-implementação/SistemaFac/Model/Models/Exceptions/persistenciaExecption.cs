using System;

namespace Model.Models.Exceptions
{
    class persistenciaExecption : SistemaFacExceptions
    {
        public persistenciaExecption(string mensagem, Exception excecao) : base(mensagem, excecao) { }
        public persistenciaExecption(string mensagem) : base(mensagem) { }
    }
}
