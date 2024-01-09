using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalAcademiaNet;
using TrabalhoFinalAcademiaNet.Models;
using TrabalhoFinalAcademiaNet.Services;
using TrabalhoFinalAcademiaNet.ViewModel;

namespace TrabalhoFinalAcademiaNet.Controllers
{
    public class EntregasController : Controller
    {
        private readonly Contexto _context;
        private readonly GetCoordService _getCoordService;


        public EntregasController(Contexto context, GetCoordService getCoordService)
        {
            _context = context;
            _getCoordService = getCoordService;
        }

        public async Task<IActionResult> Index()
        {

            var vendasEnviar = _context.Vendas.Include(x => x.Entrega).Include(p => p.Produto).Include(u => u.Cliente).ThenInclude(e => e.Endereco);
      
            var vT = vendasEnviar.Where(x => x.Enviar == true).ToList();
            List<VendaDetalhesViewModel> listEntrega = new List<VendaDetalhesViewModel>();
            double latSave = 0.0;
            double longSave = 0.0;
            foreach (var v in vT)
            {
                if (v!= null)
                {
                    Venda venda = _context.Vendas.FirstOrDefault(v => v.Id == v.Id);
                    Produto produto = _context.Produtos.FirstOrDefault(i => i.Id == venda.ProdutoId);
                    Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Id == venda.ClienteId);
                    Entrega entrega = _context.Entregas.FirstOrDefault(e => e.IdVenda == v.Id);

                    var longLat = _getCoordService.GetFromCEP(v.Cliente.Endereco.Cep);
                    if (longLat != null)
                    {
                        latSave = longLat.Result.Latitude;
                        longSave = longLat.Result.Longitude;
                    }

                    if (!_context.Entregas.Any(x=>x.IdVenda == v.Id))
                    {
                        var entregaSave = new Entrega();

                        entregaSave.IdVenda = v.Id;
                        entregaSave.Status = "Em Transporte";
                        if (longLat != null)
                        {
                            if (double.TryParse(longLat.Result.Latitude.ToString(), out double parsedLatitude))
                            {
                                latSave = parsedLatitude;
                                entregaSave.Latitude = parsedLatitude;
                            }

                            if (double.TryParse(longLat.Result.Longitude.ToString(), out double parsedLongitude))
                            {
                                longSave = parsedLongitude;
                                entregaSave.Longitude = parsedLongitude;
                            }
                        }
                        
                        _context.Entregas.Add(entregaSave);
                        await _context.SaveChangesAsync();
                    }

                    

                    var vendaEntregaVM = new VendaDetalhesViewModel
                    {
                        VendaId = v.Id,
                        DataVenda = v.DataVenda,
                        TotalVenda = v.TotalVenda,
                        ClienteNome = v.Cliente.NomeCliente,
                        ClienteEmail = v.Cliente.Email,
                        PrecoItem = v.Produto.Preco,
                        EntregaId = _context.Entregas.FirstOrDefault(x=>x.IdVenda == venda.Id).Id,
                        StatusEntrega = entrega == null ? "A Enviar": entrega.Status,
                        LatitudeEntrega = latSave,
                        LongitudeEntrega = longSave,
                        NomeItem = v.Produto.NomeProduto,
                        Endereco = v.Endereco
                    };
                    listEntrega.Add(vendaEntregaVM);
                }
            }
            return View(listEntrega.ToList());
        }



        //// GET: Entregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
    
            Entrega entrega = _context.Entregas.FirstOrDefault(e => e.IdVenda == id);
            Venda venda = _context.Vendas.FirstOrDefault(v => v.Id == entrega.IdVenda);
            Produto produto = _context.Produtos.FirstOrDefault(i => i.Id == venda.ProdutoId);
            Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Id == venda.ClienteId);
            var vendaEntregaVM = new VendaDetalhesViewModel
            {
                VendaId = venda.Id,
                DataVenda = venda.DataVenda,
                TotalVenda = venda.TotalVenda,
                ClienteNome = cliente.NomeCliente,
                ClienteEmail = cliente.Email,
                PrecoItem = produto.Preco,
                EntregaId = _context.Entregas.FirstOrDefault(x => x.IdVenda == venda.Id).IdVenda,
                StatusEntrega = entrega.Status,
                LatitudeEntrega = entrega.Latitude,
                LongitudeEntrega = entrega.Longitude,
                NomeItem = produto.NomeProduto,
                Endereco = venda.Endereco
            };

           
            if (entrega == null)
            {
                return NotFound();
            }

            return View(vendaEntregaVM);
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var entrega = await _context.Entregas.FindAsync(id);
        //    if (entrega == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(entrega);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Status,Latitude,Longitude")] Entrega entrega)
        //{
        //    if (id != entrega.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(entrega);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EntregasExists(entrega.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(entrega);
        //}

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas.FirstOrDefaultAsync(m => m.Id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrega = await _context.Entregas.FindAsync(id);
            if (entrega != null)
            {
                _context.Entregas.Remove(entrega);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        //// GET: Entregas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Entregas/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Status,Latitude,Longitude")] Entrega entrega)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(entrega);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(entrega);
        //}

        //// GET: Entregas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var entrega = await _context.Entregas.FindAsync(id);
        //    if (entrega == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(entrega);
        //}

        //// POST: Entregas/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Latitude,Longitude")] Entrega entrega)
        //{
        //    if (id != entrega.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(entrega);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EntregaExists(entrega.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(entrega);
        //}

        //// GET: Entregas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var entrega = await _context.Entregas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (entrega == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(entrega);
        //}

        //// POST: Entregas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var entrega = await _context.Entregas.FindAsync(id);
        //    if (entrega != null)
        //    {
        //        _context.Entregas.Remove(entrega);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool EntregasExists(int id)
        {
            return _context.Entregas.Any(e => e.Id == id);
        }
    }
}
