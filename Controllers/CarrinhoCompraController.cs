//using Microsoft.AspNetCore.Mvc;
//using TrabalhoFinalAcademiaNet.Models;
//using TrabalhoFinalAcademiaNet.Repositories.Interfaces;
//using TrabalhoFinalAcademiaNet.ViewModels;

//namespace TrabalhoFinalAcademiaNet.Controllers
//{
//    public class CarrinhoCompraController : Controller
//    {
//        private readonly IProdutoRepository _produtoRepository;
//        private readonly CarrinhoCompra _carrinhoCompra;

//        public CarrinhoCompraController(CarrinhoCompra carrinhoCompra)
//        {
//            _carrinhoCompra = carrinhoCompra;
//        }

//        public CarrinhoCompraController(IProdutoRepository produtoRepository)
//        {
//            _produtoRepository = produtoRepository;
//        }

//        public IActionResult Index()
//        {
//            var itens = _carrinhoCompra.GetVendas();
//            _carrinhoCompra.Vendas= itens;

//            var carrinhoCompraVM = new CarrinhoCompraViewModel
//            {
//                CarrinhoCompra = _carrinhoCompra,
//                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
//            };

//            return View(carrinhoCompraVM);
//        }
//        public IActionResult AdicionarItemNoCarrinhoCompra(int produtoId)
//        {
//            var produtoSelecionado = _produtoRepository.Produtos
//                                    .FirstOrDefault(p => p.Id == produtoId);

//            if (produtoSelecionado != null)
//            {
//                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
//            }
//            return RedirectToAction("Index");
//        }

//        public IActionResult RemoverItemDoCarrinhoCompra(int produtoId)
//        {
//            var produtoSelecionado = _produtoRepository.Produtos
//                                    .FirstOrDefault(p => p.Id == produtoId);

//            if (produtoSelecionado != null)
//            {
//                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}
