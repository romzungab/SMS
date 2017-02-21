namespace SMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        StartDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PersonID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 15, unicode: false),
                        Credits = c.Int(),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15, unicode: false),
                        Budget = c.Decimal(precision: 10, scale: 2, storeType: "numeric"),
                        StartDate = c.DateTime(storeType: "date"),
                        Administrator = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.OnlineCourse",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        URL = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.OnsiteCourse",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Location = c.String(maxLength: 15, unicode: false),
                        Days = c.String(maxLength: 4, unicode: false),
                        Time = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.StudentGrade",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(),
                        StudentID = c.Int(),
                        Grade = c.Decimal(precision: 4, scale: 3, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .ForeignKey("dbo.Person", t => t.StudentID)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 20, unicode: false),
                        FirstName = c.String(maxLength: 20, unicode: false),
                        HireDate = c.DateTime(storeType: "date"),
                        EnrollmentDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 15, unicode: false),
                        Timestamp = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Person", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrade", "StudentID", "dbo.Person");
            DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Person");
            DropForeignKey("dbo.CourseInstructor", "PersonID", "dbo.Person");
            DropForeignKey("dbo.StudentGrade", "CourseID", "dbo.Course");
            DropForeignKey("dbo.OnsiteCourse", "CourseID", "dbo.Course");
            DropForeignKey("dbo.OnlineCourse", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
            DropIndex("dbo.StudentGrade", new[] { "StudentID" });
            DropIndex("dbo.StudentGrade", new[] { "CourseID" });
            DropIndex("dbo.OnsiteCourse", new[] { "CourseID" });
            DropIndex("dbo.OnlineCourse", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropIndex("dbo.CourseInstructor", new[] { "PersonID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Person");
            DropTable("dbo.StudentGrade");
            DropTable("dbo.OnsiteCourse");
            DropTable("dbo.OnlineCourse");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
            DropTable("dbo.CourseInstructor");
        }
    }
}
