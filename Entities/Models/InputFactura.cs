using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class InputFactura
    {
        public int Id { get; set; }

        [Display(Name = "Factura Number")]
        public string FacturaNumber { get; set; }
        
        public string FirmName { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Status of Factura")]
        public bool Satus { get; set; }

      
    }
}
