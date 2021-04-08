using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WeCommerce.Data;

namespace WeCommerce.Models
{
    public class Product
    {
        private ApplicationDbContext context;
      
      

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(700, ErrorMessage = "El maximo de caracteres es 700")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El Titulo es requerido")]
        [MaxLength(50, ErrorMessage = "El maximo de caracteres es 50")]
        [Display(Name = "Titulo del producto")]
        public string Title { get; set; }

        [Display(Name = "Codigo del Producto")]
        [Required(ErrorMessage = "El codigo es requerido")]
        [MaxLength(20)]
        public string Code { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es requerido")]

        public decimal Price { get; set; }


        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        public int CategoryId { get; set; }

        public string ImageName { get; set; }
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        public int MarcaId { get; set; }




       
        //poner el nombre envez del id
        //public Category GetCategory()
        //{
        //    Category cat;

        //    using (var _context = new ApplicationDbContext())
        //    {
        //        cat = _context.Category.Where(c => c.Id == CategoryId).FirstOrDefault();

        //    }
        //    return cat;

        //}

    }
}