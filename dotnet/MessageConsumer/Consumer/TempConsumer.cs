using MessageConsumer.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MessageConsumer.Consumer
{
    public class OnboardResponseEntity
    {
        public string WelcomeMessage { get; set; }

        public string BankIFSC { get; set; }

        public int YourAccountNumber { get; set; }

        public string UserEmail { get; set; }

    }
    public class TempConsumer : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IHttpClientFactory httpClientFactory;

        // private readonly IDbContextFactory<AppDbContext> contextFactory;
        private IConnection _connection;
        private IModel _channel;



       // public TempConsumer(IDbContextFactory<AppDbContext> contextFactory)
        public TempConsumer(IServiceScopeFactory scopeFactory, IHttpClientFactory httpClientFactory)
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("AccountNumberAutomation", true, false);
            this.scopeFactory = scopeFactory;
            this.httpClientFactory = httpClientFactory;
            // this.contextFactory = contextFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            await Task.Run(() =>
            {
                //int accountNumber = 0;
                consumer.Received += (model, ea) =>
                {
                  
                    var body = ea.Body;

                    var message = Encoding.UTF8.GetString(body.ToArray());

                    var result = JsonSerializer.Deserialize<OnboardResponseEntity>(message);

                    Console.WriteLine(result.YourAccountNumber);
                    Console.WriteLine(result.BankIFSC);
                    Console.WriteLine(result.WelcomeMessage);
                    Console.WriteLine(result.UserEmail);

                    HttpClient client = httpClientFactory.CreateClient();

                    HttpRequestMessage OutGoingMessage = new HttpRequestMessage
                    {
                        Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json"),
                        RequestUri = new Uri("http://localhost:7000/gateway/ActivationUpdate"),
                        Method = HttpMethod.Post,
                    };

                    Console.WriteLine(OutGoingMessage.Content);

                    client.Send(OutGoingMessage);

                    //accountNumber = Convert.ToInt32(message);

                    //var scope = scopeFactory.CreateScope();
                    //Console.WriteLine("Here", accountNumber);
                    //var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    //var accdetails = new AccountDetails()
                    //{
                    //    AcccountNumber = accountNumber
                    //};
                    //dbContext.AccountTable.AddAsync(accdetails);
                    //dbContext.SaveChangesAsync();
                };
            });




            /* using (AppDbContext dbContext = contextFactory.CreateDbContext())
             {
                 var accdetails = new AccountDetails()
                 {
                     AcccountNumber = accountNumber
                 };
                 dbContext.AccountTable.AddAsync(accdetails);
             }*/


            _channel.BasicConsume(queue: "AccountNumberAutomation", autoAck: true, consumer: consumer);

            //return Task.CompletedTask;
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }
    }
}
