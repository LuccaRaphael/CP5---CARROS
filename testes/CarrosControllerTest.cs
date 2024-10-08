using CrudMongoDB.Config;
using CrudMongoDB.Controllers;
using CrudMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CrudMongoDB.Tests
{
    public class CarrosControllerTest
    {
        private readonly Mock<IMongoCollection<Carro>> _mockCarroCollection;
        private readonly CarrosController _controller;

        public CarrosControllerTest()
        {
            // Configura o Mock para o MongoClient e MongoDatabase
            var mockOptions = new Mock<IOptions<ConfigDB>>();
            mockOptions.Setup(m => m.Value).Returns(new ConfigDB { ConnectionString = "mongodb://localhost", Database = "TestDB" });

            // Mock do IMongoCollection<Carro>
            _mockCarroCollection = new Mock<IMongoCollection<Carro>>();

            // Mock do CarroContexto
            var mockContexto = new Mock<CarroContexto>(mockOptions.Object);
            mockContexto.Setup(c => c.Carros).Returns(_mockCarroCollection.Object);

            // Criando o controlador com o contexto mockado
            _controller = new CarrosController(mockOptions.Object);
        }

        [Fact]
        public async Task NovoCarro_Valido_RedirecionaParaIndex()
        {
            // Arrange
            var carro = new Carro { Fabricante = "Teste", Nome = "Carro Teste", Tipo = "SUV" };
            _mockCarroCollection.Setup(c => c.InsertOneAsync(carro, null, default)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.NovoCarro(carro);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(CarrosController.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task NovoCarro_Invalido_RetornaView()
        {
            // Arrange
            var carro = new Carro { Fabricante = "Teste", Nome = "Carro Teste", Tipo = "SUV" };
            _controller.ModelState.AddModelError("Nome", "Nome é obrigatório"); // Simula um erro de validação

            // Act
            var result = await _controller.NovoCarro(carro);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(carro, viewResult.Model);
        }
    }
}
