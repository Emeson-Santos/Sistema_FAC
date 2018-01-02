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
                    if (gerenciador.BuscarPreCadastro(usuario.MatriculaUsuario, usuario.EmailUsuario))
                    {
                        Usuario auxiliar = usuario;
                        auxiliar.IdUsuario = gerenciador.ObterByMatricula(usuario.MatriculaUsuario).IdUsuario;
                        gerenciador.Editar(auxiliar);


                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário sem Pré-cadastro.");
                        return View();
                    }

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

/*using Model.Models;
using Model.Models.Account;
using Negocio.Business;
using SistemaFac.Util;
//using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
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

        [HttpPost]
        public ActionResult Index()
        {
            return View(gerenciador.ObterTodos());
        }

        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Usuario usuario = gerenciador.Obter(id);
                if (usuario != null)
                    return View(usuario);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id,NvAcesso")]Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    usuario.Senha = Criptografia.GerarHashSenha(usuario.Login + usuario.Senha);
                    usuario.NvAcesso = 0;
                    gerenciador.Adicionar(usuario);
                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                Usuario usuario = gerenciador.Obter(id);
                return View(usuario);
            }
            return RedirectToAction("Index");

        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario) //FormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    //Usuario usuario = new Usuario();
                    //TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                    gerenciador.Editar(usuario);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Usuario usuario = gerenciador.Obter(id);
                if (usuario != null)
                    return View(usuario);
            }
            return RedirectToAction("Index");
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuario usuario)
        {
            try
            {
                gerenciador.Remover(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Usuario");
            }

        }

        /*
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
                                FormsAuthentication.SetAuthCookie(usuario.Email, dadosLogin.LembrarMe);
                                SessionHelper.Set(SessionKey.USUARIO, usuario);


                                if (usuario.TipoUsuario == ((int) Model.Models.TipoUsuario.USUARIO))
                                {
                                    return RedirectToAction("Index", "Usuario");
                                }
                                else if (usuario.TipoUsuario == ((int) Model.Models.TipoUsuario.EMPRESA))
                                {
                                    return RedirectToAction("Index", "Empresa");
                                }
                                else if (usuario.TipoUsuario == ((int) Model.Models.TipoUsuario.ADMINISTRADOR))
                                {
                                    return RedirectToAction("Index", "Administrador");
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
                    // Se ocorrer algum erro, reexibe.
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
                                    dadosLogin["NovaSenha"] =
                                        Criptografia.GerarHashSenha(dadosLogin["email"] + dadosLogin["NovaSenha"]);

                                    if (gerenciador.BuscarUsuario(dadosLogin["email"], dadosLogin["mae"],
                                        int.Parse(dadosLogin["matricula"])))
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
                    

    

        /*verificar este metodo ela pode estar errada
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["SenhaUsuario"] =
                        Criptografia.GerarHashSenha(collection["Email"] + collection["Senha"]);
                    Usuario usuario = new Usuario();
                    TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                    if (gerenciador.BuscarPreCadastro(usuario.Id, usuario.Email))
                    {
                        Usuario auxiliar = usuario;
                        auxiliar.Id = gerenciador.ObterByLoginSenha(usuario.Id).Id;
                        gerenciador.Editar(auxiliar);


                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário sem Pré-cadastro.");
                        return View();
                    }

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}*/
