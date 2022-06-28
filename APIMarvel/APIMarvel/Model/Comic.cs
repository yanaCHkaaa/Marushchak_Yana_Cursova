namespace APIMarvel.Model
{
    public class Comic
    {
        public Data3 data { get; set; }

    }
    public class Data3
    {
        public List<Results3> results { get; set; }
    }
    public class Results3
    {
        public string Title { get; set; }
        public double ID { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public double PageCount { get; set; }
        public List<Urls> urls { get; set; }
        public List<Prices> prices { get; set; }
        public Creators creators { get; set; }
        public Characters characters { get; set; }
    }
    public class Urls
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }
    public class Prices
    {
        public string Type { get; set; }
        public string Price { get; set; }
    }
    public class Creators
    {
        public List<Items> items { get; set; }
    }
    public class Items
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
    public class Characters
    {
        public List<Items1> items { get; set; }
    }
    public class Items1
    {
        public string Name { get; set; }
    }
}

