namespace AddressBookWPF.ViewModels
{
    using System.Windows.Input;
    using AddressBookWPF.Models;

    public class AddViewModel : ViewModelBase
    {
        private readonly AddressBook _addressBook;

        private string _name;
        private string _address;
        private string _phone;
        private string _email;

        public AddViewModel(AddressBook addressBook)
        {
            _addressBook = addressBook;

            AddContactCommand = new Command(OnAddContact);
            CancelCommand = new Command(OnCancel);
        }

        public ICommand AddContactCommand { get; }

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
            Name = null;
            Phone = null;
            Address = null;
            Email = null;
        }

        private void OnAddContact()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            var contact = new Contact(Name, Phone, Address, Email);
            _addressBook.AddContact(contact);
            _addressBook.SaveContacts();

            NavigateTo(typeof(MainViewModel), null);
        }

        private void OnCancel()
        {
            NavigateTo(typeof(MainViewModel), null);
        }
    }
}