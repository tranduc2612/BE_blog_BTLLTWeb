using System;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.Models;

public partial class LikeBlog
{
    public int IdAccount { get; set; }

    public int IdBlog { get; set; }

    public DateTime? LikeAt { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Blog IdBlogNavigation { get; set; } = null!;
}
