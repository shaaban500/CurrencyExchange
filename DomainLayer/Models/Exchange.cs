using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Exchange : BaseEntity
    {
        public double Rate { get; set; }

        public DateTime ExchangeDate { get; set; }

        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }
    }
}
