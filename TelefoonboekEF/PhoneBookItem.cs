using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Telefoonboek
{
    internal class PhoneBookItem : INotifyPropertyChanged
    {
        private string lastname;
        private string firstname;
        private string email;
        private string phoneNumber;
        private string address;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int ID { get; set; }
        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }
        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Address { get => address; set => address = value; }

        public PhoneBookItem(string lastname, string firstname, string email, string phoneNumber, string address)
        {
            Lastname = lastname;
            Firstname = firstname;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public PhoneBookItem()
        {

        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
