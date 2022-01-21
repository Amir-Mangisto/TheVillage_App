namespace TheVillage_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCitizenTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        Gender = c.String(),
                        BornInVillage = c.Boolean(nullable: false),
                        BirthDate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citizens");
        }
    }
}
