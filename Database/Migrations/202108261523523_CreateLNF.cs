namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLNF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Title = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        IsFound = c.Boolean(nullable: false),
                        ItemCommandID = c.Int(nullable: false),
                        Finder_Username = c.String(maxLength: 128),
                        Owner_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Finder_Username)
                .ForeignKey("dbo.People", t => t.Owner_Username)
                .Index(t => t.Finder_Username)
                .Index(t => t.Owner_Username);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        BirthDate = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Owner_Username", "dbo.People");
            DropForeignKey("dbo.Items", "Finder_Username", "dbo.People");
            DropIndex("dbo.Items", new[] { "Owner_Username" });
            DropIndex("dbo.Items", new[] { "Finder_Username" });
            DropTable("dbo.People");
            DropTable("dbo.Items");
        }
    }
}
