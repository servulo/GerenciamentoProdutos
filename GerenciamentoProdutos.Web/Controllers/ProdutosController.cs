using AutoMapper;
using GerenciamentoProdutos.Domain.Entities;
using GerenciamentoProdutos.Domain.Services;
using GerenciamentoProdutos.Web.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GerenciamentoProdutos.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _service;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ProdutosController));

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            _log.Info("Listando todos os produtos");
            var produtos = _service.ObterTodos();
            return View(Mapper.Map<IEnumerable<ProdutoViewModel>>(produtos));
        }

        public ActionResult Criar()
        {
            return View(new ProdutoViewModel());
        }

        [HttpPost]
        public ActionResult Criar(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Criar(Mapper.Map<Produto>(viewModel));
                    _log.Info($"Produto criado: {viewModel.Nome}");
                    return RedirectToAction("Index");
                }
                catch (ArgumentException ex)
                {
                    _log.Warn($"Validação ao criar produto: {ex.Message}");
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    _log.Error($"Erro ao criar produto: {viewModel.Nome}", ex);
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar o produto.");
                }
            }
            return View(viewModel);
        }

        public ActionResult Editar(int id)
        {
            return View(Mapper.Map<ProdutoViewModel>(_service.ObterPorId(id)));
        }

        [HttpPost]
        public ActionResult Editar(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Atualizar(Mapper.Map<Produto>(viewModel));
                    _log.Info($"Produto atualizado: ID {viewModel.Id} - {viewModel.Nome}");
                    return RedirectToAction("Index");
                }
                catch (ArgumentException ex)
                {
                    _log.Warn($"Validação ao atualizar produto: {ex.Message}");
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    _log.Error($"Erro ao atualizar produto: ID {viewModel.Id}", ex);
                    ModelState.AddModelError("", "Ocorreu um erro ao atualizar o produto.");
                }
            }
            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            return View(Mapper.Map<ProdutoViewModel>(_service.ObterPorId(id)));
        }

        public ActionResult Excluir(int id)
        {
            return View(Mapper.Map<ProdutoViewModel>(_service.ObterPorId(id)));
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExclusao(int id)
        {
            try
            {
                _service.Remover(id);
                _log.Info($"Produto excluído: ID {id}");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _log.Error($"Erro ao excluir produto: ID {id}", ex);
                return RedirectToAction("Index");
            }
        }
    }
}