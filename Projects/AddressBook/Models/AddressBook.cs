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

    public List<Contact> ShowAllContacts()
    {
        return contacts;
    }

    public void SaveContacts()
    {
        string json = JsonConvert.SerializeObject(contacts);
        File.WriteAllText("contacts.json", json);
    }

    public void LoadContacts()
    {
        if (File.Exists("contacts.json"))
        {
            string json = File.ReadAllText("contacts.json");
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }
    }
}