namespace SMSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseInstructor")]
    public partial class CourseInstructor
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Person Person { get; set; }
    }
}
