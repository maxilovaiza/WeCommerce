using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeCommerce.Models
{
    public class ComboMarca
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
