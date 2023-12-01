using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Infraestructure.Data.Configurations;
using swiftcarpenterApi.Infraestructure.Repositories;
using System.Runtime.InteropServices;

namespace swiftcarpenterApi.Services.Features.Quotes
{
    public class QuoteService
    {
        private readonly QuoteRepository _quoteRepository;

        public QuoteService(QuoteRepository quoteRepository)
        {
            this._quoteRepository = quoteRepository;
            
        }

        public async Task<IEnumerable<Quote>> GetAll()
        {
            return await _quoteRepository.GetAll();
        }

        //Optiene las cotizaciones en estado pendiente
        public async Task<IEnumerable<Quote>> GetStatusAll(int id)
        {
            var quotes = await _quoteRepository.GetStatusAll(id);

            return quotes;
            
        }

        public async Task<IEnumerable<Quote>> GetStatus(int id)
        {
            var quotes = await _quoteRepository.GetStatus(id);

            return quotes;
        }


        public async Task<Quote> GetById( int id)
        {
            return  await _quoteRepository.GetById(id);    
        }

        public async Task Add( Quote quote)
        {
            await _quoteRepository.Add(quote);
        }

        public async Task Update( Quote quoteUpdate)
        {
            var product =  await _quoteRepository.GetById(quoteUpdate.Id);
            if(product.Id > 0) 
            {
                await _quoteRepository.Update(quoteUpdate);
            }
        }

        public async Task Delete( int id)
        {
            var product = await _quoteRepository.GetById(id); 
            if(product.Id > 0)
            {
                await _quoteRepository.Delete(id);
            }
        }
    }
}
