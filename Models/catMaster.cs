using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrud.Models
{
    [Table("catMaster")]
    public class catMaster
    {
        [Key]
        public int catID { get; set; }

        public String catName { get; set; }
    }
}
