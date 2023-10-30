using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using SwiftCarpenter.Infraestructure.Data;

namespace swiftcarpenterApi.Infraestructure.Repositories
{
    public class DetailQuoteRepository
    {
        private readonly SwiftCarpenterDbContext _context;

        public DetailQuoteRepository( SwiftCarpenterDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<DetailQuote>> GetAll()
        {
            var detailQuotes = await _context.DetailQuotes
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductType)
                .ToListAsync();

            return detailQuotes;
        }

        public async Task<DetailQuote> GetById(int id)
        {
            var detailQuote = await _context.DetailQuotes.
                Include(x => x.Product)
                .ThenInclude(x => x.ProductType).
                FirstOrDefaultAsync(dq => dq.Id == id);

            return detailQuote ?? new DetailQuote();
        }

        public async Task Add(DetailQuote detailQuote)
        {
            

            await _context.DetailQuotes.AddAsync(detailQuote);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DetailQuote detailQuoteUpdate)
        {
            var detailQuote = await _context.Quotes.FirstOrDefaultAsync(detailQuote =>
            detailQuote.Id == detailQuoteUpdate.Id);

            if (detailQuote != null)
            {
                _context.Entry(detailQuote).CurrentValues.SetValues(detailQuoteUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var detailQuote = await _context.DetailQuotes.FirstOrDefaultAsync(detailQuote => 
            detailQuote.Id == id);

            if (detailQuote != null)
            {
                _context.DetailQuotes.Remove(detailQuote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
