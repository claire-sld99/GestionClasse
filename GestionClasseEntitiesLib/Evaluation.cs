using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ifinfo.Shared
{
    [Table("Evaluation")]
    public partial class Evaluation
    {
        public Evaluation()
        {
            Notes = new HashSet<Note>();
        }

        [Column(TypeName = "int")]
        public long? ClasseID { get; set; }
        [Key]
        [Column(TypeName = "int")]
        public long EvaluationID { get; set; }
        [Column(TypeName = "int")]
        public long? ProfesseurID { get; set; }
        [Column(TypeName = "longtext")]
        public string EvaluationLibelle { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] EvaluationDate { get; set; }
        [Column(TypeName = "longtext")]
        public string EvaluationMatiere { get; set; }

        [ForeignKey(nameof(ClasseID))]
        [InverseProperty("Evaluations")]
        public virtual Classe Classe { get; set; }
        [ForeignKey(nameof(ProfesseurID))]
        [InverseProperty("Evaluations")]
        public virtual Professeur Professeur { get; set; }
        [InverseProperty(nameof(Note.Evaluation))]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
