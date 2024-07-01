using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", maxLength: 4, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", maxLength: 4, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USBPorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USB_2 = table.Column<int>(type: "int", maxLength: 3, nullable: true),
                    USB_3 = table.Column<int>(type: "int", maxLength: 3, nullable: true),
                    USB_C = table.Column<int>(type: "int", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USBPorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphicsCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PowerSupplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RAMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USBPortsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeightInGrams = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_GraphicsCards_GraphicsCardId",
                        column: x => x.GraphicsCardId,
                        principalTable: "GraphicsCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_PowerSupplies_PowerSupplyId",
                        column: x => x.PowerSupplyId,
                        principalTable: "PowerSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_RAM_RAMId",
                        column: x => x.RAMId,
                        principalTable: "RAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_USBPorts_USBPortsId",
                        column: x => x.USBPortsId,
                        principalTable: "USBPorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_GraphicsCardId",
                table: "Computers",
                column: "GraphicsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_Id",
                table: "Computers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PowerSupplyId",
                table: "Computers",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProcessorId",
                table: "Computers",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_RAMId",
                table: "Computers",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_StorageId",
                table: "Computers",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_USBPortsId",
                table: "Computers",
                column: "USBPortsId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicsCards_Id",
                table: "GraphicsCards",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_Id",
                table: "PowerSupplies",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processors_Id",
                table: "Processors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RAM_Id",
                table: "RAM",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Id",
                table: "Storage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USBPorts_Id",
                table: "USBPorts",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "GraphicsCards");

            migrationBuilder.DropTable(
                name: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "USBPorts");
        }
    }
}
