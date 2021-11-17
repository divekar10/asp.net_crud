using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrud.Models
{
    [Table("productMaster")]
    public class productMaster
    {
        [Key]
        public int productID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        public int catID { get; set; }

        [Display(Name = "Category Name")]
        [NotMapped]
        public String Category { get; set; }
    }
}
