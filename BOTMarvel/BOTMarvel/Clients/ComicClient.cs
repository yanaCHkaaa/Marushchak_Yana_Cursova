using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BOTMarvel.Model;
using BOTMarvel.Constant;

namespace BOTMarvel.Clients
{
    public class ComicClient
    {
        private HttpClient _client;
        private static string _addres;
        private static string _timestamp;
        private static string _publickey;
        private static string _hash;

        public ComicClient()
        {
            _addres = Constants.addres;
            _timestamp = Constants.timestamp;
            _publickey = Constants.publicKey;
            _hash = Constants.hash;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_addres);
        }
        public async Task<Comic> GetComicAsinc(int ID)
        {
            var responce = await _client.GetAsync($"/MarvelComic?ID={ID}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Comic>(content);
            return result;
        }


        public async Task<FavouriteComic[]> GetFawVomic(long UserID)
        {
            var response = await _client.GetAsync($"/api/FavouriteComics/{UserID}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FavouriteComic[]>(content);
            return result;
        }

        public async Task PostComic(FavouriteComic favouriteComic)
        {
            var stringPayload = JsonConvert.SerializeObject(favouriteComic);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/FavouriteComics", httpContent);
            var content = response.Content.ReadAsStringAsync().Result;
        }
        public async Task PostViewed(ViewedComic viewedComic)
        {
            var stringPayload = JsonConvert.SerializeObject(viewedComic);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/ViewedComics", httpContent);
            var content = response.Content.ReadAsStringAsync().Result;
        }
    }
}
