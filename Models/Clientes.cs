using System.ComponentModel.DataAnnotations;

namespace Conexion.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; }

        [Required]
        public bool Activo { get; set; }

    }
}
