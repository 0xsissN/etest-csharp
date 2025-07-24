using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Ci { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido_Paterno { get; set; } = string.Empty;
        public string Apellido_Materno { get; set; } = string.Empty;
        public DateOnly Fecha_Nacimiento { get; set; }
        public bool Estado { get; set; } = true;
    }
}

