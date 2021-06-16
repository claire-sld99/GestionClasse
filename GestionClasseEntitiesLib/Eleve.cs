using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ifinfo.Shared
{
    [Table("Eleve")]
    public partial class Eleve
    {
        public Eleve()
        {
            Notes = new HashSet<Note>();
        }

        [Key]
        [Column(TypeName = "int")]
        public long EleveID { get; set; }
        [Column(TypeName = "int")]
        public long? ClasseID { get; set; }
        [Column(TypeName = "longtext")]
        public string EleveNom { get; set; }
        [Column(TypeName = "longtext")]
        public string ElevePrenom { get; set; }
        [Column(TypeName = "char(1)")]
        public string EleveSexe { get; set; }
        [Column(TypeName = "longtext")]
        public string EleveAdresse { get; set; }
        [Column(TypeName = "longtext")]
        public string EleveCodePostal { get; set; }
        [Column(TypeName = "longtext")]
        public string EleveVille { get; set; }
        [Column(TypeName = "longtext")]
        public string EleveTelephone { get; set; }

        [ForeignKey(nameof(ClasseID))]
        [InverseProperty("Eleves")]
        public virtual Classe Classe { get; set; }
        [InverseProperty(nameof(Note.Eleve))]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
