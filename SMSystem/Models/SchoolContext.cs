namespace SMSystem
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolDatabase : DbContext
    {
        public SchoolDatabase()
            : base("name=SchoolDatabase")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; }
        public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<StudentGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.CourseInstructors)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Course>()
                .HasOptional(e => e.OnlineCourse)
                .WithRequired(e => e.Course);

            modelBuilder.Entity<Course>()
                .HasOptional(e => e.OnsiteCourse)
                .WithRequired(e => e.Course);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Budget)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OfficeAssignment>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<OfficeAssignment>()
                .Property(e => e.Timestamp)
                .IsUnicode(false);

            modelBuilder.Entity<OnlineCourse>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<OnsiteCourse>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<OnsiteCourse>()
                .Property(e => e.Days)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.CourseInstructors)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.OfficeAssignment)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StudentGrades)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<StudentGrade>()
                .Property(e => e.Grade)
                .HasPrecision(4, 3);
        }
    }
}
