using System;
using EasyNetQ;
using Messages;
using Message = Messages.Message;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<Message>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(Message textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
