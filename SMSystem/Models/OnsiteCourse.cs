namespace SMSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OnsiteCourse")]
    public partial class OnsiteCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [StringLength(15)]
        public string Location { get; set; }

        [StringLength(4)]
        public string Days { get; set; }

        public TimeSpan? Time { get; set; }

        public virtual Course Course { get; set; }
    }
}
