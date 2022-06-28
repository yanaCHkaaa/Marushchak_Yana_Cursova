namespace APIMarvel.Model
{
    public class Character
    {
        public string Copyright { get; set; }
        public Data data { get; set; }

    }
    public class Data
    {
        public List<Results> results { get; set; }
    }
    public class Results
    {
        public string Name { get; set; }
        public double ID { get; set; }
        public string Description { get; set; }
        public Thumbnail thumbnail { get; set; }
    }
    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
