using Microsoft.AspNetCore.Mvc;
using APIMarvel.Clients;
using APIMarvel.Model;


namespace APIMarvel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarvelComicController : ControllerBase
    {
        [HttpGet(Name = "GetMarvelComic")]
        public Comic ID(int ID)
        {
            ComicClient client2 = new ComicClient();
            return client2.GetComicAsinc(ID).Result;
        }
    }
}

