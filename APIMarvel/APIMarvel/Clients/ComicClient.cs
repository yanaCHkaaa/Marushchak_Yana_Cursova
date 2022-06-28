using Newtonsoft.Json;
using APIMarvel.Model;
using APIMarvel.Constant;

namespace APIMarvel.Clients
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
            var responce = await _client.GetAsync($"/v1/public/comics/{ID}?ts={_timestamp}&apikey={_publickey}&hash={_hash}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Comic>(content);
            return result;
        }

    }
}
