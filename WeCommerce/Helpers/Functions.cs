
using Microsoft.AspNetCore.Mvc.Rendering;
using WeCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCommerce.Helpers
{
    public static class Functions
    {
        public static SelectList GetCategorys()
        {
            var dbContext = new ApplicationDbContext();
            var lstCategory = dbContext.Category.ToList();
            var SelectList = new SelectList(lstCategory, "Id", "Description");
            return SelectList;


        }



    }
}