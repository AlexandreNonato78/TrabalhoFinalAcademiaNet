using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalAcademiaNet;
using TrabalhoFinalAcademiaNet.Models;

namespace TrabalhoFinalAcademiaNet.Controllers
{
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Vendas.Include(v => v.Cliente).Include(v => v.Produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCliente");
            //ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto");
            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "NomeCliente").ToList();
            ViewBag.Produtos = new SelectList(_context.Produtos, "Id", "NomeProduto").ToList();
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVenda,Quantidade,Endereco,ClienteId,ProdutoId")] Venda venda)
        {
            var produto = _context.Produtos.Find(venda.ProdutoId);

            if (produto != null)
            {
                venda.TotalVenda = venda.Quantidade * produto.Preco;
                produto.QuantidadeEstoque -= venda.Quantidade;
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCliente", venda.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", venda.ProdutoId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Cnpj", venda.ClienteId);
            //ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", venda.ProdutoId);
            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "NomeCliente").ToList();
            ViewBag.Produtos = new SelectList(_context.Produtos, "Id", "NomeProduto").ToList();
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataVenda,Quantidade,ClienteId,ProdutoId,Endereco")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }
            var produto = _context.Produtos.Find(venda.ProdutoId);

            if (produto != null)
            {
                venda.TotalVenda = venda.Quantidade * produto.Preco;
                _context.Update(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCliente", venda.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", venda.ProdutoId);
            return View(venda);

        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
