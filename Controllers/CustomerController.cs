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

        //Optiene todas las cotizaciones del Cliente
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



        //Optiene una cotización especifica del cliente

        [HttpGet("{customerId:int}/Quotes/{quoteId:int}")]
        public async Task<IActionResult> GetCustomerQuote(int customerId, int quoteId)
        {
            var customer = await _customerService.GetById(customerId);

            if (customer.Id <= 0)
            {
                return NotFound("Cliente no encontrado");
            }

            var quote = await _quoteService.GetById(quoteId);

            if (quote == null || quote.CustomerId != customerId)
            {
                return NotFound("Cotización no encontrada para este cliente");
            }

            var dtoQuote = _mapper.Map<QuoteDTO>(quote);
            return Ok(dtoQuote);
        }




        //Cotizaciones Pendientes

        [HttpGet("{customerId:int}/Quotes/Pendientes")]
        public async Task<IActionResult> GetQuotesPendientes( int customerId)
        {

            var quotesStatus = await _quoteService.GetStatusAll( customerId );

            var quotesStatusDTO = _mapper.Map<IEnumerable<QuoteDTO>>(quotesStatus);

            return Ok(quotesStatusDTO);
        }

        [HttpGet("{customerId:int}/Quotes/Acetadas")]
        public async Task<IActionResult> GetQuotesAceptadas(int customerId)
        {

            var quotesStatus = await _quoteService.GetStatus(customerId);

            var quotesStatusDTO = _mapper.Map<IEnumerable<QuoteDTO>>(quotesStatus);

            if(quotesStatusDTO.Count() != 0)
                return Ok(quotesStatusDTO);

            return BadRequest();
        }




        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerCreateDTO customer)
        {
            var entity = _mapper.Map<Customer>(customer);

            await _customerService.Add(entity);
            var dto = _mapper.Map<CustomerDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);

        }



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
