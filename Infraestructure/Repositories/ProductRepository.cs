﻿using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using SwiftCarpenter.Infraestructure.Data;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        public async Task<IEnumerable<ProductType>> GetProductType()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
          

            return productTypes;

           
        }
        public async Task<IEnumerable<FinishType>> GetFinishType()
        {
            var finishType = await _context.FinishTypes.ToListAsync(); 
            
            return finishType;
        }
        public async Task<IEnumerable<Material>> GetMaterialAll()
        {
            var material = await _context.Materials.ToListAsync();

            return material;
        }

        public async Task<IEnumerable<Size>> GetSizesAll()
        {
            var sizes = await _context.Sizes
                .Include(s => s.Products)
                .ThenInclude(p => p.ProductType).ToListAsync();


            return sizes;
        }

        public async Task<IEnumerable<Color>> GetColorAll()
        {
            var colors = await _context.Colors.ToListAsync(); 
            return colors;
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

        public async Task<Product> GetId(int productTypeId, int sizeId, int materialId, int finishTypeId, int colorId)
        {
            var product = await _context.Products.Include(p => p.Material).Include(p => p.ProductType).Include(p => p.Color).
                            Include(p => p.Size).Include( p => p.FinishType)
                            .FirstOrDefaultAsync(p => p.ProductTypeId == productTypeId &&
                             p.SizeId == sizeId &&
                             p.MaterialId == materialId &&
                             p.FinishTypeId == finishTypeId &&
                             p.ColorId == colorId);

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
