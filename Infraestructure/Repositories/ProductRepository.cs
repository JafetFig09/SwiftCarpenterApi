using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using SwiftCarpenter.Infraestructure.Data;
using System.Runtime.InteropServices;

namespace swiftcarpenterApi.Infraestructure.Repositories
{
    public class ProductRepository
    {
        private readonly SwiftCarpenterDbContext _context;

        public ProductRepository(SwiftCarpenterDbContext context)
        {
               this._context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.Include(x => x.Material).
                Include(x=> x.ProductType).
                Include( x => x.Color).
                Include( x=> x.Size).
                Include(x => x.FinishType).
                ToListAsync();

            return products;
        }

        public async Task<Product> GetById( int id)
        {
            var product = await _context.Products.Include(x => x.Material).
                Include(x => x.ProductType).
                Include(x => x.Color).
                Include(x => x.Size).
                Include(x => x.FinishType).FirstOrDefaultAsync(p => p.Id == id);

            return product ?? new Product();
        }

        public async Task Add( Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update( Product productUpdate)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => 
            product.Id == productUpdate.Id);

            if(product != null) 
            { 
                _context.Entry(product).CurrentValues.SetValues(productUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            if( product != null ) 
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
