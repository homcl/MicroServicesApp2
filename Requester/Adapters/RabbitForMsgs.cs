using System;
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
            Console.WriteLine("**** Requester side:RabbitForMsgs object has just been instantiated ****");
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
        }

        public Message ReadMsgFromStore()
        {
            Console.WriteLine("**** Requester side:Inside RABBITForMsgs:ReadMsgFromStore ****");
            return new Message();
        }

        public void WriteMsgToStore(Message msg)
        {
            Console.WriteLine("**** Requester side:Inside RabbitForMsgs:WriteMsgToStore ****");

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
                    var serializedMsg = JsonConvert.SerializeObject(msg);

                    var msgBodyAsBytes = Encoding.UTF8.GetBytes(serializedMsg);
                    //var msgBodyAsBytes = Convert.ToBase64String(msg, Base64FormattingOptions.InsertLineBreaks);
                    channel.BasicPublish(exchange: "", routingKey: "TodoPublisher", body: msgBodyAsBytes);
                    Console.WriteLine($"**** Requester side:TodoPublisher has sent {msgBodyAsBytes} ****");
                }

                Console.ReadLine();
            }
        }
    }
}
