namespace Domain
{
    public class Response
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Film> results { get; set; }
    }
}
