using Tiffin.Data;
using Tiffin.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tiffin.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
       
        public ProductCategory ProductCategory { get; set; }

        
        public int CookId { get; set; }
        [ForeignKey("CookId")]
        public Cook Cook { get; set; }



    }
}
