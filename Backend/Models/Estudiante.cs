using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Ci { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public bool Estado { get; set; } = true;
    }
}

