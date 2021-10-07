using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Øvelse_2.Models
{
    public class Kage
    { //Model class for tabellen kage
        public int Id { get; set; }
        public string CakeName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BestBefore { get; set; }
        public decimal Price { get; set; }
    }
}
