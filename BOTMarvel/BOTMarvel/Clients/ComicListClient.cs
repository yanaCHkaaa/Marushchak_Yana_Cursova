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
    public class ComicListClient
    {
        private HttpClient _client;
        private static string _addres;
        private static string _timestamp;
        private static string _publickey;
        private static string _hash;

        public ComicListClient()
        {
            _addres = Constants.addres;
            _timestamp = Constants.apikey;
            _publickey = Constants.publicKey;
            _hash = Constants.hash;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_addres);
        }
        public async Task<ComicList> FindByName(string Name)
        {
            var responce = await _client.GetAsync($"/MarvelComicList?Name={Name}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<ComicList>(content);
            return result;
        }
    }
}
