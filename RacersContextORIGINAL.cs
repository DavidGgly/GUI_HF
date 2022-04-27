// <copyright file="RacersContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Program.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// This class inherits from DbContext, so this is the main DB class.
    /// </summary>
    public partial class RacersContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RacersContext"/> class.
        /// </summary>
        public RacersContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RacersContext"/> class.
        /// </summary>
        /// <param name="options">options parameter.</param>
        public RacersContext(DbContextOptions<RacersContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets a DbSet generic type.
        /// </summary>
        public virtual DbSet<Race> Race { get; set; }

        /// <summary>
        /// Gets or sets a DbSet generic type.
        /// </summary>
        public virtual DbSet<Racer> Racer { get; set; }

        /// <summary>
        /// Gets or sets a DbSet generic type.
        /// </summary>
        public virtual DbSet<Racetrack> Racetrack { get; set; }

        /// <summary>
        /// Configuring the RacersDataBase.mdf database, using lazy loading.
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder parameter.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RacersDataBase.mdf;Integrated Security=True");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Race>(entity =>
                {
                    entity.Property(e => e.Id)
                        .HasColumnName("ID")
                        .HasColumnType("numeric(3, 0)");

                    entity.Property(e => e.Rtrack)
                        .HasColumnName("RTRACK")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.Property(e => e.Ryear)
                        .HasColumnName("RYEAR")
                        .HasColumnType("numeric(4, 0)");

                    entity.Property(e => e.Serie)
                        .HasColumnName("SERIE")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    entity.Property(e => e.Sumlaps)
                        .HasColumnName("SUMLAPS")
                        .HasColumnType("numeric(3, 0)");

                    entity.Property(e => e.Sumracers)
                        .HasColumnName("SUMRACERS")
                        .HasColumnType("numeric(2, 0)");

                    entity.Property(e => e.Winnerid)
                        .HasColumnName("WINNERID")
                        .HasColumnType("numeric(3, 0)");

                    entity.HasOne(d => d.Winner)
                        .WithMany(p => p.Race)
                        .HasForeignKey(d => d.Winnerid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("WINNER_FOREIGN");
                });

                modelBuilder.Entity<Racer>(entity =>
                {
                    entity.Property(e => e.Id)
                        .HasColumnName("ID")
                        .HasColumnType("numeric(3, 0)");

                    entity.Property(e => e.Age)
                        .HasColumnName("AGE")
                        .HasColumnType("numeric(2, 0)");

                    entity.Property(e => e.Nationality)
                        .HasColumnName("NATIONALITY")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    entity.Property(e => e.Rname)
                        .HasColumnName("RNAME")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    entity.Property(e => e.Rserie)
                        .HasColumnName("RSERIE")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    entity.Property(e => e.Sumwin)
                        .HasColumnName("SUMWIN")
                        .HasColumnType("numeric(3, 0)");
                });

                modelBuilder.Entity<Racetrack>(entity =>
                {
                    entity.Property(e => e.Id)
                        .HasColumnName("ID")
                        .HasColumnType("numeric(3, 0)");

                    entity.Property(e => e.Builtyear)
                        .HasColumnName("BUILTYEAR")
                        .HasColumnType("numeric(4, 0)");

                    entity.Property(e => e.Isf1)
                        .HasColumnName("ISF1")
                        .HasMaxLength(3)
                        .IsUnicode(false);

                    entity.Property(e => e.Tlength)
                        .HasColumnName("TLENGTH")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.Trackname)
                        .HasColumnName("TRACKNAME")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.Property(e => e.Tvenue)
                        .HasColumnName("TVENUE")
                        .HasMaxLength(30)
                        .IsUnicode(false);
                });
            }

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
