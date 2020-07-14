using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{

    class Program
    {
        private static readonly Telegram.Bot.TelegramBotClient Bot = new Telegram.Bot.TelegramBotClient("1360100028:AAEbfPyPmHXEqXoFJYnah2ek9Hqhfwq_Tf4");
        static long chanelId = -1001289096681;
        static void Main(string[] args)
        {
            // 透過SendTextMessageAsync來傳送訊息，傳入chanelid及要傳送的訊息
            //chanelId test
            Bot.SendTextMessageAsync(chanelId, "每5秒傳送一個訊息");
            Bot.SendTextMessageAsync(chanelId, "Mickey Mouse");

            var me = Bot.GetMeAsync().Result;
            Console.Title = me.Username;
            Bot.OnMessage += BotOnMessageEcho;
            Bot.OnMessageEdited += BotOnMessageEcho;
           /* Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnReceiveError += BotOnReceiveError;*/
            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @cutebaby0630_Bot");
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnMessageEcho(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message == null || message.Type != MessageType.Text) return;
            switch (message.Text)
            {
                case "":
                    {
                        break;
                    }
                default:
                    {
                        await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                        var keyboard = new InlineKeyboardMarkup(
                        InlineKeyboardButton.WithUrl("Talk to me in private", "https://t.me/cutebaby0630_Bot"));
                        await Bot.SendTextMessageAsync(chanelId, "你剛才說:" + message.Text);
                        break;
                    }
            }
        }
       /* private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            await Bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"Received {callbackQuery.Data}");
        }
        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }*/
    }
}
