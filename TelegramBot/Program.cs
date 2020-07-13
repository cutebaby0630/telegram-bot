using System;

namespace TelegramBot
{
    class Program
    {
        static Telegram.Bot.TelegramBotClient Bot = new Telegram.Bot.TelegramBotClient("1360100028:AAEbfPyPmHXEqXoFJYnah2ek9Hqhfwq_Tf4");
        static long chanelId = -1001289096681;
        private void Tc_MessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, "你剛才說:" + e.Message.Text);
            //MessageBox.Show(e.Message.Text);
        }
            
        static void Main(string[] args)
        {
   
            // 透過SendTextMessageAsync來傳送訊息，傳入chanelid及要傳送的訊息
            Bot.SendTextMessageAsync(chanelId, "每5秒傳送一個訊息");

            Bot.SendTextMessageAsync(chanelId, "Mickey Mouse");

            Console.ReadLine();
        }
    }
}
