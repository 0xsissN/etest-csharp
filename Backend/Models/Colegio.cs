using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Colegio
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
    }
}
