namespace SMSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OnlineCourse")]
    public partial class OnlineCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        public virtual Course Course { get; set; }
    }
}
