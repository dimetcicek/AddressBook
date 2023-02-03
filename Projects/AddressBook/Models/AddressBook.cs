using Newtonsoft.Json;

public class AddressBook
{
    public List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void RemoveContact(Contact contact)
    {
        contacts.Remove(contact);
    }

    public Contact FindContact(string name)
    {
        return contacts.Find(contact => string.Equals(contact.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Contact> GetAllContacts()
    {
        return contacts;
    }

    public void SaveContacts()
    {
        var contactsPath = GetContactsPath();
        var json = JsonConvert.SerializeObject(contacts);
        
        File.WriteAllText(contactsPath, json);
    }

    public void LoadContacts()
    {
        var contactsPath = GetContactsPath();

        if (File.Exists(contactsPath))
        {
            var json = File.ReadAllText(contactsPath);
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }
    }

    private string GetContactsPath()
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        return Path.Combine(desktopPath, "contacts.json");
    }
}