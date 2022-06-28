using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Exceptions;
using BOTMarvel.Clients;
using Newtonsoft.Json;
using BOTMarvel.Model;
using System.Text.Json;



namespace BOTMarvel
{
    public class Bot
    {
        TelegramBotClient botClient = new TelegramBotClient("5480055188:AAFErTmRyFKp8VwsvZt8H0nQX9UA0bW5_hs");//змінна дозволяє підключитись до тг бота
        CancellationToken cancellationToken = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
        private readonly object Selective;

        public int ComicID { get; set; }
        public string LastText { get; private set; }
        public static long UserID { get; private set; }

        public async Task Start()
        {
            botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
            var botMe = await botClient.GetMeAsync();
            Console.WriteLine($"Bot {botMe.Username} is working");
            Console.ReadKey();
        }

        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"There is a misstake in TelegramBot API:\n{apiRequestException.ErrorCode}" +
                $"\n{apiRequestException.Message}", _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async Task HandlerCallbackQuery(ITelegramBotClient botClient, CallbackQuery? callbackQuery)
        {
            string imagePath = null;

            if (callbackQuery.Data.StartsWith("Avengers"))
            {
                imagePath = Path.Combine(Environment.CurrentDirectory, "Avengers.jpg");
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Avengers").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Avengers.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open,FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Thor"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Thor").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Thor.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, herocomics);
            }
            if (callbackQuery.Data.StartsWith("Hulk"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Hulk").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Hulk.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Black Widow"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Black Widow").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Black Widow.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Captain America"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Captain America").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Captain America.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            
            if (callbackQuery.Data.StartsWith("Doctor Strange"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Doctor Strange").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Doctor Strange.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Wolverine"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Wolverine").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Wolverine.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Iron Man"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Iron Man").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Iron Man.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Scarlet Witch"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Scarlet Witch").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Scarlet Witch.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");
            }
            if (callbackQuery.Data.StartsWith("Hawkeye"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Hawkeye").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Hawkeye.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Jessica Jones"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Jessica Jones").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Jessica Jones.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Deadpool"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Luke Cage").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Deadpool.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Luke Cage"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Luke Cage").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Luke Cage.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Black Panther"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Black Panther").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Black Panther.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Thing"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Thing").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Thing.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Vision"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Vision").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Vision.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Nick Fury"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Nick Fury").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Nick Fury.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Rocket Raccoon"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Rocket Raccoon").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Rocket Raccoon.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Groot"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Groot").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Groot.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
            if (callbackQuery.Data.StartsWith("Gamora"))
            {
                ComicListClient client = new ComicListClient();
                var ComicCharacteristic = client.FindByName("Gamora").Result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
                ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
                string herocomics = "";
                foreach (var i in comics.data.results)
                {
                    herocomics += $"\n{i.Title}\nID: {i.ID}\nFormat: {i.Format}\n";
                }
                imagePath = @"D:\EDUCATION\ОП\2 СЕМЕСТР\Images\Gamora.jpg";
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    await botClient.SendPhotoAsync(callbackQuery.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Your choice:  {callbackQuery.Data}\n{herocomics}");

            }
        }

        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandlerMessageAsync(botClient, update.Message, cancellationToken);
            }

            if (update?.Type == UpdateType.CallbackQuery)
            {
                await HandlerCallbackQuery(botClient, update.CallbackQuery);
            }
        }

        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            if (message.Text == "/start")
            {

                ReplyKeyboardMarkup replyKeyboardMarkup = new
                (
                    new[]
                    {
                        new KeyboardButton [] { "🦸🏼‍♀️Comics by a hero", "📚Comic info", "❤️Favourites" }
                    }
                )
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id, "Hi👋🏻\nI'm your your Marvel Comics Bot🦹🏼‍♀️ and I'll help you to find any information related to Marvel comics🫡." +
                    $"\nAll that you need is to select a category✅ and click on the button bellow⬇️...and of course perfect mood🤡\nAlso you can read an explanation of commands /help", replyMarkup: replyKeyboardMarkup);

                return;
            }
            else if (message.Text == "/help")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "🆘HELP🆘\n<🦸🏼‍♀️Comics by a hero> - with this button you can get a list of comics where is a hero that you will choose\n<📚Comic info> - using this command you can read more specific information about a particular comic\n<❤️Favourites> - here you can view comics that you like");
                return;
            }
            else if (message.Text == "🦸🏼‍♀️Comics by a hero")
            {
                InlineKeyboardMarkup inlineKeyboard = new(new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Avengers", "Avengers"),
                        InlineKeyboardButton.WithCallbackData("Thor", "Thor")
                    }, new[]
                    {
                    InlineKeyboardButton.WithCallbackData("Hulk", "Hulk"),
                    InlineKeyboardButton.WithCallbackData("Black Widow", "Black Widow")
                    },new[]
                    {
                    InlineKeyboardButton.WithCallbackData("Captain America", "Captain America"),
                    InlineKeyboardButton.WithCallbackData("Doctor Strange", "Doctor Strange")
                    },new[]
                    {
                    InlineKeyboardButton.WithCallbackData("Wolverine", "Wolverine"),
                    InlineKeyboardButton.WithCallbackData("Iron Man", "Iron Man")
                    },new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Scarlet Witch", "Scarlet Witch"),
                        InlineKeyboardButton.WithCallbackData("Hawkeye", "Hawkeye")
                    },new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Jessica Jones", "Jessica Jones"),
                        InlineKeyboardButton.WithCallbackData("Deadpool", "Deadpool")
                    },new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Luke Cage", "Luke Cage"),
                        InlineKeyboardButton.WithCallbackData("Black Panther", "Black Panther")
                    },new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Thing", "Thing"),
                        InlineKeyboardButton.WithCallbackData("Vision", "Vision")
                    },new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Nick Fury", "Nick Fury"),
                        InlineKeyboardButton.WithCallbackData("Rocket Raccoon", "Rocket Raccoon")
                    },new[]
                    {

                        InlineKeyboardButton.WithCallbackData("Groot", "Groot"),
                        InlineKeyboardButton.WithCallbackData("Gamora", "Gamora")
                    }

                }

                 );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Choose a Hero", replyMarkup: inlineKeyboard);
                return;
            }

            else
            if (message.Text == "❤️Favourites")
            {
                UserID = message.Chat.Id;
                ComicClient client = new ComicClient();
                var FavouriteList = client.GetFawVomic(UserID).Result;
                await client.GetFawVomic(UserID);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<FavouriteComic[]>(FavouriteList, options);
                FavouriteComic[]? like = System.Text.Json.JsonSerializer.Deserialize<FavouriteComic[]>(json);
                string favcomics = "";
                foreach (var f in like)
                {
                    favcomics += $"\n{f.ComicId}";
                }
                if (favcomics == "")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Your list is empty💨");
                    return;
                }
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Your list with ID of ❤️favourite comics❤️\n{favcomics}\nIf you wanna find more information about any of them, use a button <📚Comic info>");
                return;
            }

            else
            if (message.Text == "📚Comic info")
            {
                LastText = "📚Comic info";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Enter ID of a comic which you wanna find");
                return;

            }
            else
            if (message.Text != null)
            {
                Searching(botClient, message);
                return;
            }
            else
            if (LastText == "Enter ID of a comic which you wanna find")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"ID: {ComicID}");
                return;
            }
            
        }
        private async Task Searching(ITelegramBotClient botClient, Message message)
        {
            if (LastText == "📚Comic info")
            {
                ComicID = Int32.Parse(message.Text);
                LastText = $"{ComicID}";

                UserID = message.Chat.Id;
                ComicClient client = new ComicClient();
                ViewedComic viewedComic = new ViewedComic() { UserId = UserID, ComicId = ComicID };
                await client.PostViewed(viewedComic);

                
                var OneComic = client.GetComicAsinc(ComicID).Result;
                if (OneComic.data == null)
                {
                   await botClient.SendTextMessageAsync(message.Chat.Id, "ID isn't found. Try again👇🏻");
                   return;
                }
                else
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = System.Text.Json.JsonSerializer.Serialize<Comic>(OneComic, options);
                    Comic? onecomic = System.Text.Json.JsonSerializer.Deserialize<Comic>(json);
                    string url = "";
                    foreach (var u in onecomic.data.results[0].urls)
                    {
                        url += $"\nType: {u.Type}\nURL: {u.Url}\n";
                    }
                    string prices = "";
                    foreach (var p in onecomic.data.results[0].prices)
                    {
                        prices += $"\nType: {p.Type}\nPrice: {p.Price}\n";
                    }
                    string creators = "";
                    foreach (var c in onecomic.data.results[0].creators.items)
                    {
                        creators += $"\nName: {c.Name}\nRole: {c.Role}\n";
                    }
                    string characters = "";
                    foreach (var c in onecomic.data.results[0].characters.items)
                    {
                        characters += $"{c.Name}  ";
                    }
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"\n{onecomic.data.results[0].Title}\nID: {onecomic.data.results[0].ID}\nDescription: {onecomic.data.results[0].Description}\nFormat: {onecomic.data.results[0].Format}\nCount of page: {onecomic.data.results[0].PageCount}\nURLs: {url}\nPrices: {prices}\nCreators: {creators}\nCharacters: {characters}\n\nIf you wanna add this comic to favourite click here /Favourite") ;
                    return;
                }

            }
            if (message.Text == "/Favourite")
            {
                UserID = message.Chat.Id;
                ComicClient client = new ComicClient();
                FavouriteComic favcomic = new FavouriteComic() {UserId = UserID, ComicId = ComicID };
                await client.PostComic(favcomic);
                await botClient.SendTextMessageAsync(message.Chat.Id, "Comic was added☑️");
                return;
            }
        }

    }
}
