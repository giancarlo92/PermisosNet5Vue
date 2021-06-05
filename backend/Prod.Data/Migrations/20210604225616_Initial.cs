using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prod.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPermiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPermiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPermisoId = table.Column<int>(type: "int", nullable: false),
                    FechaPermiso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permiso_TipoPermiso_TipoPermisoId",
                        column: x => x.TipoPermisoId,
                        principalTable: "TipoPermiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoPermiso",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Descripcion", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "gzevallos", new DateTime(2021, 6, 4, 17, 56, 15, 807, DateTimeKind.Local).AddTicks(965), "Enfermedad", null, null });

            migrationBuilder.InsertData(
                table: "TipoPermiso",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Descripcion", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 2, "gzevallos", new DateTime(2021, 6, 4, 17, 56, 15, 807, DateTimeKind.Local).AddTicks(1514), "Diligencias", null, null });

            migrationBuilder.InsertData(
                table: "TipoPermiso",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Descripcion", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 3, "gzevallos", new DateTime(2021, 6, 4, 17, 56, 15, 807, DateTimeKind.Local).AddTicks(1517), "Otros", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_TipoPermisoId",
                table: "Permiso",
                column: "TipoPermisoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "TipoPermiso");
        }
    }
}
