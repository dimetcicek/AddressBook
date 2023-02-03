namespace TestProject
{
    using AddressBookWPF.ViewModels;
    using NUnit.Framework;

    internal class TestViewModelBase
    {
        private ViewModelBase _viewModelBase;

        [SetUp]
        public void Setup()
        {
            _viewModelBase = new ViewModelBase();
        }
      
        [Test]
        public void TestNavigateTo()
        {
            var gotNavigationRequest = false;
            _viewModelBase.NavigationRequest += (_, _) => gotNavigationRequest = true;
            _viewModelBase.NavigateTo(typeof(MainViewModel), null);
            Assert.True(gotNavigationRequest);
        }
    }
}