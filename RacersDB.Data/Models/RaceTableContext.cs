// <copyright file="RaceTableContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Data.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// This class inherits from DbContext, so this is the main DB class.
    /// </summary>
    public partial class RaceTableContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RaceTableContext"/> class.
        /// </summary>
        public RaceTableContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceTableContext"/> class.
        /// </summary>
        /// <param name="options">Options parameter.</param>
        public RaceTableContext(DbContextOptions<RaceTableContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets a DbSet generic type.
        /// </summary>
        public virtual DbSet<Race> Races { get; set; }

        /// <summary>
        /// Gets or sets a DbSet generic type.
        /// </summary>
        public virtual DbSet<Racer> Racers { get; set; }

        /// <summary>
        /// Gets or sets a DbSet generic type.
        /// </summary>
        public virtual DbSet<Racetrack> Racetracks { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                    .UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\RaceTableDB.mdf; Integrated Security = True");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Race>(entity =>
                {
                    entity.ToTable("Race");

                    entity.Property(e => e.Id)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("ID");

                    entity.Property(e => e.Rtrack)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("RTRACK");

                    entity.Property(e => e.Ryear)
                        .HasColumnType("numeric(4, 0)")
                        .HasColumnName("RYEAR");

                    entity.Property(e => e.Serie)
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("SERIE");

                    entity.Property(e => e.Sumlaps)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("SUMLAPS");

                    entity.Property(e => e.Sumracers)
                        .HasColumnType("numeric(2, 0)")
                        .HasColumnName("SUMRACERS");

                    entity.Property(e => e.Winnerid)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("WINNERID");

                    entity.HasOne(d => d.RtrackNavigation)
                        .WithMany(p => p.Races)
                        .HasForeignKey(d => d.Rtrack)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("RTRACK_FOREIGN");

                    entity.HasOne(d => d.Winner)
                        .WithMany(p => p.Races)
                        .HasForeignKey(d => d.Winnerid)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("WINNER_FOREIGN");
                });

                modelBuilder.Entity<Racer>(entity =>
                {
                    entity.ToTable("Racer");

                    entity.Property(e => e.Id)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("ID");

                    entity.Property(e => e.Age)
                        .HasColumnType("numeric(2, 0)")
                        .HasColumnName("AGE");

                    entity.Property(e => e.Nationality)
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnName("NATIONALITY");

                    entity.Property(e => e.Rname)
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnName("RNAME");

                    entity.Property(e => e.Rserie)
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("RSERIE");

                    entity.Property(e => e.Sumwin)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("SUMWIN");
                });

                modelBuilder.Entity<Racetrack>(entity =>
                {
                    entity.ToTable("Racetrack");

                    entity.Property(e => e.Id)
                        .HasColumnType("numeric(3, 0)")
                        .HasColumnName("ID");

                    entity.Property(e => e.Builtyear)
                        .HasColumnType("numeric(4, 0)")
                        .HasColumnName("BUILTYEAR");

                    entity.Property(e => e.Isf1)
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnName("ISF1");

                    entity.Property(e => e.Tlength)
                        .HasColumnType("numeric(5, 0)")
                        .HasColumnName("TLENGTH");

                    entity.Property(e => e.Trackname)
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnName("TRACKNAME");

                    entity.Property(e => e.Tvenue)
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnName("TVENUE");
                });

                this.OnModelCreatingPartial(modelBuilder);
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
