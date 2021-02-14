using BookShop.DL.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DL.Models
{
    public class Book
    {
        [Key]
        [Column("Id"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Name"), Required]
        public string Name { get; set; }
        [Column("Author"), Required]
        public string Author { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Price"), Required]
        public double Price { get; set; }
        [Column("Count"), Required]
        public int Count { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
