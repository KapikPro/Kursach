using System.ComponentModel.DataAnnotations.Schema;

namespace example.Models
{
    public class Articles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Article { get; set; }

        public DateTime Date{ get; set; }

        public string AuthorIdId {  get; set; }

        public User AuthorId {  get; set; }

        public bool IsActive { get; set; }
    }
}
