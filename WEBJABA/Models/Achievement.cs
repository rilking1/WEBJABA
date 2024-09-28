using System;
using System.Collections.Generic;

namespace WEBJABA.Models;

public partial class Achievement
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? PhotoId { get; set; }

    public virtual Photo? Photo { get; set; }
}
