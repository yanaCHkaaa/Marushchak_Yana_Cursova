using Microsoft.AspNetCore.Mvc;
using APIMarvel.Clients;
using APIMarvel.Model;


namespace APIMarvel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarvelComicListController : ControllerBase
    {
        [HttpGet(Name = "GetMarvelComicList")]
        public ComicList Person(string Name)
        {
            ComicListClient client1 = new ComicListClient();
            var ID = client1.FindByName(Name).Result.data.results[0].ID;
            return client1.GetComicListAsinc(ID).Result;
        }
    }
}
