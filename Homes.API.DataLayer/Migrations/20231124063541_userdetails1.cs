using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeMgmtAPI.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class userdetails1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Home_HomeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Home_HomeId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Home",
                table: "Home");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Home",
                newName: "Homes");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Room_HomeId",
                table: "Rooms",
                newName: "IX_Rooms_HomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_HomeId",
                table: "Addresses",
                newName: "IX_Addresses_HomeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homes",
                table: "Homes",
                column: "HomeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Homes_HomeId",
                table: "Addresses",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Homes_HomeId",
                table: "Rooms",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Homes_HomeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Homes_HomeId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homes",
                table: "Homes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Homes",
                newName: "Home");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HomeId",
                table: "Room",
                newName: "IX_Room_HomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_HomeId",
                table: "Address",
                newName: "IX_Address_HomeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Home",
                table: "Home",
                column: "HomeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Home_HomeId",
                table: "Address",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Home_HomeId",
                table: "Room",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
