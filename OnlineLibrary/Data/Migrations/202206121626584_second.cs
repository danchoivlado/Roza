namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "Birthday");
            DropColumn("dbo.Authors", "Death");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Death", c => c.DateTime());
            AddColumn("dbo.Authors", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
