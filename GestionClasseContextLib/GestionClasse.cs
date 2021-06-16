using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ifinfo.Shared
{
    public partial class GestionClasse : DbContext
    {
        public GestionClasse()
        {
        }

        public GestionClasse(DbContextOptions<GestionClasse> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Eleve> Eleves { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Professeur> Professeurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Filename=../GestionClasse.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classe>(entity =>
            {
                entity.Property(e => e.ClasseID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Eleve>(entity =>
            {
                entity.Property(e => e.EleveID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.Property(e => e.EvaluationID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteID).ValueGeneratedNever();

                entity.HasOne(d => d.Eleve)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.EleveID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Professeur>(entity =>
            {
                entity.Property(e => e.ProfesseurID).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
