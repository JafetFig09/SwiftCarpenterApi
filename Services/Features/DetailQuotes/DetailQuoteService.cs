using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Infraestructure.Repositories;

namespace swiftcarpenterApi.Services.Features.DetailQuotes
{
    public class DetailQuoteService
    {
        private readonly DetailQuoteRepository _detailQuoteRepository;

        public DetailQuoteService(DetailQuoteRepository detailQuoteRepository)
        {
            this._detailQuoteRepository = detailQuoteRepository;

        }

        public async Task<IEnumerable<DetailQuote>> GetAll()
        {
            return await _detailQuoteRepository.GetAll();
        }


        public async Task<DetailQuote> GetById(int id)
        {
            return await _detailQuoteRepository.GetById(id);
        }

        public async Task Add(DetailQuote detail)
        {
            await _detailQuoteRepository.Add(detail);
        }

        public async Task Update(DetailQuote detailQuoteUpdate)
        {
            var detailQuote = await _detailQuoteRepository.GetById(detailQuoteUpdate.Id);

            if (detailQuote.Id > 0)
            {
                await _detailQuoteRepository.Update(detailQuoteUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var detailQuote = await _detailQuoteRepository.GetById(id);

            if (detailQuote.Id > 0)
            {
                await _detailQuoteRepository.Delete(id);
            }
        }
    }
}
