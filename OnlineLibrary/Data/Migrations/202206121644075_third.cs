namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
