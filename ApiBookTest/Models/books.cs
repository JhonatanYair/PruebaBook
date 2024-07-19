using System;
using System.Collections.Generic;

namespace ApiBookTest.Models;

public partial class books
{
    public int id { get; set; }

    public string title { get; set; } = null!;

    public int? author_id { get; set; }

    public virtual authors? author { get; set; }
}
