using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ifinfo.Shared
{
    [Table("Note")]
    public partial class Note
    {
        [Column(TypeName = "int")]
        public long EleveID { get; set; }
        [Column(TypeName = "int")]
        public long? EvaluationID { get; set; }
        [Key]
        [Column(TypeName = "int")]
        public long NoteID { get; set; }
        [Column(TypeName = "decimal")]
        public byte[] NoteValeur { get; set; }

        [ForeignKey(nameof(EleveID))]
        [InverseProperty("Notes")]
        public virtual Eleve Eleve { get; set; }
        [ForeignKey(nameof(EvaluationID))]
        [InverseProperty("Notes")]
        public virtual Evaluation Evaluation { get; set; }
    }
}
