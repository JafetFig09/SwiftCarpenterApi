using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using SwiftCarpenter.Infraestructure.Data;

namespace swiftcarpenterApi.Infraestructure.Repositories
{
    public class CustomerRepository
    {
        private readonly SwiftCarpenterDbContext _context;

        public CustomerRepository( SwiftCarpenterDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.
                Include( x=> x.Quotes).
                ThenInclude(x => x.DetailQuotes)
                 .ThenInclude(dq => dq.Product.ProductType)
                .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers.Include( x=> x.Quotes).
                ThenInclude(x=> x.DetailQuotes)
                 .ThenInclude(dq => dq.Product.ProductType).
                FirstOrDefaultAsync(c => c.Id == id);

            return customer ?? new Customer();
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Customer customerUpdate)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cUpdated =>
            cUpdated.Id == customerUpdate.Id);

            if (customer != null)
            {
                _context.Entry(customer).CurrentValues.SetValues(customerUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c =>
            c.Id == id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
