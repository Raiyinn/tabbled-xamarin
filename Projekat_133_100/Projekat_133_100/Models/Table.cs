using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat_133_100.Models
{
    public class Table
    {
        public int Id { get; set; } 
        public Boolean Reserved { get; set; }
        public string Caffee { get; set; }

        public Table()
        {
            Reserved = false;
        }
    }
}
