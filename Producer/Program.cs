﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyNetQ;
using Messages;
using Message = Messages.Message;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message
                    {
                        Text = input
                    });
                }
            }
        }
    }
}
