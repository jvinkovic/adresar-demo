using Microsoft.AspNetCore.Mvc;
using Service;
using Data;

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
        public async Task<ActionResult<Address>> Create([FromBody] AddressDTO address)
        {
            return Ok(await _service.Create(address));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Address>> Update(Guid id, [FromBody] AddressDTO address)
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