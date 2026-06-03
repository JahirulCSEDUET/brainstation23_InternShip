using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticeDay3.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillasAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillasAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillasAmenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Jahir Villa", 65324789.0 },
                    { 2, "Raza Villa", 732889.90000000002 }
                });

            migrationBuilder.InsertData(
                table: "VillasAmenities",
                columns: new[] { "Id", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "Velcony", 1 },
                    { 2, "Plambing Service", 2 },
                    { 3, "Private Pool", 2 },
                    { 4, "Pond", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillasAmenities_VillaId",
                table: "VillasAmenities",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillasAmenities");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
