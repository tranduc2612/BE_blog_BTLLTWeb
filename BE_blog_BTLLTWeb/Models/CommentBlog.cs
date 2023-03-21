using System;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.Models;

public partial class CommentBlog
{
    public int IdComment { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public int? IdAccount { get; set; }

    public int? IdBlog { get; set; }

    public virtual Account? IdAccountNavigation { get; set; }

    public virtual Blog? IdBlogNavigation { get; set; }
}
