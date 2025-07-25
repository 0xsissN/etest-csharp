using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Aptitud
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
