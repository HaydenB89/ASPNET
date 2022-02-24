using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMvc.Models {
    public class OrderLine {

        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Product { get; set; }
        public int Qty { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(13,2)")]
        public decimal LineTotal { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
