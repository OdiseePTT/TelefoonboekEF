    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    namespace Telefoonboek
    {
        internal class PhoneBookItem : INotifyPropertyChanged
        {
            private string lastname;
            private string firstname;
            private string email;
            private string phoneNumber;

            public event PropertyChangedEventHandler PropertyChanged;

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

            public PhoneBookItem(string lastname, string firstname, string email, string phoneNumber)
            {
                Lastname = lastname;
                Firstname = firstname;
                Email = email;
                PhoneNumber = phoneNumber;
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
