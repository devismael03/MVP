using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Models
{
    public class PhoneEventArgs :EventArgs
    {
        public Phone Phone { get; set; }
        public PhoneEventArgs(Phone phone)
        {
            this.Phone = phone;
        }


    }
}
