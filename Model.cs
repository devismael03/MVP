using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp5.Models
{
    public class Model : IModel
    {
        public Phone Add(Phone phone)
        {
            var phones = Load() as IList<Phone>;
            phone.Id = Guid.NewGuid().GetHashCode();
            phones.Add(phone);
            Save(phones);
            return phone;

            
        }
        public bool Delete(int id)
        {
            var phones = Load();
            var newCollection = phones.Where(p => p.Id != id);
            if(phones.Count() == newCollection.Count())
            {
                return false;
            }
            Save(newCollection);
            return true;
        }
        public Phone Find(int id)
        {
            return Load().FirstOrDefault(p => p.Id == id);
        }
        public Phone Find(string vendor, string title)
        {
            return Load().FirstOrDefault(p => p.Vendor == vendor && p.Title == title);
        }
        public IEnumerable<Phone> SelectAll()
        {
            return Load();
        }
        private void Save(IEnumerable<Phone> phones)
        {
            using (var fs = new FileStream("data.xml", FileMode.Create))
            {

                var xmls = new XmlSerializer(typeof(List<Phone>));
                xmls.Serialize(fs,phones.ToList());
            }

        }
        private IEnumerable<Phone> Load()
        {
            if (File.Exists("data.xml"))
            {
                using (var fs = new FileStream("data.xml", FileMode.Open))
                {
                    var xmls = new XmlSerializer(typeof(List<Phone>));
                    var phones = xmls.Deserialize(fs) as List<Phone>;
                    if(phones != null)
                    {
                        return phones;
                    }
                }
            }

            return new List<Phone>();
        }
    }
}
