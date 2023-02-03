using System.Windows;

namespace AddressBookWPF
{
    using AddressBookWPF.ViewModels;
    using AddressBookWPF.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AddressBook _addressBook;

        private AddView _addView;
        private AddViewModel _addViewModel;

        private EditView _editView;
        private EditViewModel _editViewModel;

        private MainView _mainView;
        private MainViewModel _mainViewModel;

        private MainWindow _mainWindow;
        private MainWindowViewModel _mainWindowViewModel;

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _addressBook = new AddressBook();

            _addViewModel = new AddViewModel(_addressBook);
            _addView = new AddView
            {
                DataContext = _addViewModel
            };

            _editViewModel = new EditViewModel(_addressBook);
            _editView = new EditView
            {
                DataContext = _editViewModel
            };

            _mainViewModel = new MainViewModel(_addressBook);
            _mainView = new MainView
            {
                DataContext = _mainViewModel
            };

            _mainWindowViewModel = new MainWindowViewModel(_mainView, _mainViewModel, _addView, _addViewModel, _editView, _editViewModel);
            _mainWindow = new MainWindow
            {
                DataContext = _mainWindowViewModel
            };

            _mainWindow.Show();
        }
    }
}