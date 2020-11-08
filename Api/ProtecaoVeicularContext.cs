using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api
{
    public partial class ProtecaoVeicularContext : DbContext
    {
        public ProtecaoVeicularContext()
        {
        }

        public ProtecaoVeicularContext(DbContextOptions<ProtecaoVeicularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Associados> Associados { get; set; }
        public virtual DbSet<Veiculos> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
////To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=SQNOT407\\SQLEXPRESS;Initial Catalog=ProtecaoVeicular;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associados>(entity =>
            {
                entity.ToTable("TB_Associado");

                entity.Property(e => e.DataNasc)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.NomeAssociado)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.TelefoneCel)
                    .HasMaxLength(13)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Veiculos>(entity =>
            {
                entity.ToTable("TB_Veiculo");

                entity.Property(e => e.Ano)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Chassi)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Marca)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Modelo)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
