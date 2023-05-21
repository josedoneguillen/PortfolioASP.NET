using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Subscription;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        // GET: api/<SubscriptionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.subscriptionService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<SubscriptionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.subscriptionService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubscriptionAddDto subscription)
        {
            var result = await this.subscriptionService.SaveSubscription(subscription);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<SubscriptionController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] SubscriptionUpdateDto subscription)
        {
            var result = await this.subscriptionService.ModifySubscription(subscription);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
