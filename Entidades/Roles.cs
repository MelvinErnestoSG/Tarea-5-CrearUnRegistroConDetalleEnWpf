using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }

        [ForeignKey("RolId")]
        public List<RolesDetalle> Detalle { get; set; } = new List<RolesDetalle>();
    }
}
