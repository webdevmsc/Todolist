using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class ModelBase
    {
        [Key]
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}