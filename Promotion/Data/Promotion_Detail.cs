using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.Data
{
    public class Promotion_Detail
    {
        [Key]
        public string PromoID { get; set; }
        public string PromoType { get; set; }
        public int ValueType { get; set; }
        public string PromoDesc { get; set; }
        public DateTime DurationStart  { get; set; }
        public DateTime DurationEnd { get; set; }
        public string Item { get; set; }
        public string StoreString { get; set; }
        public string StoreName { get; set; }
    }

}
