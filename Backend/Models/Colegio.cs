using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Colegio
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; } = true;
    }
}
