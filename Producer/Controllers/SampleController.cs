using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IBus _bus;
        public SampleController(IBus bus)
        {
            this._bus = bus;
        }

        [HttpPost]
        [Route("/sample-call")]
        public async Task<IActionResult> Post(Message msg)
        {

            //var ep = await this._bus.GetSendEndpoint(new Uri("queue:mesajkuyrugu2"));
            //await ep.Send(msg, x =>
            //{
            //    x.ConversationId = new Guid("4be5a967-7d98-4d83-a4ca-526808ce3ee0");
            //});

            await this._bus.Publish(msg, x =>
            {
                x.ConversationId = new Guid("4be5a967-7d98-4d83-a4ca-526808ce3ee0");
            });

            return new OkResult();
        }
    }
}
