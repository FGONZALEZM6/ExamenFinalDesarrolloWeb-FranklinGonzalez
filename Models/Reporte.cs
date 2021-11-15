namespace FinalFranklinGonzalez.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reporte")]
    public partial class Reporte
    {
        [Key]
        public int Idreporte { get; set; }

        [Required]
        [StringLength(50)]
        public string List_activo { get; set; }

        [Required]
        [StringLength(50)]
        public string List_aprobados { get; set; }

        [Required]
        [StringLength(50)]
        public string List_reprobado { get; set; }
    }
}
