namespace AddressBookWPF.ViewModels
{
    using System;
    using System.ComponentModel;
    using AddressBookWPF.Models;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public event EventHandler<NavigationEventArgs> NavigationRequest;

        public void NavigateTo(Type viewModelType, Contact contact)
        {
            NavigationRequest?.Invoke(this, new NavigationEventArgs(viewModelType, contact));
        }

        public virtual void OnNavigatedTo(Contact contact)
        {
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}