using System.ComponentModel.DataAnnotations.Schema;

namespace example.Models.Entities
{
    public class Articles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Article { get; set; }

        public DateTime Date { get; set; }

        public User Author { get; set; }

        public bool IsActive { get; set; }
    }
}
