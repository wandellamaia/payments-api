using Entities;
using Infra.DataBase.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PaymentService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// WebApplicationFactory - Ajuda a inicializar nossa aplicação na memória
// Nunit, Xunit ou Mstest - o projeto fornece o ambiente para realizar os testes
// InMemory - fornece o provedor para acessar o banco de dados em memória

namespace PaymentServiceAPI.Tests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class FixturesTest
    {
        private readonly IntegrationTestFixture<StartupApiTests> _integrationTestFixture;
        public FixturesTest(IntegrationTestFixture<StartupApiTests> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Theory(DisplayName = "Efetua Saque via api")]
        [InlineData(80)]
        [InlineData(300)]
        [InlineData(500)]
        public async Task Efetua_Saque_Via_Api()
        {
            var requisicao = await _integrationTestFixture.Client.GetAsync($"/api/Payment");
            var resposta = await requisicao.Content.ReadAsStringAsync();

            Assert.True(requisicao.IsSuccessStatusCode);
            Assert.Contains("Receba seu saque", resposta);
        }

        [Theory(DisplayName = "NÃO Efetua Saque via api")]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(38)]
        public async Task Nao_Efetua_Saque_Via_Api(int valorSaque)
        {
            var requisicao = await _integrationTestFixture.Client.PostAsJsonAsync($"/api/CaixaEletronico/saque/{valorSaque}", new { });
            var resposta = await requisicao.Content.ReadAsStringAsync();

            Assert.False(requisicao.IsSuccessStatusCode);
            Assert.Contains("Valor não válido para saque", resposta);
            Assert.Equal(HttpStatusCode.BadRequest, requisicao.StatusCode);
        }
    }
}
