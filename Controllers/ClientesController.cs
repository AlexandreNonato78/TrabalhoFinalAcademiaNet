using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using TrabalhoFinalAcademiaNet.Models;
using TrabalhoFinalAcademiaNet.Services;

namespace TrabalhoFinalAcademiaNet.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _context;
        private readonly CepService _cepService;
        private readonly GetCoordService _getCoordService;

        public ClientesController(Contexto context, CepService cepService, GetCoordService getCoordService )
        {
            _context = context;
            _cepService = cepService;
            _getCoordService = getCoordService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            //if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(cliente.Endereco.ToString()))
                {
                    // Chama o serviço de busca de CEP para preencher o endereço
                    var endereco = await _cepService.BuscarEnderecoPorCep(cliente.Endereco.Cep.ToString());

                    if (endereco != null)
                    {
                        cliente.Endereco = new Models.Endereco
                        {
                            Cep = endereco.Cep,
                            Logradouro = endereco.Logradouro,
                            Bairro = endereco.Bairro,
                            Localidade = endereco.Localidade,
                            Uf = endereco.Uf,
                            Complemento = cliente.Endereco.Complemento,
                            Numero = cliente.Endereco.Numero
                        };


                    }
                    else

                    if (string.IsNullOrEmpty(cliente.NomeCliente) || string.IsNullOrEmpty(cliente.Cnpj) || string.IsNullOrEmpty(cliente.Endereco.ToString()) || string.IsNullOrEmpty(cliente.Email) || string.IsNullOrEmpty(cliente.Telefone))
                    {
                        ModelState.AddModelError(string.Empty, "Por favor, preencha todos os campos!");
                        return View(cliente);
                    }

                    _context.Add(cliente);


                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(cliente.Endereco.ToString()))
            {
                // Chama o serviço de busca de CEP para preencher o endereço
                var endereco = await _cepService.BuscarEnderecoPorCep(cliente.Endereco.Cep.ToString());

                if (endereco != null)
                {
                    cliente.Endereco = new Models.Endereco
                    {
                        Cep = endereco.Cep,
                        Logradouro = endereco.Logradouro,
                        Bairro = endereco.Bairro,
                        Localidade = endereco.Localidade,
                        Uf = endereco.Uf,
                        Complemento = cliente.Endereco.Complemento,
                        Numero = cliente.Endereco.Numero
                    };


                }
            }
            var todasVendasAtt = _context.Vendas.Include(x => x.Entrega).Where(x => x.ClienteId == cliente.Id).ToList();
            foreach (var item in todasVendasAtt)
            {
                //item.Endereco = ;




            }

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCliente,Cnpj,Endereco,Email,Telefone")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            var clienteExistente = await _context.Clientes.Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == cliente.Id);

            if (clienteExistente != null)
            {
                if (!string.IsNullOrEmpty(cliente.Endereco.ToString()))
                {
                    var endereco = await _cepService.BuscarEnderecoPorCep(cliente.Endereco.Cep.ToString());

                    if (endereco != null)
                    {
                        clienteExistente.Endereco.Cep = endereco.Cep;
                        clienteExistente.Endereco.Logradouro = endereco.Logradouro;
                        clienteExistente.Endereco.Bairro = endereco.Bairro;
                        clienteExistente.Endereco.Localidade = endereco.Localidade;
                        clienteExistente.Endereco.Uf = endereco.Uf;
                        clienteExistente.Endereco.Complemento = cliente.Endereco.Complemento;
                        clienteExistente.Endereco.Numero = cliente.Endereco.Numero;

                        _context.Entry(clienteExistente.Endereco).State = EntityState.Modified;
                    }
                }

                clienteExistente.NomeCliente = cliente.NomeCliente;
                clienteExistente.Cnpj = cliente.Cnpj;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Telefone = cliente.Telefone;

                _context.Entry(clienteExistente).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                var todasVendasUpd = _context.Vendas.Include(v=>v.Entrega).Where(x => x.ClienteId == cliente.Id).ToList();
                foreach (var item in todasVendasUpd)
                {
                    var enderecoConcatenado = $"{cliente.Endereco.Logradouro}, {cliente.Endereco.Bairro}, {cliente.Endereco.Localidade}, {cliente.Endereco.Uf}, {cliente.Endereco.Numero}, {cliente.Endereco.Complemento}";

                    item.Endereco = enderecoConcatenado;
                  
                    _context.Vendas.Update(item);
                    await _context.SaveChangesAsync();

                }
                var todasEntregasUpd = _context.Entregas.Include(v => v.Venda).Where(x => x.Venda.ClienteId == cliente.Id).ToList();

                foreach (var item in todasEntregasUpd)
                {
                    double latSave = 0.0;
                    double longSave = 0.0;
                    var longLat = _getCoordService.GetFromCEP(cliente.Endereco.Cep);
                    if (longLat != null)
                    {
                        latSave = longLat.Result.Latitude;
                        longSave = longLat.Result.Longitude;
                    }

                    if (double.TryParse(longLat.Result.Latitude.ToString(), out double parsedLatitude))
                    {
                        latSave = parsedLatitude;
                        item.Latitude = parsedLatitude;
                    }

                    if (double.TryParse(longLat.Result.Longitude.ToString(), out double parsedLongitude))
                    {
                        longSave = parsedLongitude;
                        item.Longitude = parsedLongitude;
                    }
                    _context.Entregas.Update(item);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));

            }
            else
            {
                return NotFound();
            }
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult BuscarEnderecoPorCep(string cep)
        {
            var endereco = _cepService.BuscarEnderecoPorCep(cep).Result;

            return Json(endereco);
        }

    }
}


