using System.ComponentModel.DataAnnotations.Schema;

namespace appComercial.Models
{
   public class Curso
{
    public int Id { get; set; }
    [Column("Curso")]
    public required string Nombre { get; set; }  // Nombre del curso
    public int Creditos { get; set; }
    public int HorasSemanal { get; set; }
    public int Ciclo { get; set; }

    public int DocenteId { get; set; }
    public Docente Docente { get; set; }  // Propiedad de navegación
}
}
