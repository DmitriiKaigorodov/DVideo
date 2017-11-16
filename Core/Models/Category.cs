using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVideo.Core.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> Subcategories { get; set; }
        public virtual ICollection<CategoryVideo> Videos { get; set; }

        public Category()
        {
            Subcategories = new Collection<Category>();
            Videos = new Collection<CategoryVideo>();
        }
    }
}