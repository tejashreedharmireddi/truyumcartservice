using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "FreeDelivery")]
        public Boolean FreeDelivery { get; set; }
        [Required]
        public Double Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }
        public Boolean Active { get; set; }
        public string CategoryName { get; set; }
        //public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }
    }
}
