using MassTransit;
using Shared;

namespace Consumer.Consumers
{
    public class MessageConsumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            var originalMsj = context.Message;

            await Task.CompletedTask;
        }
    }
}
