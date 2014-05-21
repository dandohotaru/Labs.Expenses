using System.Data.Entity.Migrations;

namespace Labs.Expenses.W.Data.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "expenses.Expense",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    PolicyId = c.Guid(nullable: false),
                    MerchantId = c.Guid(nullable: false),
                    Date = c.DateTimeOffset(nullable: false, precision: 7),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Vat = c.Decimal(precision: 18, scale: 2),
                    TenantId = c.Guid(nullable: false),
                    Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("expenses.Merchant", t => t.MerchantId, cascadeDelete: true)
                .Index(t => t.MerchantId);

            CreateTable(
                "expenses.Merchant",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    TenantId = c.Guid(nullable: false),
                    Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "expenses.Tag",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    TenantId = c.Guid(nullable: false),
                    Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "expenses.Policy",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    TenantId = c.Guid(nullable: false),
                    Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "expenses.ExpenseTag",
                c => new
                {
                    ExpenseId = c.Guid(nullable: false),
                    TagId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new {t.ExpenseId, t.TagId})
                .ForeignKey("expenses.Expense", t => t.ExpenseId, cascadeDelete: true)
                .ForeignKey("expenses.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ExpenseId)
                .Index(t => t.TagId);
        }

        public override void Down()
        {
            DropForeignKey("expenses.ExpenseTag", "TagId", "expenses.Tag");
            DropForeignKey("expenses.ExpenseTag", "ExpenseId", "expenses.Expense");
            DropForeignKey("expenses.Expense", "MerchantId", "expenses.Merchant");
            DropIndex("expenses.ExpenseTag", new[] {"TagId"});
            DropIndex("expenses.ExpenseTag", new[] {"ExpenseId"});
            DropIndex("expenses.Expense", new[] {"MerchantId"});
            DropTable("expenses.ExpenseTag");
            DropTable("expenses.Policy");
            DropTable("expenses.Tag");
            DropTable("expenses.Merchant");
            DropTable("expenses.Expense");
        }
    }
}