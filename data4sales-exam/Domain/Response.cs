namespace Domain
{
    public class Response
    {
        public int Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<Film> Results { get; set; }
    }
}
