//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.DependencyInjection;
//using TrabalhoFinalAcademiaNet.Models;

//namespace TrabalhoFinalAcademiaNet.Models
//{
//    public class CarrinhoCompra
//    {
//        private readonly Contexto _context;

//        public CarrinhoCompra(Contexto context)
//        {
//            _context = context;
//        }

//        public string CarrinhoCompraId { get; set; }    
//        public List<Venda> Vendas { get; set; } = new List<Venda>();

//        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
//        {
//            ISession session = 
//                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

//            var context = services.GetService<Contexto>();

//            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

//            session.SetString("CarrinhoId", carrinhoId);

//            return new CarrinhoCompra(context)
//            {
//                CarrinhoCompraId = carrinhoId
//            };

//        }

//        public void AdicionarAoCarrinho(Produto produto)
//        {
//            var vendaExistente = Vendas.SingleOrDefault(
//                    s=> s.Produto.Id == produto.Id &&
//                     s.CarrinhoCompraId == CarrinhoCompraId);

//            if (vendaExistente == null)
//            {
//                Vendas.Add(new Venda
//                {
//                    CarrinhoCompraId = CarrinhoCompraId,
//                    Produto = produto,
//                    Quantidade = 1
//                });
                
//                _context.Vendas.Add(vendaExistente);
//            }
//            else
//            {
//                vendaExistente.Quantidade++;
//            }

//            _context.SaveChanges();
//        }

//        public int RemoverDoCarrinho(Produto produto)
//        {
//            var vendaExistente = _context.Vendas.SingleOrDefault(
//                    s => s.Produto.Id == produto.Id &&
//                     s.CarrinhoCompraId == CarrinhoCompraId);


//            var quantidadeLocal = 0;
//            if(vendaExistente != null)
//            {
//                if(vendaExistente.Quantidade > 1)
//                {
//                    vendaExistente.Quantidade--;
//                    quantidadeLocal= vendaExistente.Quantidade;                    
//                }
//                else
//                {
//                    Vendas.Remove(vendaExistente);
//                }                
//            }
//            _context.SaveChanges();
//            return quantidadeLocal;
//        }

//        public List<Venda> GetVendas()
//        {
//            return Vendas??(Vendas =
//                           _context.Vendas
//                           .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
//                           .Include(p => p.Produto)
//                           .ToList());
//        }

//        public void LimparCarrinho()
//        {
//            Vendas.Clear();
//            _context.SaveChanges();
//        }

//        public double GetCarrinhoCompraTotal()
//        {
//            var total =  Vendas
//                        .Where(c=>c.CarrinhoCompraId == CarrinhoCompraId)
//                        .Select(c=>c.Produto.Preco * c.Quantidade).Sum();

//            return total;
//        }
//    }
    
//}
