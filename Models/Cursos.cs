namespace FinalFranklinGonzalez.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cursos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreCurso { get; set; }
    }
}
