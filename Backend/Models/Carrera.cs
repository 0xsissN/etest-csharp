using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? Aptitud_id { get; set; }
        [ForeignKey(nameof(Aptitud_id))]
        [JsonIgnore]
        public Aptitud? Aptitud { get; set; }
    }
}
