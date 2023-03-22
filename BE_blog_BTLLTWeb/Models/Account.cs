using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace BE_blog_BTLLTWeb.Models;

public partial class Account
{
    public int IdAccount { get; set; }
    [Required(ErrorMessage = "Please enter this field !")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter this field !")]
	//[RegularExpression(@"/[a-z][A-Z][0-9][!@#$%^&*]/g",
	//	 ErrorMessage = "Characters are not allowed.")]
    public string Pass { get; set; } = null!;

    public string? Fullname { get; set; }

    public int? IdAdmin { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Avatar { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();

    public virtual ICollection<CommentBlog> CommentBlogs { get; } = new List<CommentBlog>();

    public virtual AdminBlog? IdAdminNavigation { get; set; }

    public virtual ICollection<Blog> IdBlogs { get; } = new List<Blog>();
}
