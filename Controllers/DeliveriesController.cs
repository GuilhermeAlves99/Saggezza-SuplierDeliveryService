using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saggezza_SuplierDeliveryService.Application.UseCases;
using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;

namespace Saggezza_SuplierDeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeliveriesController : ControllerBase
    {
        private readonly CreateSupplier _createSupplier;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IProductRepository _productRepository;

        public DeliveriesController(CreateSupplier createSupplier, IDeliveryRepository deliveryRepository, IProductRepository productRepository)
        {
            _createSupplier = createSupplier;
            _deliveryRepository = deliveryRepository;
            _productRepository = productRepository;
        }

        [HttpPost("suppliers")]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierRequest request)
        {
            if (string.IsNullOrEmpty(request?.Name))
                return BadRequest("Nome do fornecedor é obrigatório");

            var supplier = await _createSupplier.Execute(request.Name);
            return Ok(supplier);
            try
            {
                return Ok("Sucesso");
            }
            catch (BadImageFormatException ex)
            {
                // Logue o InnerException para mais detalhes
                Console.WriteLine("Erro de formato de imagem: {Message}. Inner: {Inner}", ex.Message, ex.InnerException?.Message);
                return StatusCode(500, "Erro interno: Formato de DLL inválido");
            }
            catch (Exception ex)
            {
                Console.WriteLine( "Erro geral em AddSupplier");
                return StatusCode(500, ex.Message);
            }
        }

        public class SupplierRequest
        {
            public string Name { get; set; }
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await _productRepository.Add(product);
            return Ok(result);
        }

        [HttpPost("deliveries")]
        public async Task<IActionResult> AddDelivery([FromBody] Delivery delivery)
        {
            var result = await _deliveryRepository.Add(delivery);
            return Ok(result);
        }

        [HttpGet("deliveries")]
        public async Task<IActionResult> GetDeliveries()
        {
            try
            {
                var deliveries = _deliveryRepository.GetAll();
                return Ok(deliveries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }
    }
}
