namespace AddressBookWPF.ViewModels
{
    using AddressBookWPF.Models;
    using AddressBookWPF.Views;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly MainView _mainView;
        private readonly MainViewModel _mainViewModel;
        private readonly AddView _addView;
        private readonly AddViewModel _addViewModel;
        private readonly EditView _editView;
        private readonly EditViewModel _editViewModel;

        private ViewModelBase _currentViewModel;

        public MainWindowViewModel(
            MainView mainView,
            MainViewModel mainViewModel,
            AddView addView,
            AddViewModel addViewModel,
            EditView editView,
            EditViewModel editViewModel)
        {
            _mainView = mainView;
            _mainViewModel = mainViewModel;
            _addView = addView;
            _addViewModel = addViewModel;
            _editView = editView;
            _editViewModel = editViewModel;

            _mainViewModel.NavigationRequest += OnNavigationRequest;
            _addViewModel.NavigationRequest += OnNavigationRequest;
            _editViewModel.NavigationRequest += OnNavigationRequest;

            CurrentViewModel = _mainViewModel;
            CurrentViewModel.OnNavigatedTo(null);
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;

            set
            {
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }

        private void OnNavigationRequest(object? sender, NavigationEventArgs args)
        {
            if (args.ViewModelType == typeof(MainViewModel))
            {
                CurrentViewModel = _mainViewModel;
            }
            else if (args.ViewModelType == typeof(AddViewModel))
            {
                CurrentViewModel = _addViewModel;
            }
            else if (args.ViewModelType == typeof(EditViewModel))
            {
                CurrentViewModel = _editViewModel;
            }

            CurrentViewModel.OnNavigatedTo(args.Contact);
        }
    }
}