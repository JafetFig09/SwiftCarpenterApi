using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;
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

        public QuoteController(QuoteService quoteService, IMapper mapper)
        {
            this._quoteService = quoteService;
            this._mapper = mapper;
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
        public async Task<IActionResult> Add(QuoteCreateDTO quote)
        {
            var entity = _mapper.Map<Quote>(quote);

            await _quoteService.Add(entity);

            var dto = _mapper.Map<QuoteDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }


        [HttpPut("{id:int}/Comprar")]
        public async Task<IActionResult> Update(int id,QuoteUpdateDTO quoteUpdateDTO)
        {
            var quote = await _quoteService.GetById(id);
            if (id != quote.Id)
            {
                return BadRequest();
            }
            _mapper.Map(quoteUpdateDTO, quote);
            await _quoteService.Update(quote);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _quoteService.Delete(id);
            return NoContent();

        }
    }
}
