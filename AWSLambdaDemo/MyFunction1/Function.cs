using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyFunction1;

public class Function
{
    private readonly IHost host;

    public Function()
    {
        this.host = CreateHost();
    }

    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext _)
    {
        using var scope = this.host.Services.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<IProcessor>();

        foreach (var message in evnt.Records)
        {
            await processor.ProcessRequest(message);
        }
    }

    private static IHost CreateHost()
    {
        var builder = Host
            .CreateDefaultBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>((_, builder) =>
            {
                builder.RegisterType<Processor>().As<IProcessor>();
            });

        return builder.Build();
    }
}