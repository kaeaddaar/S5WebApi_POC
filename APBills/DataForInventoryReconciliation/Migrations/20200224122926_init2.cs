using Microsoft.EntityFrameworkCore.Migrations;

namespace DataForInventoryReconciliation.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillCommentLines",
                columns: table => new
                {
                    BillCommentLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentLineIndex = table.Column<int>(nullable: false),
                    CommentLineData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCommentLines", x => x.BillCommentLineId);
                });

            migrationBuilder.CreateTable(
                name: "BillHeaders",
                columns: table => new
                {
                    BillHeaderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    PO = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Foreign = table.Column<string>(nullable: true),
                    Pay = table.Column<int>(nullable: false),
                    Supplier = table.Column<int>(nullable: false),
                    Total = table.Column<float>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    DueDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillHeaders", x => x.BillHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "BillLines",
                columns: table => new
                {
                    BillLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillUnique = table.Column<int>(nullable: true),
                    DataDate = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    CurrencyCode = table.Column<int>(nullable: false),
                    Supplier = table.Column<int>(nullable: false),
                    WholeCurrencyCode = table.Column<int>(nullable: false),
                    LedgerAccount = table.Column<string>(nullable: true),
                    LedgerAccountName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DbCd = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    CurrencyDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillLines", x => x.BillLineId);
                });

            migrationBuilder.CreateTable(
                name: "Payees",
                columns: table => new
                {
                    BillPayeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContextUnique = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Unique = table.Column<int>(nullable: false),
                    AName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StateName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Phone_1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payees", x => x.BillPayeeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    BillSupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContextUnique = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Unique = table.Column<int>(nullable: false),
                    AName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StateName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Phone_1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.BillSupplierId);
                });

            migrationBuilder.CreateTable(
                name: "APBills",
                columns: table => new
                {
                    APBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unique = table.Column<int>(nullable: false),
                    EnterTime = table.Column<float>(nullable: false),
                    EnterDate = table.Column<string>(nullable: true),
                    HeaderInfoBillHeaderId = table.Column<int>(nullable: true),
                    PayeeBillPayeeId = table.Column<int>(nullable: true),
                    SupplierBillSupplierId = table.Column<int>(nullable: true),
                    BillCommentLinesBillCommentLineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APBills", x => x.APBillId);
                    table.ForeignKey(
                        name: "FK_APBills_BillCommentLines_BillCommentLinesBillCommentLineId",
                        column: x => x.BillCommentLinesBillCommentLineId,
                        principalTable: "BillCommentLines",
                        principalColumn: "BillCommentLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APBills_BillHeaders_HeaderInfoBillHeaderId",
                        column: x => x.HeaderInfoBillHeaderId,
                        principalTable: "BillHeaders",
                        principalColumn: "BillHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APBills_Payees_PayeeBillPayeeId",
                        column: x => x.PayeeBillPayeeId,
                        principalTable: "Payees",
                        principalColumn: "BillPayeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APBills_Suppliers_SupplierBillSupplierId",
                        column: x => x.SupplierBillSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "BillSupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APBills_BillCommentLinesBillCommentLineId",
                table: "APBills",
                column: "BillCommentLinesBillCommentLineId");

            migrationBuilder.CreateIndex(
                name: "IX_APBills_HeaderInfoBillHeaderId",
                table: "APBills",
                column: "HeaderInfoBillHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_APBills_PayeeBillPayeeId",
                table: "APBills",
                column: "PayeeBillPayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_APBills_SupplierBillSupplierId",
                table: "APBills",
                column: "SupplierBillSupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APBills");

            migrationBuilder.DropTable(
                name: "BillLines");

            migrationBuilder.DropTable(
                name: "BillCommentLines");

            migrationBuilder.DropTable(
                name: "BillHeaders");

            migrationBuilder.DropTable(
                name: "Payees");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
