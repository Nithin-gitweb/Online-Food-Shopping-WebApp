namespace TruYumCS_OrderFoodOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool FreeDelivery { get; set; }

        public double Price { get; set; }
    }
}
