using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; } 
        public string Codigo { get; set; }
        public int? Estudiante_ci { get; set; }
        [ForeignKey(nameof(Estudiante_ci))]
        [JsonIgnore]
        public Estudiante? Estudiante { get; set; }
        public int? Colegio_id { get; set; }
        [ForeignKey(nameof(Colegio_id))]
        [JsonIgnore]
        public Colegio? Colegio { get; set; }
        public int? Curso_id { get; set; }
        [ForeignKey(nameof(Curso_id))]
        [JsonIgnore]
        public Curso? Curso { get; set; }
        public int? Usuario_id { get; set; }
        [ForeignKey(nameof(Usuario_id))]
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        public bool Estado { get; set; } = true;
    }
}
