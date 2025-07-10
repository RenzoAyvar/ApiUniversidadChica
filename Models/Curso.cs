using System.ComponentModel.DataAnnotations.Schema;

namespace appComercial.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Column("Curso")]
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int HorasSemanal { get; set; }
        public int Ciclo { get; set; }
        [ForeignKey("DocenteId")]
        public int DocenteId { get; set; }

        public Docente Docente { get; set; }
    }
}
