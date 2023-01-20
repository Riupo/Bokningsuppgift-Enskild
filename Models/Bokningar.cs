using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokning_G.Models
{
    public class Bokningar
    {
        public int Id { get; set; }
        public int SkapaKontoId { get; set; }
        public string KundNamn { get; set; }
        public DateTime Tid { get; set; }
        public int Pris { get; set; }
    }
}
