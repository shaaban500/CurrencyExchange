using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos
{
    public class MaxRatesDto
    {
        public int maxRate { get; set; }

        public Currency currency { get; set; }
    }
}
