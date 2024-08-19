using System;
using System.Collections.Generic;

namespace library.Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? PublishedYear { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
