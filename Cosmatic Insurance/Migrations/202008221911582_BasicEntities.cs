namespace Cosmatic_Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        MobileNo = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        Detail = c.String(),
                        Status = c.Boolean(nullable: false),
                        PatientId = c.Int(nullable: false),
                        SurgeonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Surgeons", t => t.SurgeonId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.SurgeonId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        MobileNo = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surgeons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNo = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Specialization = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PolicyName = c.String(),
                        PolicyDescription = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EMI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolicyCompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "SurgeonId", "dbo.Surgeons");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "SurgeonId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Policies");
            DropTable("dbo.Surgeons");
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
            DropTable("dbo.Agents");
        }
    }
}
