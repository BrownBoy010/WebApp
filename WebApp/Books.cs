using System.ComponentModel.DataAnnotations;

namespace WebApp
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        public string BookName { get; set; }
    }
}
