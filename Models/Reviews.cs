namespace SpaFinal213.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }

        public User User { get; set; }
    }
}
