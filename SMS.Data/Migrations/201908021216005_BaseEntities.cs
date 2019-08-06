namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        RollNo = c.Int(nullable: false, identity: true),
                        StdName = c.String(),
                        FatherName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        ClassID = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.RollNo)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassID", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
