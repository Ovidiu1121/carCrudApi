using FluentMigrator;

namespace CarCrudApi.Data.Migrations
{
    [Migration(17032024942)]
    public class TestMigrate:Migration
    {
        public override void Up()
        {
            Execute.Script(@"./Data/Scripts/data.sql");
        }
        public override void Down()
        {

        }

    }
}
