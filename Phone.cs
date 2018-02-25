using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public double ScreenSize { get; set; }
        public int Memory { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Vendor} {Title}";
        }
    }
}
