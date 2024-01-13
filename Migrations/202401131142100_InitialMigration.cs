namespace schoolManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        CNE = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        Filiere = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CNE);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Etudiants");
            DropTable("dbo.Admins");
        }
    }
}
