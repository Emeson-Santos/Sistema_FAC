using System.Web.Mvc;
using Model.Models.Account;
using Model.Models;
using Negocio.Business;
using SistemaFac.Util;
using System.Web.Security;


namespace SistemaFac.Controllers
{
    public class UsuarioController : Controller
    {
        private GerenciadorUsuario gerenciador;

        public UsuarioController()
        {
            gerenciador = new GerenciadorUsuario();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel dadosLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Obtendo o usuário.
                    //dadosLogin.Senha = Criptografia.GerarHashSenha(dadosLogin.Login + dadosLogin.Senha);
                    Usuario usuario = gerenciador.ObterByLoginSenha(dadosLogin.Login, dadosLogin.Senha);

                    // Autenticando.
                    if (usuario != null)
                    {
                        FormsAuthentication.SetAuthCookie(usuario.EmailUsuario, dadosLogin.LembrarMe);
                        SessionHelper.Set(SessionKey.USUARIO, usuario);


                        if (usuario.TipoUsuario == ((int)Model.Models.TipoUsuario.USUARIO))
                        {
                            return RedirectToAction("Index", "Usuario");
                        }
                        else if (usuario.TipoUsuario == ((int)Model.Models.TipoUsuario.EMPRESA))
                        {
                            return RedirectToAction("Index", "Empresa");
                        }                        
                        else

                            return RedirectToAction("Index", "Administrador");

                    }
                }
                ModelState.AddModelError("", "Usuário e/ou senha inválidos.");
            }
            catch
            {
                ModelState.AddModelError("", "A autenticação falhou. Forneça informações válidas e tente novamente.");
            }
            // Se ocorrer algum erro, reexibe o formulário.
            return View();
        }

        //GET
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha(FormCollection dadosLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dadosLogin["NovaSenha"] = Criptografia.GerarHashSenha(dadosLogin["email"] + dadosLogin["NovaSenha"]);

                    if (gerenciador.BuscarUsuario(dadosLogin["email"], dadosLogin["mae"], int.Parse(dadosLogin["matricula"])))
                    {
                        Usuario auxiliar = gerenciador.ObterByMatricula(int.Parse(dadosLogin["matricula"]));
                        auxiliar.SenhaUsuario = dadosLogin["NovaSenha"];
                        gerenciador.Editar(auxiliar);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não Encontrado.");
                    }

                }
            }
            catch
            {
                ModelState.AddModelError("", "A autenticação falhou. Forneça informações válidas e tente novamente.");
            }
            // Se ocorrer algum erro, reexibe o formulário.
            ModelState.AddModelError("", "Preencha todos os dados de Forma Correta.");
            return View();
        }


       // [Authenticated]
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cadastrar()
        {
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
                    collection["SenhaUsuario"] = Criptografia.GerarHashSenha(collection["EmailUsuario"] + collection["SenhaUsuario"]);

                    Usuario usuario = new Usuario();
                    TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                   
                        Usuario auxiliar = usuario;
                        auxiliar.IdUsuario = gerenciador.ObterByMatricula(usuario.MatriculaUsuario).IdUsuario;
                        gerenciador.Editar(auxiliar);
                        return RedirectToAction("Login");    
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
