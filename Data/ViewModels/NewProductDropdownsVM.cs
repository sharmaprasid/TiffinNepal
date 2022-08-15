using Tiffin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiffin.Models;

namespace Tiffin.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
          
            Cooks = new List<Cook>();
          
        }

       
        public List<Cook> Cooks { get; set; }
       
    }
}
