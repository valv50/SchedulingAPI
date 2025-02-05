using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedulingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TypeName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    MarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MarketName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.MarketId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Company_CompanyType",
                        column: x => x.TypeId,
                        principalTable: "CompanyType",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_Company_Market",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "MarketId");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Market",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "MarketId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDate",
                columns: table => new
                {
                    ScheduleDateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDate", x => x.ScheduleDateId);
                    table.ForeignKey(
                        name: "FK_ScheduleDate_Schedule",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleType",
                columns: table => new
                {
                    ScheduleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleType", x => x.ScheduleTypeId);
                    table.ForeignKey(
                        name: "FK_ScheduleType_CompanyType",
                        column: x => x.TypeId,
                        principalTable: "CompanyType",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_ScheduleType_Schedule",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_MarketId",
                table: "Company",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_TypeId",
                table: "Company",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_MarketId",
                table: "Schedule",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDate_ScheduleId",
                table: "ScheduleDate",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleType",
                table: "ScheduleType",
                columns: new[] { "ScheduleId", "TypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleType_TypeId",
                table: "ScheduleType",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ScheduleDate");

            migrationBuilder.DropTable(
                name: "ScheduleType");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Market");
        }
    }
}
