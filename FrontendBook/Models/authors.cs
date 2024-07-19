using System;
using System.Collections.Generic;

namespace FrontendBook.Models;

public partial class authors
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<books> books { get; set; } = new List<books>();
}
