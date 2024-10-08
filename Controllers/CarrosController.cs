using CrudMongoDB.Config;
using CrudMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Controllers {
    public class CarrosController : Controller {
        private readonly CarroContexto _carroContexto;

        public CarrosController(IOptions<ConfigDB> opcoes) {
            _carroContexto = new CarroContexto(opcoes);
        }

        public async Task<IActionResult> Index() {
            var carros = await _carroContexto.Carros.Find(c => true).ToListAsync();
            return View(carros);
        }

        [HttpGet]
        public IActionResult NovoCarro() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoCarro(Carro carro) {
            if (!ModelState.IsValid) {
                return View(carro); 
            }

            carro.CarroId = Guid.NewGuid();
            await _carroContexto.Carros.InsertOneAsync(carro);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarCarro(Guid carroId) {
            Carro carro = await _carroContexto.Carros.Find(c => c.CarroId == carroId).FirstOrDefaultAsync();
            if (carro == null) {
                return NotFound(); 
            }
            return View(carro);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCarro(Carro carro) {
            if (!ModelState.IsValid) {
                return View(carro); 
            }

            await _carroContexto.Carros.ReplaceOneAsync(c => c.CarroId == carro.CarroId, carro);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirCarro(Guid carroId) {
            await _carroContexto.Carros.DeleteOneAsync(c => c.CarroId == carroId);
            return RedirectToAction(nameof(Index));
        }
    }
}
