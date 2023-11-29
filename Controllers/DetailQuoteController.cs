//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using SwiftCarpenter.Domain.Entities;
//using swiftcarpenterApi.Domain.Dtos;
//using swiftcarpenterApi.Services.Features.DetailQuotes;
//using swiftcarpenterApi.Services.Features.Products;
//using swiftcarpenterApi.Services.Features.Quotes;
//using System;


//namespace swiftcarpenterApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class DetailQuoteController : ControllerBase
//    {
//        private readonly DetailQuoteService _detailQuoteService;
//        private readonly IMapper _mapper;
//        private readonly ProductService _productService;

//        public DetailQuoteController(DetailQuoteService deatilQuoteService, IMapper mapper, ProductService productService)
//        {
//            this._detailQuoteService = deatilQuoteService;
//            this._mapper = mapper;
//            this._productService = productService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var detailQuotes = await _detailQuoteService.GetAll();

//            var detailQuotesDto = _mapper.Map<IEnumerable<DetailQuoteDTO>>(detailQuotes);
//            return Ok(detailQuotesDto);
//        }

//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var detailQuote = await _detailQuoteService.GetById(id);
//            if (detailQuote.Id <= 0)
//            {
//                return NotFound();
//            }

//            var detailQuoteDto = _mapper.Map<DetailQuoteDTO>(detailQuote);
//            return Ok(detailQuoteDto);
//        }


//        [HttpPost("Quotes/{id:int}")]
//        public async Task<IActionResult> Add(int Id,DetailQuoteCreateDTO detailQuoteDto)
//        {
//            var product = await _productService.GetById(detailQuoteDto.ProductId);

//            if (product == null)
//            {
//                return BadRequest("El producto no existe.");
//            }
//            decimal subtotal = detailQuoteDto.Amount * product.Price;

//            var detailQuote = new DetailQuote
//            {
//                QuoteId = Id,
//                ProductId = detailQuoteDto.ProductId,
//                Amount = detailQuoteDto.Amount,
//                Subtotal = subtotal
//            };

//            await _detailQuoteService.Add(detailQuote);

//            var dto = _mapper.Map<DetailQuoteDTO>(detailQuote);

//            return CreatedAtAction(nameof(GetById), new { id = detailQuote.Id }, dto);


//        }



//        [HttpPut("{id:int}")]
//        public async Task<IActionResult> Update(int id, DetailQuote detailQuote)
//        {
//            if (id != detailQuote.Id)
//            {
//                return BadRequest();
//            }

//            await _detailQuoteService.Update(detailQuote);
//            return NoContent();
//        }

//        [HttpDelete("{id:int}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _detailQuoteService.Delete(id);
//            return NoContent();

//        }

//    }

