using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Collections;
using System.Threading;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace PrizrakGulaga
{
    class Program
    {

        private static string token = "1171466776:AAEOuRuvndU-MzqT6_-iTX81DU5mNwIbco4";
        private static TelegramBotClient client;
        public static ArrayList frazes;
        public static ArrayList usernames;
        public static ArrayList randomMessages;
        public static MessageEventArgs messageEvent;
        private static ArrayList randomAnswerToTagPrizrak;
        private static ArrayList randoAnswerToBot;
        public static int forwardedMessageId;


        // chat ID "-1001468546184"
        // мій id 778263684



        static void Main(string[] args)
        {
            FillFrazessList(); // записать всі фрази сразу
            client = new TelegramBotClient(token);
            client.StartReceiving();

            

           // forwardRandomMessageFromAnotherGroup();
            client.OnMessage += OnMessageHandler;
            client.OnMessage += ReplyToTag;
            client.OnMessage += ReplyToBot;
            
            SendRandomMessage();
            SendDice();
            client.StopReceiving();
            
            
            

            
        }

        

        private static async void ReplyToTag(object sender, MessageEventArgs e)
        {
            var msg = e.Message;



            if (msg.Text != null)
            {
                var textWithBotName = msg.Text;
                
                Console.WriteLine(textWithBotName);
                if (msg.Text.Contains("@prizrakGulagaBot"))
                {
                    
                    Thread.Sleep(7000);
                    var randomInstance = new Random();
                    string rndFraze = (string)randomAnswerToTagPrizrak[randomInstance.Next(0, (randomAnswerToTagPrizrak.Count) - 1)];
                    await client.SendTextMessageAsync(msg.Chat.Id, rndFraze, replyToMessageId: msg.MessageId);
                }
            }

           // forwardRandomMessageFromAnotherGroup();

        }


        private static async void ReplyToBot(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            
            if (msg.Text != null)
            {
                var textWithBotName = msg.Text;
                Console.WriteLine(textWithBotName);
                if ((msg.Text.Contains("осуждаю")) || (msg.Text.Contains("осуждение")))
                {
                    Thread.Sleep(7000);
                    var randomInstance = new Random();
                    string rndFraze = (string)randoAnswerToBot[randomInstance.Next(0, (randoAnswerToBot.Count) - 1)];
                    await client.SendTextMessageAsync(msg.Chat.Id, rndFraze, replyToMessageId: msg.MessageId);
                }
                
            }
        }



        

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            var timeNow = DateTime.Now;
            Console.WriteLine("MessageId from user: "+ msg.MessageId);
            
            

            
            /*  Console.WriteLine("Time now: "+timeNow);
              Console.WriteLine("Time -10: "+timeNow.AddMinutes(-10));
              Console.WriteLine("Message date: "+msg.Date);  */

            var msgDate = msg.Date.AddHours(3);


            if (msg.Text != null & msgDate > timeNow.AddMinutes(-2))
            {

                var randomInstance = new Random();
                var rndNumber = randomInstance.Next(0, 10);
                Console.WriteLine(rndNumber);

                if (rndNumber == 3)    /// шанс ріплая в чат
                {
                    Thread.Sleep(5000);
                    string rndFraze = (string)frazes[randomInstance.Next(0, (frazes.Count) - 1)];
                    Console.WriteLine(rndFraze);
                    await client.SendTextMessageAsync(msg.Chat.Id, rndFraze, replyToMessageId: msg.MessageId);

                }
            }
            else 
            {
                //Console.WriteLine("false");
            }

        }


        public static void FillFrazessList() {

            frazes = new ArrayList();
            frazes.Add("пшов нахой, говнарь");
            frazes.Add("я приїду в бердос і розібью тобі ебало");
            frazes.Add("а смішні рофли сьодня будуть?");
            frazes.Add("Це карочі Макс в сквад вривається");
            frazes.Add("ясно, клоун");
            frazes.Add("нюахй піську, шлюха");
            frazes.Add("кловн");
            frazes.Add("welCum");
            frazes.Add("аж сракотан загорівся");
            frazes.Add("це хуйня, а текєн круче");
            frazes.Add("це хуйня");
            frazes.Add("да ти заїбеш");
            frazes.Add("ти це максу скажи");
            frazes.Add("ти це дімі скажи");
            frazes.Add("на твому місці я би не пиздів так");
            frazes.Add("хулі ти пиздиш, твій IQ размєром з мою піпісю");
            frazes.Add("я тебе за ці слова ушатать можу"); 
            frazes.Add("я ща @tsilinskyi позву, він тебе з чата йобне");
            frazes.Add("і шо блять??");
            frazes.Add("хулі ти пиздиш");
            frazes.Add("пиздиш хуйню, ростеш дибілом");
            frazes.Add("ти обідився?");
            frazes.Add("даж незнаю шо добавить");
            frazes.Add("тож так думаю");
            frazes.Add("неа, хуйня це ");
            frazes.Add("за такі слова тебе на бутилку посадять");
            frazes.Add("на бутилку!");
            frazes.Add("абіда єбана");
            frazes.Add("хулі ви до Максіма доїбались");
            frazes.Add("ну ти @khaleesi_tg_bot шлюха");
            frazes.Add("ну ти @khaleesi_tg_bot шлюха");




            usernames = new ArrayList();
            usernames.Add("@jjoestar");
            usernames.Add("@vasiliygrynkiv");
            usernames.Add("@Maxim_Thomas");
            usernames.Add("@khaleesi_tg_bot");
            usernames.Add("@503793837 (Nikita)");
            usernames.Add("@AstraCloud");
            usernames.Add("@chisel412");
            usernames.Add("@prizrakGulagaBot");


            randomMessages = new ArrayList();
            randomMessages.Add("Шо мовчите тварі?");
            randomMessages.Add("Суету навести охота");
            randomMessages.Add("Запуск срача через 3..2..1..");
            randomMessages.Add("Є хто живий??");
            randomMessages.Add("Шото скучно, мож срач в гулагє устроїм??");


            randomAnswerToTagPrizrak = new ArrayList();
            randomAnswerToTagPrizrak.Add("чєго??");
            randomAnswerToTagPrizrak.Add("хулі ти доєбався?");
            randomAnswerToTagPrizrak.Add("іди до Діми доєбись");
            randomAnswerToTagPrizrak.Add("шо нада, чмоня?");
            randomAnswerToTagPrizrak.Add("шо хоч??");
            randomAnswerToTagPrizrak.Add("не тегай мене, я занятий");
            randomAnswerToTagPrizrak.Add("ще раз мене тегнеш, приїду в бєрдос, а далі угадай");


            randoAnswerToBot = new ArrayList();
            randoAnswerToBot.Add("кого ти осуждаєш, підріла?");
            randoAnswerToBot.Add("себе осуждай, єбанько");


                



            /* 
             @jjoestar
             @vasiliygrynkiv
             @Maxim_Thomas
             @khaleesi_tg_bot
            @503793837 (Nikita) 
            @AstraCloud
            @chisel412


             */


        }

        public static async void SendRandomMessage() {

            
            Random random = new Random();
            do
            {
                string date = DateTime.UtcNow.ToString("mm");
                int minutes = Convert.ToInt32(date);
                if (minutes == 33)
                {
                    var rnd = random.Next(0, (randomMessages.Count) - 1);
                    await client.SendTextMessageAsync(-1001468546184, (string)randomMessages[rnd]);
                    SendDice();
                }

                Thread.Sleep(59000);
            } while (true);
        }


        public static async void SendDice()
        {
            Random random = new Random();
            int diceNumber = random.Next(1, 6);
            int randomUser = random.Next(0, usernames.Count);

            await client.SendTextMessageAsync(-1001468546184, "Ща кину кубік, якшо випаде [" + diceNumber + "], то " + usernames[randomUser] + " піідор");
            Thread.Sleep(30000);
            await client.SendDiceAsync(-1001468546184, false, 1, null, default, Emoji.Dice);
           
        }


        //ne vorkae
        public static async void forwardRandomMessageFromAnotherGroup()
        {

            //var msg = e.Message;

            /* Console.WriteLine("ForwardFromChat.Description: " + msg.ForwardFromChat.Description);
             Console.WriteLine("ForwardFromChat.Id: " + msg.ForwardFromChat.Id);
             Console.WriteLine("ForwardFromChat.Username: " + msg.ForwardFromChat.Username);
             Console.WriteLine("From.Username: " + msg.From.Username);
             Console.WriteLine("ForwardFrom: " + msg.ForwardFrom);
             Console.WriteLine("ForwardFromMessageId: " + msg.ForwardFromMessageId);*/
            
            await client.ForwardMessageAsync("-1001468546184", "-1001468546184", 71543);  //аморач
           

        }

    }
}
