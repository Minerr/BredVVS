using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace ViewModel
{
    public class CreateNewCustomerViewModel : INotifyPropertyChanged
    {
        public string FirstName { get; set {  } }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZIPcode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public void CreateNewCustomer()
        {
            Customer customer = new Customer(FirstName, LastName, Address, ZIPcode, City, PhoneNumber);
            
        }

        public bool IsCustomerDataNotNull()
        {
            bool result = true;
            if(string.IsNullOrEmpty(FirstName) || 
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(ZIPcode) ||
                string.IsNullOrEmpty(City) ||
                string.IsNullOrEmpty(PhoneNumber))
            {
                result = false;
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
