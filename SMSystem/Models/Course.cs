namespace SMSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseInstructors = new HashSet<CourseInstructor>();
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int CourseID { get; set; }

        [StringLength(15)]
        public string Title { get; set; }

        public int? Credits { get; set; }

        public int? DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        public virtual OnlineCourse OnlineCourse { get; set; }

        public virtual OnsiteCourse OnsiteCourse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
