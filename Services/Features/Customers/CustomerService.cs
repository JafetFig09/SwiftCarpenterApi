using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Infraestructure.Repositories;

namespace swiftcarpenterApi.Services.Features.Customers
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task Add(Customer customer)
        {
            await _customerRepository.Add(customer);
        }


        public async Task Update(Customer customerUpdate)
        {

            var customer = await GetById(customerUpdate.Id);
            if (customer.Id > 0)
            {
                await _customerRepository.Update(customerUpdate);
            }

        }


        public async Task Delete(int id)
        {
            var customer = await GetById(id);
            if (customer.Id > 0)
            {
                await _customerRepository.Delete(id);
            }

        }
    }
}
