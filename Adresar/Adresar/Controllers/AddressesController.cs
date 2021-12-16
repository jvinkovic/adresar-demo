using Date;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Adresar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        private readonly AddressService _service;

        public AddressesController(ILogger<AddressesController> logger, AddressService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Address>> Get(Guid id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Create([FromBody] Address address)
        {
            return Ok(await _service.Create(address));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Address>> Update(Guid id, [FromBody] Address address)
        {
            return Ok(await _service.Update(id, address));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}