using System.ComponentModel.DataAnnotations;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PermisoId { get; set; }
        public int RolId { get; set; }
        public bool EsAsignado { get; set; }

        public RolesDetalle()
        {
            Id = 0;
            RolId = 0;
            PermisoId = 0;
            EsAsignado = true;
        }

        public RolesDetalle(int permisoId, int rolId, bool esAsignado)
        {
            Id = 0;
            PermisoId = permisoId;
            RolId = rolId;
            EsAsignado = esAsignado;
        }
    }
}
