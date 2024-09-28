using System;
using System.Collections.Generic;

namespace WEBJABA.Models;

public partial class Skin
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? PhotoId { get; set; }

    public virtual ICollection<Inventory> Inventory { get; set; } = new List<Inventory>();


    public virtual Photo? Photo { get; set; }
}
