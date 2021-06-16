using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ifinfo.Shared
{
    [Table("Classe")]
    public partial class Classe
    {
        public Classe()
        {
            Eleves = new HashSet<Eleve>();
            Evaluations = new HashSet<Evaluation>();
        }

        [Key]
        [Column(TypeName = "int")]
        public long ClasseID { get; set; }
        [Column(TypeName = "char(1)")]
        public string ClasseNom { get; set; }
        [Column(TypeName = "longtext")]
        public string ClasseNiveau { get; set; }

        [InverseProperty(nameof(Eleve.Classe))]
        public virtual ICollection<Eleve> Eleves { get; set; }
        [InverseProperty(nameof(Evaluation.Classe))]
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
