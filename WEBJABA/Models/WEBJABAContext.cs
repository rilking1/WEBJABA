using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;
using Microsoft.EntityFrameworkCore;
namespace WEBJABA.Models;

public partial class WEBJABAContext : IdentityDbContext<User>
{
    public WEBJABAContext()
    {
    }

    public WEBJABAContext(DbContextOptions<WEBJABAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Skin> Skins { get; set; }

    public virtual DbSet<Inventory> Inventorys { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }



}
