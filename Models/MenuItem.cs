namespace TruYumCS_OrderFoodOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("MenuItems")]
    public partial class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Price { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfLaunch { get; set; }

        [Required]
        public string Type { get; set; }

        public bool FreeDelivery { get; set; }
    }
}
