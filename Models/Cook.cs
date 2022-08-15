using Tiffin.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tiffin.Models
{
    public class Cook:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cook Image")]
        [Required(ErrorMessage = "Cook Image is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Cook Name")]
        [Required(ErrorMessage = "Cookname is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cook description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Product> Products { get; set; }
    }
}
