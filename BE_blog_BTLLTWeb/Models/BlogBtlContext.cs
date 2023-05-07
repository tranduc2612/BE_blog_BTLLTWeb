using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BE_blog_BTLLTWeb.Models;

public partial class BlogBtlContext : DbContext
{
    public BlogBtlContext()
    {
    }

    public BlogBtlContext(DbContextOptions<BlogBtlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AdminBlog> AdminBlogs { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CommentBlog> CommentBlogs { get; set; }

    public virtual DbSet<LikeBlog> LikeBlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=Databaseblog.mssql.somee.com;packet size=4096;user id=tranminhduc2602_SQLLogin_2;pwd=yf2kz8shw2;data source=Databaseblog.mssql.somee.com;persist security info=False;initial catalog=Databaseblog;Encrypt=False;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PK__Account__DA18132CF7538B8F");

            entity.ToTable("Account");

            entity.Property(e => e.IdAccount).HasColumnName("idAccount");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Avatar).HasColumnType("ntext");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .HasColumnName("fullname");
            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.Pass)
                .HasMaxLength(200)
                .HasColumnName("pass");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .HasColumnName("userName");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("fk_Admin_Account");
        });

        modelBuilder.Entity<AdminBlog>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__AdminBlo__B2C3ADE5D4324D07");

            entity.ToTable("AdminBlog");

            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.AdminAccount)
                .HasMaxLength(200)
                .HasColumnName("adminAccount");
            entity.Property(e => e.AdminPass)
                .HasMaxLength(200)
                .HasColumnName("adminPass");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.IdBlog).HasName("PK__Blog__E5472CA88A434D52");

            entity.ToTable("Blog");

            entity.Property(e => e.IdBlog).HasColumnName("idBlog");
            entity.Property(e => e.AmountLike).HasColumnName("amountLike");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("date")
                .HasColumnName("createAt");
            entity.Property(e => e.IdAccount).HasColumnName("idAccount");
            entity.Property(e => e.ImageTitle).HasColumnType("ntext");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("fk_Blog_Account");

            entity.HasMany(d => d.IdCategories).WithMany(p => p.IdBlogs)
                .UsingEntity<Dictionary<string, object>>(
                    "DetailCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Category_DetailCategory"),
                    l => l.HasOne<Blog>().WithMany()
                        .HasForeignKey("IdBlog")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Blog_DetailCategory"),
                    j =>
                    {
                        j.HasKey("IdBlog", "IdCategory").HasName("PK__DetailCa__92DA1AB3B2E475D2");
                        j.ToTable("DetailCategory");
                        j.IndexerProperty<int>("IdBlog").HasColumnName("idBlog");
                        j.IndexerProperty<int>("IdCategory").HasColumnName("idCategory");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B662C49A0B");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.Img)
                .HasColumnType("ntext")
                .HasColumnName("img");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(100)
                .HasColumnName("nameCategory");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("fk_Admin_Category");
        });

        modelBuilder.Entity<CommentBlog>(entity =>
        {
            entity.HasKey(e => e.IdComment).HasName("PK__CommentB__0370297EEADE1A44");

            entity.ToTable("CommentBlog");

            entity.Property(e => e.IdComment).HasColumnName("idComment");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("date")
                .HasColumnName("createAt");
            entity.Property(e => e.IdAccount).HasColumnName("idAccount");
            entity.Property(e => e.IdBlog).HasColumnName("idBlog");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.CommentBlogs)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("fk_CommentBlog_Account");

            entity.HasOne(d => d.IdBlogNavigation).WithMany(p => p.CommentBlogs)
                .HasForeignKey(d => d.IdBlog)
                .HasConstraintName("fk_CommentBlog_Blog");
        });

        modelBuilder.Entity<LikeBlog>(entity =>
        {
            entity.HasKey(e => new { e.IdBlog, e.IdAccount }).HasName("PK__LikeBlog__38E6AD9A46E08D0F");

            entity.ToTable("LikeBlog");

            entity.Property(e => e.IdBlog).HasColumnName("idBlog");
            entity.Property(e => e.IdAccount).HasColumnName("idAccount");
            entity.Property(e => e.LikeAt)
                .HasColumnType("date")
                .HasColumnName("likeAt");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.LikeBlogs)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_LikeBlog_Account");

            entity.HasOne(d => d.IdBlogNavigation).WithMany(p => p.LikeBlogs)
                .HasForeignKey(d => d.IdBlog)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_LikeBlog_Blog");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
