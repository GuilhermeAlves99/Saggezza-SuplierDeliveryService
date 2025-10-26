using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;

namespace Saggezza_SuplierDeliveryService.Application.UseCases
{
    public class CreateProduct
    {
        private readonly IProductRepository _productRepository;

        public CreateProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Execute(Product product)
        {
            if (string.IsNullOrEmpty(product.Name)) throw new ArgumentException("Nome do Produto é obrigatório.");
            return await _productRepository.Add(product);
        }
    }
}
