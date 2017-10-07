using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Prova.Application.Services;
using Prova.Application.ViewModels;

namespace Prova.UI.Controllers
{
    [RoutePrefix("administrativo-contas")]
    [Route("{action=listar}")]
    public class ContasController : Controller
    {
        private readonly IContaAppService _contaAppService;

        public ContasController(IContaAppService contaAppService)
        {
            _contaAppService = contaAppService;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_contaAppService.ObterTodos());
        }

        [Route("detalhes/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id.Value);
            if (contaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contaViewModel);
        }

        [Route("detalhes/{id:int}")]
        public ActionResult PerfilDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PerfilViewModel perfilViewModel = _contaAppService.ObterPerfilPorId(id.Value);

            return View(perfilViewModel);
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContaPerfilViewModel contaPerfilViewModel)
        {
            if (ModelState.IsValid)
            {
                _contaAppService.Adicionar(contaPerfilViewModel);

                return RedirectToAction("Index");
            }

            return View(contaPerfilViewModel);
        }

        [Route("editar/{id:guid}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id.Value);
            if (contaViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.ContaId = id;
            return View(contaViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContaViewModel contaViewModel)
        {
            if (ModelState.IsValid)
            {
                _contaAppService.Atualizar(contaViewModel);
                return RedirectToAction("Index");
            }
            return View(contaViewModel);
        }
        
        [Route("excluir/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id.Value);
            if (contaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contaViewModel);
        }
       
        [Route("excluir/{id:int}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _contaAppService.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListarPerfis(int id)
        {
            ViewBag.ContaId = id;
            return PartialView("_PerfisList", _contaAppService.ObterPorId(id).Perfis);
        }

        [Route("adicionar-perfil")]
        public ActionResult AdicionarPerfil(int id)
        {
            ViewBag.ContaId = id;
            return PartialView("_AdicionarPerfil");
        }

        [Route("adicionar-perfil")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarPerfil(PerfilViewModel perfilViewModel)
        {
            if (ModelState.IsValid)
            {
                _contaAppService.AdicionarPerfil(perfilViewModel);

                string url = Url.Action("ListarPerfis", "Contas", new { id = perfilViewModel.ContaId });
                return PartialView(url, perfilViewModel);
            }

            return PartialView("_AdicionarPerfil", perfilViewModel);
        }

        [Route("adicionar-perfil/{id:int}")]
        public ActionResult AtualizarPerfil(int id)
        {
            return PartialView("_AtualizarPerfil", _contaAppService.ObterPerfilPorId(id));
        }

        [Route("adicionar-perfil/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarPerfil(PerfilViewModel perfilViewModel)
        {
            if (ModelState.IsValid)
            {
                _contaAppService.AtualizarPerfil(perfilViewModel);

                string url = Url.Action("ListarPerfis", "Contas", new { id = perfilViewModel.ContaId });
                return PartialView(url, perfilViewModel);
            }

            return PartialView("_AtualizarPerfil", perfilViewModel);
        }

        [Route("excluir-endereco/{id:int}")]
        public ActionResult DeletarPerfil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var perfilViewModel = _contaAppService.ObterPerfilPorId(id.Value);
            if (perfilViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarPerfil", perfilViewModel);
        }

        // POST: Clientes/Delete/5

        [Route("excluir-endereco/{id:int}")]
        [HttpPost, ActionName("DeletarPerfil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarPerfilConfirmed(int id)
        {
            var contaId = _contaAppService.ObterPerfilPorId(id).ContaId;
            _contaAppService.RemoverPerfil(id);

            var perfilViewModel = _contaAppService.ObterTodos();

            string url = Url.Action("ListarPerfis", "Contas", new { id = contaId });
            return PartialView(url, perfilViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contaAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}