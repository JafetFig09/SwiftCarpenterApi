using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Infraestructure.Repositories;

namespace swiftcarpenterApi.Services.Features.Products
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();

        }

        public async Task<IEnumerable<ProductType>> GetAllProductType()
        {
            return await _productRepository.GetProductType();
        }
        public async Task<IEnumerable<Material>> GetMaterialAll()
        {
            var material = await _productRepository.GetMaterialAll();

            return material;
        }

        public async Task<IEnumerable<Size>> GetSizesAll()
        {
            return await _productRepository.GetSizesAll();
        }

        public async Task<IEnumerable<Size>> GetSizeAll()
        {
            return await _productRepository.GetSizesAll();
        }

        public async Task<IEnumerable<Color>> GetColorAll()
        {
            return await _productRepository.GetColorAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IEnumerable<FinishType>> GetFinishTypes()
        {
            return await _productRepository.GetFinishType();
        }
        public async Task<Product> GetId(int productTypeId, int sizeId, int materialId, int finishTypeId, int colorId)
        {
            return await _productRepository.GetId(productTypeId, sizeId, materialId, finishTypeId, colorId);
        }
        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task Update(Product productUpdate)
        {
            var product = await GetById(productUpdate.Id);

            if (product.Id > 0)
            {
                await _productRepository.Update(productUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);

            if (product.Id > 0)
            {
                await _productRepository.Delete(id);
            }
        }

    }
}
