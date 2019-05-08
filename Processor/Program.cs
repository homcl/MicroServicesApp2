using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Processor.Port;
using RabbitMQ.Client.Events;
using System;
using Processor.Adapter;
using RabbitMQ.Client;
using System.Text;

namespace Processor
{
    public class Program
    {
        private static IAmMsgStorageForProcessorToReadAndWriteFrom _subscriber = new RabbitForMsgs();

        public static void Main(string[] args)
        {
//            var factory = new ConnectionFactory() { HostName = "localhost" };
//            using (var connection = factory.CreateConnection())
//            using (var channel = connection.CreateModel())
//            {
//                channel.QueueDeclare(queue: "TodoPublisher",
//                    durable: false,
//                    exclusive: false,
//                    autoDelete: false,
//                    arguments: null);
//
//                var consumer = new EventingBasicConsumer(channel);
//                consumer.Received += (model, ea) =>
//                {
//                    var body = ea.Body;
//                    var message = Encoding.UTF8.GetString(body);
//                    Console.WriteLine(" [x] Received {0}", message);
//                };
//
//                channel.BasicConsume(queue: "TodoPublisher",
//                    autoAck: true,
//                    consumer: consumer);
//
//                Console.WriteLine(" Press [enter] to exit.");
//                Console.ReadLine();
//            }

            _subscriber.ReadMsgFromStore();
            // CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5002");


    }
}
