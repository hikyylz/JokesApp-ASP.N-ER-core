using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class BlogPost
    {
        [Key] // EFC db işlemlerini yaparken belli bir id değişkeni istiyordu bu key onun için.
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogAuthor { get; set; }

    }
}
