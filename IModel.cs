using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Models
{
    public interface IModel
    {
        IEnumerable<Phone> SelectAll();
        Phone Find(int id);
        Phone Find(string vendor, string title);
        Phone Add(Phone phone);
        bool Delete(int id);

    }
}
