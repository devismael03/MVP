using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Models;
using WindowsFormsApp5.Views;

namespace WindowsFormsApp5.Presenters
{
    class Presenter
    {
        IModel model;
        IView view;
        public Presenter(IModel m,IView v)
        {
            this.model = m;
            this.view = v;
            view.AddInvoked += View_AddInvoked;
            view.RemoveInvoked += View_RemoveInvoked;
            view.ViewLoaded += View_ViewLoaded;
        }

        private void View_ViewLoaded(object sender, EventArgs e)
        {
            var phones = this.model.SelectAll();
            this.view.ShowAll(phones);
        }

        private void View_RemoveInvoked(object sender, PhoneEventArgs e)
        {
            model.Delete(e.Phone.Id);
            view.RemovePhone(e.Phone);
        }


        private void View_AddInvoked(object sender, PhoneEventArgs e)
        {
            var newPhone = model.Add(e.Phone);
            view.ShowNewPhone(newPhone);
        }
    }
}
