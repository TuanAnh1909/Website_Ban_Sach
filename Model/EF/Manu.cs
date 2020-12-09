namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manu")]
    public partial class Manu
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public int? DisplayOder { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        public bool? status { get; set; }

        public int? TypeID { get; set; }
    }
}
