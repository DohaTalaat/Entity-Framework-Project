namespace EF_project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Has")]
    public partial class Has
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string name { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime time_input_storage { get; set; }

        public int? Quantity_of_Category { get; set; }

        public virtual Category Category { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
