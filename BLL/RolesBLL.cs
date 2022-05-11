using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.DAL;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.BLL
{
    public class RolesBLL
    {
       public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            
            }
            return encontrado;
        }

        public static bool Guardar(Roles rol)//Guardar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea guardar al contexto
                if(contexto.Roles.Add(rol) != null)
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Roles rol)//Modificar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM RolesDetalle Where RolId = {rol.RolId}");

                foreach (var anterior in rol.Detalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }

                contexto.Entry(rol).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)

            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)//Eliminar
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Roles.Find(id);
                    contexto.Entry(eliminar).State = EntityState.Deleted;
                    paso = (contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Roles Buscar(int id)//Buscar
        {
            var contexto = new Contexto();
            var rol = new Roles();
            
            try
            {
                rol = contexto.Roles.Include(x => x.Detalle)
                    .Where(p => p.RolId == id)
                    .SingleOrDefault();    
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return rol;
        }

        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)//Listar
        {
            List<Roles> lista = new List<Roles>();
            Contexto contexto = new Contexto();

            try
            {
                //Obtenemos la lista y la filtramos segun el criterio recibido por parametro.
                lista = contexto.Roles.Where(criterio).ToList();
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
