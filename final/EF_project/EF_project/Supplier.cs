namespace EF_project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Permissions = new HashSet<Permission>();
        }

        [Key]
        [StringLength(20)]
        public string Name { get; set; }

        public int? Phone { get; set; }

        [StringLength(15)]
        public string Mail { get; set; }

        public int? Work { get; set; }

        [StringLength(15)]
        public string E_mail { get; set; }

        public int? Fax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
