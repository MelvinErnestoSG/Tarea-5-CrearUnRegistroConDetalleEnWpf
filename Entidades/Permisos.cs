using System.ComponentModel.DataAnnotations;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades
{
    public class Permisos
    {
        [Key]
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
