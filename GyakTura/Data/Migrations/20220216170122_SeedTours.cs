using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GyakTura.Data.Migrations
{
    public partial class SeedTours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Tours (UserId, Date, Destination, Km, Comment) VALUES " +
                "('5326487f-69b1-4ddd-aa3f-e6ce0b1afda6', '2016-02-01', 'Tata', 30, 'gyalogos'), " +
                "('5326487f-69b1-4ddd-aa3f-e6ce0b1afda6', '2016-04-11', 'Komárom', 50, 'kerékpáros')"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
