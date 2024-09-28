using System;
using System.Collections.Generic;

namespace WEBJABA.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public int? Skinid { get; set; }

    public int? PhotoId { get; set; }


    public virtual Skin? Skin { get; set; }


    public virtual Photo? Photo { get; set; }
}
