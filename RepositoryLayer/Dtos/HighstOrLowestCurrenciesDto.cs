using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Dtos
{

    public class HighstOrLowestCurrenciesDto
    {
        public string name { get; set; }
        public double rate { get; set; }
        public DateTime exchangeDate { get; set; }
    }
}
