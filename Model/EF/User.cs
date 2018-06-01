namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public bool Status { get; set; }
    }
}
