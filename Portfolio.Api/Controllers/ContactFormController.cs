using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.ContactForm;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormService contactFormService;

        public ContactFormController(IContactFormService contactFormService)
        {
            this.contactFormService = contactFormService;
        }

        // GET: api/<ContactFormController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.contactFormService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<ContactFormController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.contactFormService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<ContactFormController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactFormAddDto contactForm)
        {
            var result = await this.contactFormService.SaveContactForm(contactForm);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<ContactFormController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ContactFormUpdateDto contactForm)
        {
            var result = await this.contactFormService.ModifyContactForm(contactForm);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
