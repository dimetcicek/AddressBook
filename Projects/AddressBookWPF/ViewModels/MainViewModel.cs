namespace AddressBookWPF.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using AddressBookWPF.Models;

    public class MainViewModel : ViewModelBase
    {
        private readonly AddressBook _addressBook;

        private Contact _selectedContact;
        private ObservableCollection<Contact> _contacts;
        private Visibility _detailedInformationVisibility;

        public MainViewModel(AddressBook addressBook)
        {
            _addressBook = addressBook;

            RemoveContactCommand = new Command(OnRemoveContact);
            EditContactCommand = new Command(OnEditContact);
            AddContactCommand = new Command(OnAddContact);

            SelectedContact = null;
        }

        public ICommand RemoveContactCommand { get; }

        public ICommand EditContactCommand { get; }

        public ICommand AddContactCommand { get; }

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;

            set
            {
                _contacts = value;

                RaisePropertyChanged(nameof(Contacts));
            }
        }

        public Contact SelectedContact
        {
            get => _selectedContact;

            set
            {
                _selectedContact = value;
                RaisePropertyChanged(nameof(SelectedContact));

                if (_selectedContact != null)
                {
                    DetailedInformationVisibility = Visibility.Visible;
                }
                else
                {
                    DetailedInformationVisibility = Visibility.Hidden;
                }
            }
        }

        public Visibility DetailedInformationVisibility
        {
            get => _detailedInformationVisibility;

            set
            {
                _detailedInformationVisibility = value;
                RaisePropertyChanged(nameof(DetailedInformationVisibility));
            }
        }

        public override void OnNavigatedTo(Contact contact)
        {
            _addressBook.LoadContacts();
            var contacts = _addressBook.GetAllContacts();
            Contacts = new ObservableCollection<Contact>(contacts);

            if (contact != null)
            {
                SelectedContact = _addressBook.FindContact(contact.Name);
            }
        }

        private void OnRemoveContact()
        {
            if (SelectedContact == null)
            {
                return;
            }

            var result = MessageBox.Show(Application.Current.MainWindow, $"Är du säker på att du vill ta bort: {SelectedContact.Name}?", "Bekräfta", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _addressBook.RemoveContact(SelectedContact);
                Contacts.Remove(SelectedContact);
                _addressBook.SaveContacts();
            }
        }

        private void OnEditContact()
        {
            NavigateTo(typeof(EditViewModel), SelectedContact.Clone());
        }

        private void OnAddContact()
        {
            NavigateTo(typeof(AddViewModel), null);
        }
    }
}