using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bokning_G.Models
{
    public class SkapaKonto
    {
        public int Id { get; set; }
        public string Användernamn { get; set; }
        public string Lösenord { get; set; }
        public string Namn { get; set; }
        public DateTime Ålder { get; set; }
        public int Telefonnummer { get; set; }
        public string Mail { get; set; }
        public bool isAdmin { get; set; }
        public ICollection<Bokningar> Bokningarna { get; set; }
    }
}
