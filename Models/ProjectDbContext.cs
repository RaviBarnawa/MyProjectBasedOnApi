using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }
        public virtual DbSet<CommentTbl> CommentTbls { get; set; }
        public virtual DbSet<LikeTbl> LikeTbls { get; set; }
        public virtual DbSet<Mergeing> Mergeings { get; set; }
        public virtual DbSet<PostTbl> PostTbls { get; set; }
        public virtual DbSet<UserTbl> UserTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryTbl>(entity =>
            {
                entity.ToTable("CategoryTbl");

                entity.Property(e => e.Category).HasMaxLength(50);
            });

            modelBuilder.Entity<CommentTbl>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("CommentTbl");

                entity.Property(e => e.CommentDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.CommentTbls)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_CommentTbl_PostTbl");
            });

            modelBuilder.Entity<LikeTbl>(entity =>
            {
                entity.HasKey(e => e.LikeId);

                entity.ToTable("LikeTbl");

                entity.Property(e => e.LikeId).HasColumnName("LikeID");

                entity.Property(e => e.DateOfLike).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikeTbls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikeTbl_UserTbl");
            });

            modelBuilder.Entity<Mergeing>(entity =>
            {
                entity.ToTable("Mergeing");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Mergeings)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Mergeing_CategoryTbl");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Mergeings)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Mergeing_CommentTbl");

                entity.HasOne(d => d.Like)
                    .WithMany(p => p.Mergeings)
                    .HasForeignKey(d => d.LikeId)
                    .HasConstraintName("FK_Mergeing_LikeTbl");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Mergeings)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Mergeing_PostTbl");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mergeings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Mergeing_UserTbl");
            });

            modelBuilder.Entity<PostTbl>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("PostTbl");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.PostTbls)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostTbl_CategoryTbl");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.ToTable("UserTbl");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
