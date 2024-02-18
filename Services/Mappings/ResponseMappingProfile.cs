 using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;

namespace swiftcarpenterApi.Services.Mappings
{
    public class ResponseMappingProfile : Profile
    {
        public ResponseMappingProfile()
        {
            CreateMap<Quote, QuoteDTO>()
                .ForMember(
                    dest => dest.DateQuote,
                    opt => opt.MapFrom(src => src.DateQuote.Year))
                .ForMember(
                    dest => dest.DetailQuotes,
                     opt => opt.MapFrom(src => src.DetailQuotes))
                 .ForMember(
                        dest => dest.CustomerName,
                         opt => opt.MapFrom(src => src.Customer.CustomerName))
                 
                  .ForMember(
                         dest => dest.Total,
                         opt => opt.MapFrom(src => src.DetailQuotes.Sum(dq => dq.Subtotal)))
                  .ForMember(
                
                    dest => dest.Status,
                    opt => opt.MapFrom( src => src.StatusQuote ? "Aceptado" : "Pendiente")
                );
                



            CreateMap<DetailQuote, DetailQuoteDTO>()
                .ForMember( dest => dest.ProductName, opt => opt.MapFrom( src => src.Product.ProductType.TypeName))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(
                     src => src.Product.DescriptionProduct
                    
                    ))
                
                ;


            CreateMap<Customer, CustomerDTO>()
                .ForMember(
                    dest => dest.Quotes,
                    opt => opt.MapFrom( src => src.Quotes)
                );



            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(
                    src => src.ProductType.TypeName

                    ))
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(
                    src => src.Material.MaterialName
                    ))
                .ForMember( dest => dest.FinishType, opt => opt.MapFrom(
                    src => src.FinishType.FinishName
                    ))
                .ForMember( dest => dest.Size, opt => opt.MapFrom(
                    src => src.Size.SizeName
                    ))
                .ForMember( dest => dest.Color, opt => opt.MapFrom(
                    src => src.Color.ColorName
                    ))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(
                    src => src.Price
                    ))
                .ForMember(dest => dest.DescriptionProduct , opt => opt.MapFrom(
                    src => src.DescriptionProduct
                    ))
                ;

            CreateMap<Customer, CustomerResponseDTO>();

            CreateMap<ProductType, ProductTypeDTO>();
                //.ForMember(dest => dest.Products, opt => opt.Ignore())
                // .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));


            CreateMap<Material, MaterialDTO>();
            
            CreateMap<Color,  ColorResponseDTO>();

            CreateMap<Size, SizeResponseDTO>();
            
            CreateMap<FinishType , FinishTypeDTO>();



        }

   
    }
}
