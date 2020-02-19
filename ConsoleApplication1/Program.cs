﻿using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Awesome
{
    class Program
    {
        static ITelegramBotClient botClient;
            
        static void Main()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            botClient = new TelegramBotClient("993694663:AAHCzWB3QfMoyffKgBNClmROCPIkuzXQtqc");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)  
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }
    }
}

