using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CornerstonePRSPractice.Models {
    public class PO {

        public Vendor Vendor { get; set; }
        public IEnumerable<PoLine> PoLines { get; set; }
        public decimal PoTotal { get; set; }

    }
}
