using Date;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Adresar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly ContactService _service;

        public ContactsController(ILogger<ContactsController> logger, ContactService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Create([FromBody] Contact contact)
        {
            return Ok(await _service.Create(contact));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Contact>> Update(Guid id, [FromBody] Contact contact)
        {
            return Ok(await _service.Update(id, contact));
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