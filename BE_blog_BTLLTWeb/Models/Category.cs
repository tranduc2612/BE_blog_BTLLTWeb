using System;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? NameCategory { get; set; }

    public int? IdAdmin { get; set; }

    public string? Img { get; set; }

    public virtual AdminBlog? IdAdminNavigation { get; set; }

    public virtual ICollection<Blog> IdBlogs { get; } = new List<Blog>();
}
