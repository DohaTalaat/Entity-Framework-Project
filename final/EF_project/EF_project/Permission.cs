namespace EF_project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int perm_num { get; set; }

        [Column(TypeName = "date")]
        public DateTime? perm_date { get; set; }

        [StringLength(20)]
        public string num_Sup { get; set; }

        public int? ID_Cust { get; set; }

        [StringLength(20)]
        public string N_Ware { get; set; }

        public int? c_cate { get; set; }

        public virtual Category Category { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
