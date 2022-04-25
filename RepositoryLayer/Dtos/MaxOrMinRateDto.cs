using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Dtos
{
    public class MaxOrMinRateDto
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public DateTime exchangeDate { get; set; }
    }
}
