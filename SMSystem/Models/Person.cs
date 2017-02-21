namespace SMSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            CourseInstructors = new HashSet<CourseInstructor>();
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int PersonID { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EnrollmentDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
