using System;
using System.Web;

namespace SistemaFac.Util
{
    public enum SessionKey { USUARIO }

    public static class SessionHelper
    {
        public static Object Get(SessionKey chave)
        {
            String chaveString = Enum.GetName(typeof(SessionKey), chave);
            return HttpContext.Current.Session[chaveString];
        }

        public static Object Set(SessionKey chave, Object valor)
        {
            String chaveString = Enum.GetName(typeof(SessionKey), chave);
            return HttpContext.Current.Session[chaveString] = valor;
        }
    }
}

/*using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;

namespace SistemaFac.Util
{
    public enum SessionKey { USUARIO}

    public static class SessionHelper
    {
        public static object Get(SessionKey chave)
        {
            String chaveString = Enum.GetName(typeof(SessionKey), chave);
            return HttpContext.Current.Session[chaveString];
        }

        public static object Set(SessionKey chave,object valor)
        {
            String chaveString = Enum.GetName(typeof(SessionKey), chave);
            return HttpContext.Current.Session[chaveString] = valor;
        }
    }
}
*/
