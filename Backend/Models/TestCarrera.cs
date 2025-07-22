using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class TestCarrera
    {
        [Key]
        public int Id { get; set; }
        public int? Test_id { get; set; }
        [ForeignKey(nameof(Test_id))]
        [JsonIgnore]
        public Test? Test { get; set; }
        public int? Carrera_id { get; set; }
        [ForeignKey(nameof(Carrera_id))]
        [JsonIgnore]
        public Carrera? Carrera { get; set; }
    }
}
