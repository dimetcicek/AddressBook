using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class TestAddressBook
    {
        private AddressBook _addressBook;

        [SetUp]
        public void Setup ()
        {
            _addressBook = new AddressBook();
        }

        [Test]
        public void TestCreateContact()
        {
            var contact = new Contact("TestName", "12345", "TestAddress", "TestMail");
            Assert.AreEqual(null, _addressBook.FindContact(contact.Name));
            _addressBook.AddContact(contact);
            Assert.AreEqual(contact, _addressBook.FindContact(contact.Name));
        }
    }
}