using Amazon.Lambda.SQSEvents;

namespace MyFunction1
{
    internal class Processor : IProcessor
    {
        public async Task ProcessRequest(SQSEvent.SQSMessage message)
        {
            Console.WriteLine($"ProcessRequest received MessageId {message.MessageId}");
            await Task.CompletedTask;
        }
    }
}
