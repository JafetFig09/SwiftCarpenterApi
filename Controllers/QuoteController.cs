using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;
using swiftcarpenterApi.Services.Features.DetailQuotes;
using swiftcarpenterApi.Services.Features.Products;
using swiftcarpenterApi.Services.Features.Quotes;
using System;

namespace swiftcarpenterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly QuoteService _quoteService;
        private readonly IMapper _mapper;
        private readonly DetailQuoteService _detailQuoteService;
        private readonly ProductService _productService;

        public QuoteController(QuoteService quoteService, IMapper mapper, ProductService productService,
            DetailQuoteService detailQuoteService)
        {
            this._quoteService = quoteService;
            this._mapper = mapper;
            this._detailQuoteService = detailQuoteService;
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotes = await _quoteService.GetAll();
            //Transforma un quote a un quoteDTO
            var quotesDtos =  _mapper.Map<IEnumerable<QuoteDTO>>(quotes); 

            return Ok(quotesDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quote = await _quoteService.GetById(id);
            if (quote.Id <= 0)
            {
                return NotFound();
            }

            var dto = _mapper.Map<QuoteDTO>(quote);
            return Ok(dto);
        }




        [HttpPost]
        public async Task<IActionResult> Add(QuoteCreateDTO quoteCreate)
        {
            var entity = new Quote
            {
                CustomerId = quoteCreate.CustomerId,
                DateQuote = DateTime.Now,
                DetailQuotes = quoteCreate.DetailQuotes.Select(dto => new DetailQuote
                {
                    ProductId = dto.ProductId,
                    Amount = dto.Amount,
                    Subtotal = CalculateSubtotal(dto.ProductId, dto.Amount)
                }).ToList()
            };

            await _quoteService.Add(entity);


            var dto = new QuoteDTO
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                DateQuote = entity.DateQuote,

            };

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }
        

      


        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _quoteService.Delete(id);
            return NoContent();

        }





        private decimal CalculateSubtotal(int productId, int amount)
        {

            var product = _productService.GetById(productId);
            if (product != null)
            {
                return product.Result.Price * amount;
            }
            return 0;
        }
    }
}
