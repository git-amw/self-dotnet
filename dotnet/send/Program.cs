using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using static A;

var message = new OnboardResponseEntity()
{
    WelcomeMessage = "Welcome to Infinity Bank ! We are thrilled to have you as our newest customer. Enjoy a seamless banking experience with us!!",
    BankIFSC = "INFYNAGBFSI",
    YourAccountNumber = 12345678,
    UserEmail = "cekoten453@inkiny.com",
};

A.SendMessage<A.OnboardResponseEntity>(message);

public static class A
{
    public class OnboardResponseEntity
    {
        public string WelcomeMessage { get; set; }

        public string BankIFSC { get; set; }

        public int YourAccountNumber { get; set; }

        public string UserEmail { get; set; }

    }
    public static void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("AccountNumberAutomation", true, false);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "AccountNumberAutomation", body: body);
    }
}
