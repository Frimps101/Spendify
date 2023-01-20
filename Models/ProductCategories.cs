using System.ComponentModel.DataAnnotations;

namespace Spendify.Models
{
    public class ProductCategories
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Product Category")]
        public string ProductCategory { get; set; }
    }
}
