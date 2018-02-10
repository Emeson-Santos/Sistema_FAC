using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaFac.Util;
using Model.Models.Exceptions;

namespace SistemaFac.Controllers
{
   // [Authenticated]
   // [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
    public class EmpresaController : Controller
    {

        private GerenciadorUsuario usuarioGerenciador;


        public EmpresaController()
        {
            usuarioGerenciador = new GerenciadorUsuario();
        }


        public ActionResult Index()
        {
            List<Usuario> usuarios = usuarioGerenciador.ObterTodos();
            if (usuarios == null || usuarios.Count == 0)
                usuarios = null;
            return View(usuarios);
        }


        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Usuario user = usuarioGerenciador.Obter(id);
                if (user != null)
                    return View(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection dadosForm)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Usuario u = new Usuario();
                    TryUpdateModel<Usuario>(u, dadosForm.ToValueProvider());
                    if (!usuarioGerenciador.BuscarMatricula(u.MatriculaUsuario))
                    {
                        usuarioGerenciador.Adicionar(u);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Matricula já existente.");
                    }

                }
                else
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Usuario user = usuarioGerenciador.Obter(id);
                if (user != null)
                    return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuario user)
        {
            try
            {
                usuarioGerenciador.Editar(user);
                return RedirectToAction("Index");

            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Usuario user = usuarioGerenciador.Obter(id);
                if (user != null)
                    return View(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Delete(int id, Usuario user)
        {
            try
            {
                usuarioGerenciador.Remover(usuarioGerenciador.Obter(id));
                return RedirectToAction("Index");
            }

            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
        }

        [HttpPost]
        public ActionResult Buscar(int? matricula)
        {
            List<Usuario> usuarios = usuarioGerenciador.Buscar(matricula);
            if (usuarios == null)
                usuarios = null;

            return View("Index", usuarios);
        }
    }
}

/*using Model.Models;
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
}*/
