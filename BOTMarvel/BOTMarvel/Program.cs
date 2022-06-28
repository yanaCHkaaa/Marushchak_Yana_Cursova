//using BOTMarvel.Model;
//using Microsoft.EntityFrameworkCore;
using BOTMarvel;
using BOTMarvel.Clients;
using Newtonsoft.Json;
using BOTMarvel.Model;
using System.Text.Json;

Bot BOTMarvel = new Bot();
BOTMarvel.Start();
Console.ReadKey();


//long UserID = 539682502;
//ComicClient client = new ComicClient();
//var FavouriteList = client.GetFawVomic(UserID).Result;
//await client.GetFawVomic(UserID);
//var options = new JsonSerializerOptions
//{
//    WriteIndented = true
//};
//string json = System.Text.Json.JsonSerializer.Serialize<FavouriteComic[]>(FavouriteList, options);
//FavouriteComic[]? like = System.Text.Json.JsonSerializer.Deserialize<FavouriteComic[]>(json);
//string favcomics = "";
//foreach (var f in like)
//{
//    Console.WriteLine(favcomics += $"\n{f.ComicId}");
//}

//Console.ReadKey();
//ComicClient client = new ComicClient();
//ViewedComic viewedComic = new ViewedComic() { UserId = 23, ComicId = 987 };
//await client.PostViewed(viewedComic);

//ComicListClient mc = new ComicListClient();
//var ComicCharacteristic = mc.FindByName("Hulk").Result;
//var options = new JsonSerializerOptions
//{
//    WriteIndented = true
//};
//string json = System.Text.Json.JsonSerializer.Serialize<ComicList>(ComicCharacteristic, options);
//ComicList? comics = System.Text.Json.JsonSerializer.Deserialize<ComicList>(json);
//foreach (var i in comics.data.results)
//{
//    Console.WriteLine($"{i.Title}\n{i.ID}");
//}


//ComicClient client = new ComicClient();
//var OneComic = client.GetComicAsinc("123").Result;
//var options = new JsonSerializerOptions
//{
//    WriteIndented = true
//};
//string json = System.Text.Json.JsonSerializer.Serialize<Comic>(OneComic, options);
//Comic? onecomic = System.Text.Json.JsonSerializer.Deserialize<Comic>(json);
//string url = "";
//foreach (var u in onecomic.data.results[0].urls)
//{
//    url += $"\nType: {u.Type}\nURL: {u.Url}\n";
//}
//string prices = "";
//foreach (var p in onecomic.data.results[0].prices)
//{
//    prices += $"\nType: {p.Type}\nPrice: {p.Price}\n";
//}
//string creators = "";
//foreach (var c in onecomic.data.results[0].creators.items)
//{
//    creators += $"\nType: {c.Name}\nURL: {c.Role}\n";
//}
//string characters = "";
//foreach (var c in onecomic.data.results[0].characters.items)
//{
//    characters += $"{c.Name}  ";
//}
//Console.WriteLine($"\n{onecomic.data.results[0].Title}\nID: {onecomic.data.results[0].ID}\nDescription: {onecomic.data.results[0].Description}\nFormat: {onecomic.data.results[0].Format}\nCount of page: {onecomic.data.results[0].PageCount}\nURLs: {url}\nPrices: {prices}\nCreators: {creators}\nCharacters: {characters}");



//int ComicID = Int32.Parse(Console.ReadLine());


//ComicClient client = new ComicClient();
//var OneComic = client.GetComicAsinc(ComicID).Result;
//if (OneComic.data == null)
//{
//    Console.WriteLine("ID isn't found. Try again");
//}
//else
//{
//    var options = new JsonSerializerOptions
//    {
//        WriteIndented = true
//    };
//    string json = System.Text.Json.JsonSerializer.Serialize<Comic>(OneComic, options);
//    Comic? onecomic = System.Text.Json.JsonSerializer.Deserialize<Comic>(json);
//    string url = "";
//    foreach (var u in onecomic.data.results[0].urls)
//    {
//        url += $"\nType: {u.Type}\nURL: {u.Url}\n";
//    }
//    string prices = "";
//    foreach (var p in onecomic.data.results[0].prices)
//    {
//        prices += $"\nType: {p.Type}\nPrice: {p.Price}\n";
//    }
//    string creators = "";
//    foreach (var c in onecomic.data.results[0].creators.items)
//    {
//        creators += $"\nName: {c.Name}\nRole: {c.Role}\n";
//    }
//    string characters = "";
//    foreach (var c in onecomic.data.results[0].characters.items)
//    {
//        characters += $"{c.Name}  ";
//    }
//    Console.WriteLine($"\n{onecomic.data.results[0].Title}\nID: {onecomic.data.results[0].ID}\nDescription: {onecomic.data.results[0].Description}\nFormat: {onecomic.data.results[0].Format}\nCount of page: {onecomic.data.results[0].PageCount}\nURLs: {url}\nPrices: {prices}\nCreators: {creators}\nCharacters: {characters}");
//}


//Console.ReadKey();

