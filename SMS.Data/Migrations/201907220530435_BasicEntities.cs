namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        RollNo = c.Int(nullable: false, identity: true),
                        StdName = c.String(),
                        FatherName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        ClassID_ClassID = c.Int(),
                        ID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RollNo)
                .ForeignKey("dbo.Classes", t => t.ClassID_ClassID)
                .ForeignKey("dbo.Teachers", t => t.ID_ID)
                .Index(t => t.ClassID_ClassID)
                .Index(t => t.ID_ID);
            
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
            DropForeignKey("dbo.Students", "ID_ID", "dbo.Teachers");
            DropForeignKey("dbo.Students", "ClassID_ClassID", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ID_ID" });
            DropIndex("dbo.Students", new[] { "ClassID_ClassID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
