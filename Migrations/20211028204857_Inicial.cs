using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    EsActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "RolesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false),
                    RolId = table.Column<int>(type: "INTEGER", nullable: false),
                    EsAsignado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesDetalle_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 1, "Permiso para ser administrador del sistema.", "Administrador" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 2, "Permiso para entrar como moderador al sistema.", "Moderador" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 3, "Permiso para entrar como usuario al sistema.", "Usuario" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 4, "Permiso para entrar como invitado del sistema.", "Invitado" });

            migrationBuilder.CreateIndex(
                name: "IX_RolesDetalle_RolId",
                table: "RolesDetalle",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "RolesDetalle");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
