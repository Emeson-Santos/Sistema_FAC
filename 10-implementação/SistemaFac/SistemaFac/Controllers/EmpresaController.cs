using Model.Models;
using Negocio.Business;
using SistemaFac.Util;
using System.Web.Mvc;
using System.Web.Security;
namespace SistemaFac.Controllers
{
    public class EmpresaController : Controller
    {
        private GerenciadorEmpresa gerenciador;

        public EmpresaController()
        {
            gerenciador = new GerenciadorEmpresa();
        }

        public ActionResult Index()
        {
            return View(gerenciador.ObterTodos());
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Empresa empresa = gerenciador.Obter(id);
                if (empresa != null)
                    return View(empresa);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id,NvAcesso")]Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    empresa.Senha = Criptografia.GerarHashSenha(empresa.Login + empresa.Senha);
                    empresa.NvAcesso = 1;
                    gerenciador.Adicionar(empresa);
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
                Empresa empresa = gerenciador.Obter(id);
                return View(empresa);
            }
            return RedirectToAction("Index");

        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Empresa empresa) //FormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    //Usuario usuario = new Usuario();
                    //TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                    gerenciador.Editar(empresa);
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
                Empresa empresa = gerenciador.Obter(id);
                if (empresa != null)
                    return View(empresa);
            }
            return RedirectToAction("Index");
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Empresa empresa)
        {
            try
            {
                gerenciador.Remover(empresa);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Empresa");
            }

        }
    }
}