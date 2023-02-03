namespace AddressBookWPF.ViewModels
{
    using System.Windows.Input;
    using AddressBookWPF.Models;

    public class EditViewModel : ViewModelBase
    {
        private readonly AddressBook _addressBook;

        private string _name;
        private string _address;
        private string _phone;
        private string _email;
        private Contact _realContact;

        public EditViewModel(AddressBook addressBook)
        {
            _addressBook = addressBook;

            SaveContactCommand = new Command(OnSaveContact);
            CancelCommand = new Command(OnCancel);
        }

        public ICommand SaveContactCommand { get; }

        public ICommand CancelCommand { get; }

        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Address
        {
            get => _address;

            set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        public string Phone
        {
            get => _phone;

            set
            {
                _phone = value;
                RaisePropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get => _email;

            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        public override void OnNavigatedTo(Contact contact)
        {
            Name = contact.Name;
            Phone = contact.Phone;
            Address = contact.Address;
            Email = contact.Email;

            _realContact = _addressBook.FindContact(contact.Name);
        }

        private void OnSaveContact()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            var contact = new Contact(Name, Phone, Address, Email);
            _addressBook.RemoveContact(_realContact);
            _addressBook.AddContact(contact);
            _addressBook.SaveContacts();

            NavigateTo(typeof(MainViewModel), contact);
        }

        private void OnCancel()
        {
            NavigateTo(typeof(MainViewModel), _realContact);
        }
    }
}