using System;
using System.Collections.Generic;

namespace BlogPostPage.Models
{
    public partial class Post
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? DatePost { get; set; }
    }
}
