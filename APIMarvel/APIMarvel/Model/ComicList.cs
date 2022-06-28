namespace APIMarvel.Model
{
    public class ComicList
    {
        public Data2 data { get; set; }

    }
    public class Data2
    {
        public List<Results2> results { get; set; }
    }
    public class Results2
    {
        public string Title { get; set; }
        public double ID { get; set; }
        public string Format { get; set; }
    }
    
}
