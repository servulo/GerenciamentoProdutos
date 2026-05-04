using GerenciamentoProdutos.Domain.Interfaces;
using GerenciamentoProdutos.Web.Mappers;
using GerenciamentoProdutos.Web.ViewModels;
using System.Web.Mvc;

namespace GerenciamentoProdutos.Web.Controllers
{
    public class ProdutosController : Controller
    {
        
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
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
                _repository.Adicionar(ProdutoMapper.ToEntity(viewModel));
                return RedirectToAction("Index");
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
                _repository.Atualizar(ProdutoMapper.ToEntity(viewModel));
                return RedirectToAction("Index");
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
            _repository.Remover(id);
            return RedirectToAction("Index");
        }
    }
}