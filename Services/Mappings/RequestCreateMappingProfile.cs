using AutoMapper;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;

namespace swiftcarpenterApi.Services.Mappings
{
    public class RequestCreateMappingProfile : Profile 
    {
        public RequestCreateMappingProfile()
        {
            // Configuración del mapeo de QuoteCreateDTO a Quote
            CreateMap<QuoteCreateDTO, Quote>()
                 .AfterMap
                 (
                     (src, dest) =>
                     {
                        
                         dest.DateQuote = DateTime.Now;
                     }
                 );
            CreateMap<DetailQuoteCreateDTO, DetailQuote>();
         


        }
    }
    
}
