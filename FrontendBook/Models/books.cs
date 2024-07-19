using System;
using System.Collections.Generic;

namespace FrontendBook.Models;

public partial class books
{
    public int id { get; set; }

    public string title { get; set; } = null!;

    public int? author_id { get; set; }

    public virtual authors? author { get; set; }
}
