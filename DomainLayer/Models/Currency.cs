using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Currency : BaseEntity
    {
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Sign { get; set; }

        public bool IsActive { get; set; }
    }
}
