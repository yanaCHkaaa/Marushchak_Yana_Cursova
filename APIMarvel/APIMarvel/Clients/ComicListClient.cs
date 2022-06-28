using Newtonsoft.Json;
using APIMarvel.Model;
using APIMarvel.Constant;


namespace APIMarvel.Clients
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
            _timestamp = Constants.timestamp;
            _publickey = Constants.publicKey;
            _hash = Constants.hash;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_addres);
        }
        public async Task<ComicList> GetComicListAsinc(double ID)
        {
            var responce = await _client.GetAsync($"/v1/public/characters/{ID}/comics?ts={_timestamp}&apikey={_publickey}&hash={_hash}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<ComicList>(content);
            return result;
        }
        public async Task<Character> FindByName(string Name)
        {
            var responce = await _client.GetAsync($"/v1/public/characters?ts={_timestamp}&apikey={_publickey}&hash={_hash}&name={Name}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Character>(content);
            return result;
        }
    }
}