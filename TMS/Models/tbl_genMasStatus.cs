namespace TMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_genMasStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_genMasStatus()
        {
            tbl_pmsTxTask = new HashSet<tbl_pmsTxTask>();
        }

        [Key]
        [StringLength(20)]
        [DisplayName("Status Code")]
        public string status_ID { get; set; }

        [StringLength(200)]
        [DisplayName("Status")]
        public string status { get; set; }

        public bool? isActive { get; set; }

        [StringLength(20)]
        public string createUser_ID { get; set; }

        [StringLength(20)]
        public string modifiedUser_ID { get; set; }

        [StringLength(20)]
        public string deletedUser_ID { get; set; }

        public DateTime? dateCreated { get; set; }

        public DateTime? dateModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }
    }
}
