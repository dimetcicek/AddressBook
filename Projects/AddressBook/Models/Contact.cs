public class Contact
{
    public Contact(string name, string phone, string address, string email)
    {
        Name = name;
        Phone = phone;
        Address = address;
        Email = email;
    }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public Contact Clone()
    {
        return new Contact(Name, Phone, Address, Email);
    }
}