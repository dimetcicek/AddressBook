namespace AddressBookWPF.Models
{
    using System;

    public class NavigationEventArgs : EventArgs
    {
        public NavigationEventArgs(Type viewModelType, Contact contact)
        {
            ViewModelType = viewModelType;
            Contact = contact;
        }

        public Type ViewModelType { get; }

        public Contact Contact { get; }
    }
}