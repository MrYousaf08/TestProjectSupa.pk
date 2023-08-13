using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkConfigurations",
                columns: table => new
                {
                    NetworkLabelName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Networkcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkConfigurations", x => x.NetworkLabelName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkConfigurations");
        }
    }
}
