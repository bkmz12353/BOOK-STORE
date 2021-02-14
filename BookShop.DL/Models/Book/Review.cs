using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DL.Models
{
   public class Review
    {
        [Key]
        [Column("Id"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Title"), Required]
        [MaxLength(20), MinLength(4)]
        public string Title { get; set; }
        [Column("Content"), Required]
        [MaxLength(250)]
        public string Content { get; set; }
        [Column("ReviewRating"), Required]
        [Range(0, 10)]
        public int ReviewRating { get; set; }
        [Column("PublicationDate"), Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PublicstionDate { get; set; }
        [ForeignKey(nameof(Owner)), Required]
        public string ReviewOwner { get; set; }
        public virtual IdentityUser Owner { get; set; }
        [ForeignKey(nameof(Book)), Required]
        public int ReviewBookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
