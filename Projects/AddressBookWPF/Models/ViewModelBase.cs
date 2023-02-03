namespace AddressBookWPF.Models
{
    using System;
    using System.ComponentModel;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public event EventHandler<NavigationEventArgs> NavigationRequest;

        public virtual void OnNavigatedTo(Contact contact)
        {
        }

        protected void NavigateTo(Type viewModelType, Contact contact)
        {
            NavigationRequest?.Invoke(this, new NavigationEventArgs(viewModelType, contact));
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}