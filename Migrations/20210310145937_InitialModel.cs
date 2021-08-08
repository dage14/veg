using Microsoft.EntityFrameworkCore.Migrations;

namespace veg.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make3')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make1-ModelA','1')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make1-ModelB','1')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make1-ModelC','1')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make2-ModelA','2')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make2-ModelB','2')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make2-ModelC','2')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make3-ModelA','3')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make3-ModelB','3')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES('Make3-ModelC','3')");

            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature1')");
            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature2')");
            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature3')");
            migrationBuilder.Sql("INSERT INTO Features (Name) Values ('Feature4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
