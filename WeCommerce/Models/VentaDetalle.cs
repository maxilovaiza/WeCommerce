using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WeCommerce.Data;

namespace WeCommerce.Models
{
    public class VentaDetalle
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }


        public int Quntity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public Product getProductos()
        {
            Product product;
            using (var context = new ApplicationDbContext())
            {
                product = context.Product.Where(p => p.Id == ProductId).FirstOrDefault();
            }
            return product;
        }

        public int VentaCabeceraId { get; set; }


    }
}
