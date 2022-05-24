using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Telefoonboek
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string lastname;
        private string firstname;
        private string email;
        private string phoneNumber;
        private List<PhoneBookItem> phoneBookItems = new List<PhoneBookItem>();
        private PhoneBookItem selectedItem;
        private string address;

        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged();
                CheckSaveButtonAvailablity();
            }
        }

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged();
                CheckSaveButtonAvailablity();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
                CheckSaveButtonAvailablity();
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
                CheckSaveButtonAvailablity();
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        public PhoneBookItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    FillTextBoxes(selectedItem);
                }
                else
                {
                    ResetProperties();
                }
                OnPropertyChanged();
                CheckDeleteButtonAvailablity();
            }
        }

        private bool saveButtonEnabled;
        private bool deleteButtonEnabled;

        public bool SaveButtonEnabled
        {
            get { return saveButtonEnabled; }
            private set
            {
                saveButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool DeleteButtonEnabled
        {
            get { return deleteButtonEnabled; }
            private set
            {
                deleteButtonEnabled = value;
                OnPropertyChanged();
            }
        }




        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public List<PhoneBookItem> PhoneBookItems
        {
            get => phoneBookItems;
            set
            {
                phoneBookItems = value;
                OnPropertyChanged();
            }
        }
        PhoneBookRepository phoneBookRepository = new PhoneBookRepository();

        public MainViewModel()
        {
            SaveCommand = new ActionCommand(SaveCommandAction);
            DeleteCommand = new ActionCommand(DeleteCommandAction);
            PhoneBookItems = phoneBookRepository.GetAllPhoneBookItems();
        }

        private void FillTextBoxes(PhoneBookItem item)
        {
            Lastname = item.Lastname;
            Firstname = item.Firstname;
            Email = item.Email;
            PhoneNumber = item.PhoneNumber;
        }

        private void SaveCommandAction()
        {
            if (SelectedItem == null)
            {
                phoneBookRepository.SaveItem(new PhoneBookItem(Lastname, Firstname, Email, PhoneNumber, Address));
                ResetProperties();
            }
            else
            {
                SelectedItem.Lastname = Lastname;
                SelectedItem.Firstname = Firstname;
                SelectedItem.Email = Email;
                SelectedItem.PhoneNumber = PhoneNumber;
                SelectedItem.Address = Address;
                phoneBookRepository.UpdateItem(SelectedItem);

                SelectedItem = null; // deselecteren van item.
            }
            PhoneBookItems = phoneBookRepository.GetAllPhoneBookItems();
        }

        private void ResetProperties()
        {
            Lastname = null;
            Firstname = null;
            Email = null;
            PhoneNumber = null;
        }

        private void DeleteCommandAction()
        {
            phoneBookRepository.DeleteItem(SelectedItem);
            PhoneBookItems = phoneBookRepository.GetAllPhoneBookItems();

        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CheckSaveButtonAvailablity()
        {
            SaveButtonEnabled = (Lastname != null && Lastname != "") && (Firstname != null && Firstname != "") && ((Email != null && Email != "") || (PhoneNumber != null && PhoneNumber != ""));
        }

        private void CheckDeleteButtonAvailablity()
        {
            DeleteButtonEnabled = SelectedItem != null;
        }

    }
}
