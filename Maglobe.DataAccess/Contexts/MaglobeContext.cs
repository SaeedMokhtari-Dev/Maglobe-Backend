using System;
using System.Threading.Tasks;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Maglobe.DataAccess.Contexts
{
    public partial class MaglobeContext : DbContext
    {
        private readonly string _connectionString;
        
        public MaglobeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MaglobeContext(DbContextOptions<MaglobeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<CustomerSupportRequest> CustomerSupportRequests { get; set; }
        public virtual DbSet<DynamicPage> DynamicPages { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttachment> ProductAttachments { get; set; }
        public virtual DbSet<ProductCertificate> ProductCertificates { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public async Task ExecuteTransactionAsync(Func<Task> action)
        {
            await Database.BeginTransactionAsync();

            await action();

            try
            {
                await Database.CurrentTransaction.CommitAsync();
            }
            catch
            {
                await Database.CurrentTransaction.RollbackAsync();

                throw;
            }
        }

        public async Task<T> ExecuteTransactionAsync<T>(Func<Task<T>> action)
        {
            await Database.BeginTransactionAsync();

            var result = await action();

            try
            {
                await Database.CurrentTransaction.CommitAsync();
            }
            catch
            {
                await Database.CurrentTransaction.RollbackAsync();

                throw;
            }

            return result;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.ToTable("Agency");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(50);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Image).IsRequired();
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.HasIndex(e => e.IsActive, "IX_Blog_IsActive");

                entity.HasIndex(e => e.Language, "IX_Blog_Language");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_Blog_Attachment");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_Certificate_Attachment");
            });

            modelBuilder.Entity<CustomerSupportRequest>(entity =>
            {
                entity.ToTable("CustomerSupportRequest");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DynamicPage>(entity =>
            {
                entity.ToTable("DynamicPage");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Editor).IsRequired();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.HasIndex(e => e.IsActive, "IX_Menu_IsActive");

                entity.HasIndex(e => e.Language, "IX_Menu_Language");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<PasswordResetToken>(entity =>
            {
                entity.ToTable("PasswordResetToken");

                entity.HasIndex(e => new { e.UserId, e.Token }, "IX_PasswordResetToken_UserId_Token")
                    .IsUnique();

                entity.Property(e => e.ResetRequestDate).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                /*entity.HasOne(d => d.User)
                    .WithMany(p => p.PasswordResetTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PasswordResetToken_Users");*/
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.IsActive, "IX_Product_IsActive");

                entity.HasIndex(e => e.Language, "IX_Product_Language");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.OilType).HasMaxLength(50);

                entity.Property(e => e.Quality).HasMaxLength(50);

                entity.Property(e => e.Volume).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductAttachment>(entity =>
            {
                entity.ToTable("ProductAttachment");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.ProductAttachments)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_ProductAttachment_Attachment");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttachments)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductAttachment_Product");
            });

            modelBuilder.Entity<ProductCertificate>(entity =>
            {
                entity.ToTable("ProductCertificate");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.ProductCertificates)
                    .HasForeignKey(d => d.CertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCertificate_Certificate");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCertificates)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductCertificate_Product");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.HasIndex(e => e.Token, "IX_RefreshToken_Token")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpiresAt).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_Users");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WebsiteTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.WebsiteLogo)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.WebsiteLogoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Setting_Attachment");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("Testimonial");

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Job).HasMaxLength(100);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SocialNetwork).HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.TestimonialAttachments)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_Testimonial_Attachment");

                entity.HasOne(d => d.SmallPicture)
                    .WithMany(p => p.TestimonialSmallPictures)
                    .HasForeignKey(d => d.SmallPictureId)
                    .HasConstraintName("FK_Testimonial_SmallPictureId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.IsActive, "IX_User_IsActive");

                entity.HasIndex(e => e.Username, "IX_User_Username")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastLoginAt).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
