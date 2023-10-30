using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Domain.Dtos;
using swiftcarpenterApi.Services.Features.Customers;
using swiftcarpenterApi.Services.Features.DetailQuotes;
using swiftcarpenterApi.Services.Features.Quotes;

namespace swiftcarpenterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase 
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly QuoteService _quoteService;

        public CustomerController( CustomerService customerService, IMapper mapper, QuoteService quoteService )
        {
            this._customerService = customerService;
            this._mapper = mapper;
            this._quoteService = quoteService;
        }

        //El usuario no necesita ver a los demas usuarios
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var customers = await _customerService.GetAll();

        //    var customersDto = _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
        //    return Ok(customersDto);
        //}

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdCustomeer(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer.Id <= 0)
            {
                return NotFound();
            }

            var dtoCustomer = _mapper.Map<CustomerResponseDTO>(customer);
            return Ok(dtoCustomer);
        }


        [HttpGet("{id:int}/Quotes")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer.Id <= 0)
            {
                return NotFound();
            }

            var dtoCustomer = _mapper.Map<CustomerDTO>(customer);
            return Ok(dtoCustomer);
        }

        //[HttpGet("{customerId:int}/Quotes/{quoteId:int}")]
        //public async Task<IActionResult> GetQuote(int customerId, int quoteId)
        //{
        //    var customer = await _customerService.GetById(customerId);

        //    if (customer.Id <= 0)
        //    {
        //        return NotFound("Cliente no encontrado");
        //    }

        //    var quote = customer.Quotes.FirstOrDefault(q => q.Id == quoteId);

        //    if (quote == null)
        //    {
        //        return NotFound("Cotización no encontrada");
        //    }

        //    var dtoQuote = _mapper.Map<QuoteDTO>(quote);
        //    return Ok(dtoQuote);
        //}



        [HttpPut("{id:int}/Quotes/{quoteId:int}/Comprar")]
        public async Task<IActionResult> Update(int id, int quoteId, QuoteUpdateDTO quoteUpdateDTO)
        {
            var customer = await _customerService.GetById(id);

            if (id != customer.Id)
            {
                return BadRequest();
            }

            var quote = await _quoteService.GetById(quoteId);

            if (quote == null)
                return BadRequest();

            var quoteUpdate = _mapper.Map(quoteUpdateDTO, quote);


            await _quoteService.Update(quoteUpdate);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.Delete(id);
            return NoContent();

        }
    }
}
