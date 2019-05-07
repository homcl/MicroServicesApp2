using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Requester.Model;
using Requester.Port;
using RabbitMQ.Client;

namespace Requester.Adapter
{
    public class RabbitForMsgs : IAmMsgStorageForRequesterToReadAndWriteFrom
    {
        private static ConnectionFactory _connectionFactory;

        public RabbitForMsgs()
        {
            Console.WriteLine("RabbitForMsgs object has just been instantiated");
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 15672
            };
        }

        public Message ReadMsgFromStore()
        {
            Console.WriteLine("**** Inside RABBITForMsgs:ReadMsgFromStore ****");
            return new Message(1, "Returning from RabbitForMsgs: ReadMsgFromStore");
        }

        public void WriteMsgToStore(Message msg)
        {
            Console.WriteLine("**** Inside RabbitForMsgs:WriteMsgToStore ****");

            // Format msg to put on Rabbit queue
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "TodoPublisher",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var msgBodyAsBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));
                    channel.BasicPublish(exchange: "", routingKey: "TodoPublisher", body: msgBodyAsBytes);
                    Console.WriteLine($"TodoPublisher has sent {msgBodyAsBytes}");
                }

                Console.ReadLine();
            }

            // using (var client = new HttpClient())
            // {
            //     client.PostAsJsonAsync("http://localhost:5002/api/msg", msg);
            // 
            // }
        }
    }
}
