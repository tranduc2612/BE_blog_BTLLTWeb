using System;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.Models;

public partial class AdminBlog
{
    public int IdAdmin { get; set; }

    public string? AdminAccount { get; set; }

    public string? AdminPass { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<Category> Categories { get; } = new List<Category>();
}
