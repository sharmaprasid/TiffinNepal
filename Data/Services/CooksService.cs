using Tiffin.Data.Base;
using Tiffin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiffin.Data.Services
{
    public class CooksService:EntityBaseRepository<Cook>, ICooksService
    {
        public CooksService(AppDbContext context) : base(context)
        {
        }
    }
}
