using GerenciamentoProdutos.Domain.Interfaces;
using GerenciamentoProdutos.Web.Mappers;
using GerenciamentoProdutos.Web.ViewModels;
using log4net;
using System;
using System.Web.Mvc;

namespace GerenciamentoProdutos.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repository;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ProdutosController));

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            _log.Info("Listando todos os produtos");
            var produtos = _repository.ObterTodos();
            return View(ProdutoMapper.ToViewModelList(produtos));
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
                    _repository.Adicionar(ProdutoMapper.ToEntity(viewModel));
                    _log.Info($"Produto criado: {viewModel.Nome}");
                    return RedirectToAction("Index");
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
            return View(ProdutoMapper.ToViewModel(_repository.ObterPorId(id)));
        }

        [HttpPost]
        public ActionResult Editar(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Atualizar(ProdutoMapper.ToEntity(viewModel));
                    _log.Info($"Produto atualizado: ID {viewModel.Id} - {viewModel.Nome}");
                    return RedirectToAction("Index");
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
            return View(ProdutoMapper.ToViewModel(_repository.ObterPorId(id)));
        }

        public ActionResult Excluir(int id)
        {
            return View(ProdutoMapper.ToViewModel(_repository.ObterPorId(id)));
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExclusao(int id)
        {
            try
            {
                _repository.Remover(id);
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