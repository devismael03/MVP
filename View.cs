using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Models;

namespace WindowsFormsApp5.Views
{
    public partial class View : Form,IView
    {
        public View()
        {
            InitializeComponent();
        }

        public event EventHandler<PhoneEventArgs> AddInvoked;
        public event EventHandler<PhoneEventArgs> RemoveInvoked;
        public event EventHandler<EventArgs> ViewLoaded;
        public event EventHandler<EventArgs> ViewClosing;

        public void RemoveAll()
        {
            this.listBox1.Items.Clear();
        }

        public void RemovePhone(Phone phone)
        {
            listBox1.Items.Remove(phone);
        }

        public void ShowAll(IEnumerable<Phone> phones)
        {
            listBox1.Items.AddRange(phones.ToArray());
        }

        public void ShowNewPhone(Phone phone)
        {
            this.listBox1.Items.Add(phone);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (AddInvoked != null)
            {
                var p = new Phone {
                    //use tryparse,you stupid csharper
                    Memory = int.Parse(this.memTextBox.Text),
                    Vendor = this.vendorTextBox.Text,
                    Title = this.titleTextBox.Text,
                    Price = int.Parse(this.priceTextBox.Text),
                    ScreenSize = double.Parse(this.scrSizeTextBox.Text)

                };
                AddInvoked.Invoke(this, new PhoneEventArgs(p));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(RemoveInvoked != null)
            {
                var p = this.listBox1.SelectedItem as Phone;
                RemoveInvoked.Invoke(this, new PhoneEventArgs(p));
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            if(ViewLoaded != null)
            {
                ViewLoaded.Invoke(this, e);
            }
        }
    }
}
