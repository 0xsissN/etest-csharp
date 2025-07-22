using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Ci { get; set; }  
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public DateOnly Fecha_Nacimiento { get; set; }
        public bool Estado { get; set; } = true;
    }
}

