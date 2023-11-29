
using AutoMapper;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;
using swiftcarpenterApi.Services.Features.Products;

public class RequestCreateMappingProfile : Profile
{

    public RequestCreateMappingProfile()
    {
        //this._productService = productService;

        //CreateMap<QuoteCreateDTO, Quote>()
        //    .AfterMap((src, dst) =>
        //    {
        //        dst.DateQuote = DateTime.Now;
        //    })
        //    .ForMember(dest => dest.DetailQuotes, opt => opt.MapFrom(src => src.DetailQuotes));

        //CreateMap<DetailQuoteCreateDTO, DetailQuote>()
        //    .AfterMap(async (src, dst) =>
        //    {
        //        var product = await _productService.GetById(src.ProductId);
        //        if (product == null) { return; }
        //        dst.Subtotal = product.Price * src.Amount;
        //    });
        CreateMap<CustomerCreateDTO, Customer>();

    }

}
