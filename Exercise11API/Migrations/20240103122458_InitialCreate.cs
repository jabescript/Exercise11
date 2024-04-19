using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise11API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SummaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarSpace = table.Column<int>(type: "int", nullable: false),
                    NumberOfBedroom = table.Column<int>(type: "int", nullable: false),
                    NumberOfBathroom = table.Column<int>(type: "int", nullable: false),
                    FloorArea = table.Column<int>(type: "int", nullable: false),
                    LandSize = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPropertyOfTheWeek = table.Column<bool>(type: "bit", nullable: false),
                    PropertyCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
