
using System.Web.Mvc;
using Model.Models.Account;
using Model.Models;
using Negocio.Business;
using SistemaFac.Util;
using System.Web.Security;

namespace SistemaFac.Controllers
{
    public class LoginController : Controller
    {
        private GerenciadorUsuario gerenciador;

        public LoginController()
        {
            gerenciador = new GerenciadorUsuario();
        }

        
        [Authenticated]
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = TipoUsuario.USUARIO, MetodoAcao = "IndexADMINISTRADOR", Controladora = "Usuario")]
        public ActionResult IndexUsuario()
        {
            return View();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = TipoUsuario.ADMINISTRADOR, MetodoAcao = "IndexEMPRESA", Controladora = "Usuario")]
        public ActionResult IndexADMINISTRADOR()
        {
            return View();
        }
        [Authenticated]
        [CustomAuthorize(NivelAcesso = TipoUsuario.EMPRESA, MetodoAcao = "IndexADMINISTRADOR", Controladora = "Usuario")]
        public ActionResult IndexEMPRESA()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            ViewBag.TipoUsuario = new SelectList(gerenciador.ObterTodos(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                    Usuario usuario = new Usuario();
                    TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                    if (gerenciador.BuscarPreCadastro(usuario.Id, usuario.Email))
                    {
                        Usuario auxiliar = usuario;
                        auxiliar.Id = gerenciador.Obter(usuario.Id).Id;
                        gerenciador.Editar(auxiliar);
                    }
                    // gerenciador.Adicionar(usuario);
                    return RedirectToAction("Login");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            return View(gerenciador.ObterTodos());
        }
    }
}