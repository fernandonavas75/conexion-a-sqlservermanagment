using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion.Models
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        [StringLength(10)]  // Aquí puedes ajustar la longitud según tus necesidades
        public string Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(255)]
        public string Imagen { get; set; }
    }
}
