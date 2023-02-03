public class Program
{
    public static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();
        addressBook.LoadContacts();

        while (true)
        {
            PrintMenu();
            var choice = GetChoice();
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateContact(addressBook);
                    break;
                case 2:
                    RemoveContact(addressBook);
                    break;
                case 3:
                    ShowContact(addressBook);
                    break;
                case 4:
                    ShowAllContacts(addressBook);
                    break;
                case 5:
                    addressBook.SaveContacts();
                    return;
            }

            Console.WriteLine();
        }
    }

    private static void PrintMenu() 
    {
        Console.WriteLine("Welcome to the address book!");
        Console.WriteLine("1. Add Contact");
        Console.WriteLine("2. Remove Contact");
        Console.WriteLine("3. Show Contact");
        Console.WriteLine("4. Show All Contacts");
        Console.WriteLine("5. Exit");
    }

    private static void CreateContact(AddressBook addressBook)
    {
        Console.WriteLine("Enter name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter phone:");
        var phone = Console.ReadLine();

        Console.WriteLine("Enter address:");
        var address = Console.ReadLine();

        Console.WriteLine("Enter email:");
        var email = Console.ReadLine();

        addressBook.AddContact(new Contact(name, phone, address, email));
        Console.WriteLine("New contact added. ");
    }

    private static void RemoveContact(AddressBook addressBook)
    {
        Console.Write("Enter the name of the contact you wish to remove: ");
        Console.WriteLine();

        var contactName = Console.ReadLine();
        Contact contact = addressBook.FindContact(contactName);

        if (contact != null)
        {
            while (true)
            {
                Console.Write("Are you sure you want to delete " + contactName + "? (y/n): ");
                var input = Console.ReadLine();

                if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase))
                {
                    addressBook.RemoveContact(contact);
                    Console.WriteLine("Contact removed.");

                    break;
                }
                else if (string.Equals(input, "n", StringComparison.OrdinalIgnoreCase))
                {
                    PressAnyKey();

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }

    private static void ShowContact(AddressBook addressBook)
    {
        Console.WriteLine("Enter name:");
        var name = Console.ReadLine();

        var specificContact = addressBook.FindContact(name);

        Console.WriteLine();
        Console.WriteLine("Name: " + specificContact.Name);
        Console.WriteLine("Phone: " + specificContact.Phone);
        Console.WriteLine("Address: " + specificContact.Address);
        Console.WriteLine("Email: " + specificContact.Email);

        PressAnyKey();
    }

    private static void ShowAllContacts(AddressBook addressBook)
    {
        var allContacts = addressBook.GetAllContacts();

        foreach (Contact contact in allContacts)
        {
            Console.WriteLine("Name: " + contact.Name);
            Console.WriteLine("Phone: " + contact.Phone);
            Console.WriteLine("Address: " + contact.Address);
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine();
        }

        PressAnyKey();
    }

    private static int GetChoice()
    {
        while(true)
        {
            if(int.TryParse(Console.ReadLine(), out var choice))
            {
                return choice;
            }

            Console.WriteLine("Please enter a valid choice!");
        }
    }

    private static void EraseLastCharacter()
    {
        var pos = Console.GetCursorPosition();
        Console.SetCursorPosition(pos.Left - 1, pos.Top);
        Console.Write(" ");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to return to main menu.");
        Console.ReadKey();
        EraseLastCharacter();
    }
}