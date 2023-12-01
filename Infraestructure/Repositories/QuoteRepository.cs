using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using SwiftCarpenter.Infraestructure.Data;

namespace swiftcarpenterApi.Infraestructure.Repositories
{
    public class QuoteRepository
    {
        private readonly SwiftCarpenterDbContext _context;

        public QuoteRepository(SwiftCarpenterDbContext context) 
        { 
            this._context = context;
        }

        public async Task<IEnumerable<Quote>> GetAll()
        {
            var quotes = await _context.Quotes
                .Include(x => x.Customer)
                .Include(x => x.DetailQuotes)
                .ThenInclude(dq => dq.Product.ProductType) 
                .ToListAsync();

            return quotes;
        }


        public async Task<Quote> GetById(int id)
        {
            var quote = await _context.Quotes
                 .Include(x => x.Customer)
                 .Include(x => x.DetailQuotes)
                 .ThenInclude(dq => dq.Product.ProductType).
                  FirstOrDefaultAsync(q => q.Id == id);

           
            return quote ?? new Quote();
        }

        public async Task<IEnumerable<Quote>> GetStatusAll(int id)
        {
            var quote = await _context.Quotes.Where(q => q.CustomerId == id && q.StatusQuote == false).
                Include(q => q.Customer).Include(q => q.DetailQuotes).ThenInclude( dq => dq.Product.ProductType).ToListAsync();

            return quote;
        }

        public async Task<IEnumerable<Quote>> GetStatus(int id)
        {
            var quote = await _context.Quotes.Where(q => q.CustomerId == id && q.StatusQuote == true).
                Include(q => q.Customer).Include(q => q.DetailQuotes).ThenInclude(dq => dq.Product.ProductType).ToListAsync();

            return quote;
        }





        public async Task Add(Quote quote)
        {
            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Quote quoteUpdate)
        {
            var quote = await _context.Quotes.FirstOrDefaultAsync(quote =>
            quote.Id == quoteUpdate.Id);

            if (quote != null)
            {
                _context.Entry(quote).CurrentValues.SetValues(quoteUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var quote = await _context.Quotes.FirstOrDefaultAsync(quote => quote.Id == id);

            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
