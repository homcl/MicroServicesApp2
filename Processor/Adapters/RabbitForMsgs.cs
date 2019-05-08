using System;
using Processor.Model;
using Processor.Port;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Processor.Adapter
{
    public class RabbitForMsgs : IAmMsgStorageForProcessorToReadAndWriteFrom
    {
        private static ConnectionFactory _connectionFactory;

        public RabbitForMsgs()
        {
            Console.WriteLine("**** Processor/Subscriber side:RabbitForMsgs object has just been instantiated ****");
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
        }

    
        public void ReadMsgFromStore()
        {
            Console.WriteLine("**** Processor/Subscriber side: Inside RabbitForMsgs ReadMsgFromStore ****");

            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "TodoPublisher",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    //consumer.Received += HandleConsumerReceived;

                    // Alternative way of setting a pointer to the Handler:
                    consumer.Received += (eventSrc, eventArgs) =>
                    {
                        var body = eventArgs.Body;
                        var message = System.Text.Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };

                    channel.BasicConsume(
                        queue: "TodoPublisher",
                        autoAck: true,
                        consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }

        private void HandleConsumerReceived(Object eventSrc, BasicDeliverEventArgs eventArgs)
        {
            var body = eventArgs.Body;
            var message = System.Text.Encoding.UTF8.GetString(body);
            Console.WriteLine("***** Inside Processor/Subscriber:HandleConsumerReceived because 'received' event occurred. *****");

            if (message.Length.Equals(0))
            {
                Console.WriteLine("Either there is no message or one has failed to be taken from the queue");
            }
            else
            {
                Console.WriteLine(" [x] Received {0}", message);
            }
        }

        public void WriteMsgToStore(Message msg)
        {
            Console.WriteLine("**** Processor/Subscriber side: Inside RabbitForMsgs WriteMsgToStore ****");
            throw new NotImplementedException();
        }
    }
}
