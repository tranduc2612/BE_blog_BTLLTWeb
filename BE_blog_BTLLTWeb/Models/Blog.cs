using System;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.Models;

public partial class Blog
{
    public int IdBlog { get; set; }

    public string Title { get; set; } = null!;

    public int? Status { get; set; }

    public DateTime CreateAt { get; set; }

    public string Content { get; set; } = null!;

    public int? AmountLike { get; set; }

    public int? IsDelete { get; set; }

    public int? IdAccount { get; set; }

    public string? ImageTitle { get; set; }

    public virtual ICollection<CommentBlog> CommentBlogs { get; } = new List<CommentBlog>();

    public virtual Account? IdAccountNavigation { get; set; }

    public virtual ICollection<Account> IdAccounts { get; } = new List<Account>();

    public virtual ICollection<Category> IdCategories { get; } = new List<Category>();
}
