using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProducts.Domains
{
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string? Name { get; set; }

        [Column(TypeName = "Decimal")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public decimal Price { get; set; }
    }
}
