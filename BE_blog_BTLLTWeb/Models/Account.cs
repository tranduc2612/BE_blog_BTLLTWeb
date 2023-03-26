using System;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.Models;

public partial class Account
{
    public int IdAccount { get; set; }

    public string UserName { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? Fullname { get; set; }

    public int? IdAdmin { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Avatar { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();

    public virtual ICollection<CommentBlog> CommentBlogs { get; } = new List<CommentBlog>();

    public virtual AdminBlog? IdAdminNavigation { get; set; }

    public virtual ICollection<LikeBlog> LikeBlogs { get; } = new List<LikeBlog>();
}
