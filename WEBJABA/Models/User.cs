using Microsoft.AspNetCore.Identity;


namespace WEBJABA.Models
{
    public class User : IdentityUser
    {
        public int? PhotoId { get; set; }

        public string? Biography { get; set; }

        public int? InventoryId { get; set; }

        public virtual Inventory? Inventory { get; set; }


        public virtual Photo? Photo { get; set; }

    }
}
