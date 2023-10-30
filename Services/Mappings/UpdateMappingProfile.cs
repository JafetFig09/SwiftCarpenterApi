using AutoMapper;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;

namespace swiftcarpenterApi.Services.Mappings
{
    public class UpdateMappingProfile : Profile
    {
        public UpdateMappingProfile()
        {
            CreateMap<QuoteUpdateDTO, Quote>()
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
