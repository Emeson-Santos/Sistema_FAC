using System.Web;
using System.Web.Mvc;
using Model.Models;
using System.Web.Routing;

namespace SistemaFac.Util
{
    public enum TipoUsuario { USUARIO, EMPRESA, ADMINISTRADOR }

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        #region PropriedadesConstrutor

        /// <summary> Propriedade AllowAccess que permite o acesso a um método de ação. /// </summary>
        public bool AllowAccess { get; set; }

        /// <summary> Propriedade NivelAcesso que determina o nível de acesso de um método de ação. /// </summary>
        public TipoUsuario NivelAcesso;


        /// <summary> Propriedade referente ao método de ação que o usuário será redirecionado caso não tenha permissão. /// </summary>
        public string MetodoAcao;

        /// <summary> Propriedade referente à controladora que o usuário será redirecionado caso não tenha permissão. /// </summary>
        public string Controladora;

        /// <summary> Método Construtor. /// </summary>
        public CustomAuthorizeAttribute()
        {
            AllowAccess = false;
            MetodoAcao = "Index";
            Controladora = "Home";
        }

        #endregion

        /// <summary>
        /// Método AuthorizeCore - Valida se um usuário está autorizado para acessar um recurso.
        /// </summary>
        /// <param name="httpContext"> Objeto do tipo HttpContextBase contendo atributos de uma
        ///     requisição e/ou sessão do usuário. </param>
        /// <returns> Booleano que indica se o usuário está autorizado. </returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                Usuario usuario = SessionHelper.Get(SessionKey.USUARIO) as Usuario;

                if (httpContext.Request.IsAuthenticated && (usuario.TipoUsuario == ((int)NivelAcesso) || AllowAccess))
                    return true;
                else
                    return false;
            }
            catch
            {
                //TODO Implementar
            }
            return false;
        }

        /// <summary>
        /// Método HandleUnauthorizedRequest - Permite redirecionar o usuário para a página inicial
        ///     quando o mesmo não tem permissão para acessar um recurso.
        /// </summary>
        /// <param name="filterContext"> Objeto do tipo AuthorizationContext, o qual é necesssário
        ///     para o redirecionamento do usuário. </param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Usuario usuario = SessionHelper.Get(SessionKey.USUARIO) as Usuario;
            RouteValueDictionary rota = new RouteValueDictionary();

            if (usuario == null)
            {
                rota["controller"] = Controladora;
                rota["action"] = MetodoAcao;
            }
            else
            {
                int tipo = usuario.TipoUsuario;
                switch (tipo)
                {
                    case 1:
                        rota["controller"] = "Usuario";
                        rota["action"] = "Index";
                        break;
                    case 2:
                        rota["controller"] = "Empresa";
                        rota["action"] = "Index";
                        break;
                    default:
                        rota["controller"] = "Administrador";
                        rota["action"] = "Index";
                        break;
                }
            }
            filterContext.Result = new RedirectToRouteResult(rota);
        }
    }
}

/*using System;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using System.Web.Routing;

namespace SistemaFac.Util
{
    public enum TipoUsuario { USUARIO,EMPRESA,ADMINISTRADOR}

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        #region PropriedadesConstrutor

        /// <summary> Propriedade AllowAccess que permite o acesso a um método de ação. /// </summary>
        public bool AllowAccess { get; set; }

        /// <summary> Propriedade NivelAcesso que determina o nível de acesso de um método de ação. /// </summary>
        public TipoUsuario NivelAcesso;

        /// <summary> Propriedade referente ao método de ação que o usuário será redirecionado caso não tenha permissão. /// </summary>
        public string MetodoAcao;

        /// <summary> Propriedade referente à controladora que o usuário será redirecionado caso não tenha permissão. /// </summary>
        public string Controladora;

        /// <summary> Método Construtor. /// </summary>
        public CustomAuthorizeAttribute()
        {
            AllowAccess = false;
            MetodoAcao = "Index";
            Controladora = "Home";
        }

        #endregion

        /// <summary>
        /// Método AuthorizeCore - Valida se um usuário está autorizado para acessar um recurso.
        /// </summary>
        /// <param name="httpContext"> Objeto do tipo HttpContextBase contendo atributos de uma
        ///     requisição e/ou sessão do usuário. </param>
        /// <returns> Booleano que indica se o usuário está autorizado. </returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                Usuario usuario = SessionHelper.Get(SessionKey.USUARIO) as Usuario;

                if (httpContext.Request.IsAuthenticated && (usuario.TipoUsuario == ((int) NivelAcesso) || AllowAccess))
                    return true;
                else
                    return false;

                //  if (usuario == null)
                //     return false;

            }
            catch (Exception e)
            {
                //todo: implementar
            }
            return false;
        }
    

    /// <summary>
        /// Método HandleUnauthorizedRequest - Permite redirecionar o usuário para a página inicial
        ///     quando o mesmo não tem permissão para acessar um recurso.
        /// </summary>
        /// <param name="filterContext"> Objeto do tipo AuthorizationContext, o qual é necesssário
        ///     para o redirecionamento do usuário. </param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Usuario usuario = SessionHelper.Get(SessionKey.USUARIO) as Usuario;

            RouteValueDictionary rota = new RouteValueDictionary();

            if (usuario == null)
            { 
            // HttpContext.Current.Session.Abandon();
            rota["controller"] = Controladora;
            rota["action"] = MetodoAcao;
            //filterContext.Result = new RedirectToRouteResult(rota);
        }
        else

        {
                int tipo = usuario.TipoUsuario;
                switch (tipo)
                {
                    case 1:
                        rota["controller"] = "Usuario";
                        rota["action"] = "Index";
                        break;
                    case 2:
                        rota["controller"] = "Empresa";
                        rota["action"] = "Index";
                        break;
                    case 3:
                        rota["controller"] = "Administrador";
                        rota["action"] = "Index";
                        break;
                    default://verificar este defaut
                        rota["controller"] = "Administrador";
                        rota["action"] = "Index";
                        break;
                }
            }
            filterContext.Result = new RedirectToRouteResult(rota);
        }
    }
    
}*/
