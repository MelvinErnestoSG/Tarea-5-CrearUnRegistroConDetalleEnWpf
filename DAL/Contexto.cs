using Microsoft.EntityFrameworkCore;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\GestionRoles.db");
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permisos>().HasData(new Permisos() 
            {
                PermisoId = 1,
                Nombre = "Administrador",
                Descripcion = "Permiso para ser administrador del sistema."
            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos() 
            {
                PermisoId = 2,
                Nombre = "Moderador",
                Descripcion = "Permiso para entrar como moderador al sistema."
            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos()
            {
                PermisoId = 3,
                Nombre = "Usuario",
                Descripcion = "Permiso para entrar como usuario al sistema."
            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos() 
            {
                PermisoId = 4,
                Nombre = "Invitado",
                Descripcion = "Permiso para entrar como invitado del sistema."
            });
        }
    }
}
