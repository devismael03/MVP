using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Models;

namespace WindowsFormsApp5.Views
{
    public interface IView
    {
        void ShowAll(IEnumerable<Phone> phones);
        void ShowNewPhone(Phone phone);
        void RemovePhone(Phone phone);
        void RemoveAll();

        event EventHandler<PhoneEventArgs> AddInvoked;
        event EventHandler<PhoneEventArgs> RemoveInvoked;
        event EventHandler<EventArgs> ViewLoaded;
        event EventHandler<EventArgs> ViewClosing;
    }
}
