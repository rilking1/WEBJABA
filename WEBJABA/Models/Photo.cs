using System;
using System.Collections.Generic;

namespace WEBJABA.Models;

public partial class Photo
{
    public int Id { get; set; }

    public string? Photos { get; set; }

    public virtual ICollection<Skin> Skins { get; set; } = new List<Skin>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();


    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
