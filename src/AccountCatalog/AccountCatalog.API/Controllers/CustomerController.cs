using System.Xml.Linq;
using AccountCatalog.API.DTO.Customers;
using AccountCatalog.Application.UseCases.Customers.Commands;
using AccountCatalog.Application.UseCases.Customers.Queries;
using AccountCatalog.Domain.Entities.Customer;

namespace AccountCatalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public CustomerController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCustomers()
        {
            var fromCache = await _distributedCache.GetStringAsync("GetAllCustomers");

            if (fromCache is null)
            {
                var customers = await _mediator.Send(new GetAllCustomersQuery());

                if (!customers.Any())
                    return Ok();

                fromCache = JsonSerializer.Serialize(customers);
                await _distributedCache.SetStringAsync("GetAllCustomers", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<List<Customers>>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetCustomerByPhoneNumber(string PhoneNumber)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Customer{PhoneNumber}");

            if (fromCache is null)
            {
                var customer = await _mediator.Send(new GetCustomerByPhoneQuery { PhoneNumber = PhoneNumber });

                if (customer is null)
                    return Ok();

                fromCache = JsonSerializer.Serialize(customer);
                await _distributedCache.SetStringAsync($"Customer{PhoneNumber}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<Customers>(fromCache);
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCustomer(CreateCustomerDTO createCustomerDTO)
        {
            CreateCustomerCommand customer = new CreateCustomerCommand()
            {
                FirstName=createCustomerDTO.FirstName,
                LastName=createCustomerDTO.LastName,
                Password=createCustomerDTO.Password,
                PhoneNumber=createCustomerDTO.PhoneNumber
            };
            var result = await _mediator.Send(customer);
            await _distributedCache.RemoveAsync($"Customer{customer.PhoneNumber}");
            await _distributedCache.RemoveAsync($"GetAllCustomers");
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCustomer(UpdateCustomerDTO updateCustomerDTO)
        {
            UpdateCustomerCommand customer = new UpdateCustomerCommand()
            {
                FirstName = updateCustomerDTO.FirstName,
                LastName = updateCustomerDTO.LastName,
                Password = updateCustomerDTO.Password,
                PhoneNumber = updateCustomerDTO.PhoneNumber,
                PhoneNumberChange = updateCustomerDTO.PhoneNumberChange,
                RoleId = updateCustomerDTO.RoleId
            };
            var result = await _mediator.Send(customer);

            await _distributedCache.RemoveAsync($"Customer{customer.PhoneNumber}");
            await _distributedCache.RemoveAsync($"GetAllCustomers");

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCustomer(string PhoneNumber)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand() { PhoneNumber = PhoneNumber });

            await _distributedCache.RemoveAsync($"Customer{PhoneNumber}");
            await _distributedCache.RemoveAsync($"GetAllCustomers");

            return Ok(result);
        }
    }
}

