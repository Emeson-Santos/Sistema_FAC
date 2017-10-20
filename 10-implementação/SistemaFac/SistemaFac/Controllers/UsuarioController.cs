using Model.Models;
using Negocio.Business;
using SistemaFac.Util;
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

        public ActionResult Index()
        {
            return View(gerenciador.ObterTodos());
        }

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
        public ActionResult Create([Bind(Exclude ="Id,NvAcesso")]Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    usuario.Senha = Criptografia.GerarHashSenha(usuario.Login + usuario.Senha);
                    usuario.NvAcesso = 1;
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
    }
}