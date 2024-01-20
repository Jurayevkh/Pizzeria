using AccountCatalog.API.DTO.Customers;
using AccountCatalog.Application.UseCases.Customers.Commands;
using AccountCatalog.Application.UseCases.Customers.Queries;

namespace AccountCatalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetCustomerByPhoneNumber(string PhoneNumber)
        {
            var customer = await _mediator.Send(new GetCustomerByPhoneQuery { PhoneNumber = PhoneNumber });
            return Ok(customer);
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
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCustomer(string PhoneNumber)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand() { PhoneNumber = PhoneNumber });
            return Ok(result);
        }
    }
}

