using System.Data.Entity.Migrations;

namespace Labs.Expenses.W.Data.Migrations
{
    public partial class TuningTheModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("expenses.Expense", "Vat", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("expenses.Expense", "Vat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}