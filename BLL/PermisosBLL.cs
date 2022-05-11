using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.DAL;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.BLL
{
    public class PermisosBLL
    {
        public static List<Permisos> GetPermisos()
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Permisos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
