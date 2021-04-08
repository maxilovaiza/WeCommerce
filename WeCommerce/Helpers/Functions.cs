
using Microsoft.AspNetCore.Mvc.Rendering;
using WeCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCommerce.Models;

namespace WeCommerce.Helpers
{
    public static class Functions
    {
        public static SelectList GetCategorys(bool  IncluyeTodas=false)
        {
            var dbContext = new ApplicationDbContext();
            var lstCategory = dbContext.Category.ToList();

            if (IncluyeTodas)
            {
                var categoryAll = new Category();
                categoryAll.Id = 0;
                categoryAll.Description = "Todas";
                lstCategory.Insert(0, categoryAll);
            }
            var SelectList = new SelectList(lstCategory, "Id", "Description");
            return SelectList;


        }


        public static SelectList GetMarca(bool IncluyeTodas = false)
        {
            var dbContext = new ApplicationDbContext();
            var ltsMarca = dbContext.Marca.ToList();
            if (IncluyeTodas)
            {
                var marcasAll = new Marca();
                marcasAll.Id = 0;
                marcasAll.Description = "Todas";
                ltsMarca.Insert(0, marcasAll);
            }
            var SelectList = new SelectList(ltsMarca, "Id", "Description");
            return SelectList;


        }


    }
}