using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ifinfo.Shared
{
    [Table("Professeur")]
    public partial class Professeur
    {
        public Professeur()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        [Key]
        [Column(TypeName = "int")]
        public long ProfesseurID { get; set; }
        [Column(TypeName = "longtext")]
        public string ProfesseurNom { get; set; }
        [Column(TypeName = "longtext")]
        public string ProfesseurPrenom { get; set; }

        [InverseProperty(nameof(Evaluation.Professeur))]
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
