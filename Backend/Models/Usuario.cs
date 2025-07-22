using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; } = "Admin";
    }
}
