namespace SMSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OfficeAssignment")]
    public partial class OfficeAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorID { get; set; }

        [StringLength(15)]
        public string Location { get; set; }

        [StringLength(5)]
        public string Timestamp { get; set; }

        public virtual Person Person { get; set; }
    }
}
