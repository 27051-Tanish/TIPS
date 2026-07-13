using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

var contacts = new List<String>();

Console.WriteLine("Console-Based Contact Manager");
Console.WriteLine();
bool stopLoop = false;
while (!stopLoop)
{
    Console.WriteLine("===========================================");
    Console.WriteLine("[1]. To Add New Contact: Press 'A' or 'a'");
    Console.WriteLine("[2]. To View Contact: Press 'V' or 'v'");
    Console.WriteLine("[3]. To Edit Contact: Press 'ED' or 'ed'");
    Console.WriteLine("[4]. To Delete Contact: Press 'D' or 'd'");
    Console.WriteLine("[5]. To Search Contact: Press 'S' or 's'");
    Console.WriteLine("[6]. To Exit: Press 'E' or 'e'");
    Console.WriteLine("===========================================");

    var userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "A":
        case "a":
            Console.WriteLine("Add New Contact:");
            Console.WriteLine();
            Console.WriteLine("Enter name of the contact :");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Phone Number :");
            long phoneNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter email address :");
            string email = Console.ReadLine();
            contacts.Add(name);
            Console.WriteLine();
            AddContactInfo(name, phoneNumber, email);
            break;

        case "V":
        case "v":
            ViewContactInfo();
            break;

        case "ED":
        case "ed":
            EditContactInfo();
            break;

        case "R":
        case "r":
            RemoveContactInfo();
            break;

        case "S":
        case "s":
            SearchContactInfo();
            break;

        case "E":
        case "e":
            stopLoop = true;
            break;
    }
}

void AddContactInfo(string name, long phoneNumber, string email)
{
    Console.WriteLine("Name :" + name);
    Console.WriteLine("Phone Number :" + phoneNumber);
    Console.WriteLine("Email :" + email);
    Console.WriteLine();
    Console.WriteLine("Contact added successfully");
}
void ViewContactInfo()
{
        if(contacts.Count == 0)
        {
        Console.WriteLine("There is no contact present in the Contact Manager");
        }
        else
        {
        for (int i = 0; i < contacts.Count; i++)
            {
            Console.WriteLine($"{i+1}. {contacts[i]}");
            }
        }
}
void EditContactInfo()
{
    bool isEditable = false;
    while (!isEditable)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("There is no contact in the manager");
            continue;
        }
        Console.WriteLine("Enter the index of the contact to edit: ");
        var userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int index) && index >= 1 && index <= contacts.Count)
        {
            var contactToBeEdited = contacts[index - 1];
            Console.WriteLine("Enter New Name: ");
            string newName = Console.ReadLine();
            contactToBeEdited = newName;
            Console.WriteLine("Edited the contact info successfully");
            ViewContactInfo();
            isEditable = true;
        }
        else
        {
            Console.WriteLine("There is no such contact");
        }
    }
}
void RemoveContactInfo()
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("No Contacts have been added yet");
        return;
    }
    bool isIndexValid = false;

    while (!isIndexValid)
    {
        Console.WriteLine("Enter the index of the contact to delete: ");
        ViewContactInfo();
        var removeIndex = Console.ReadLine();
        if (removeIndex == "")
        {
            Console.WriteLine("Remove Index should not be empty");
            continue;
        }
        if (int.TryParse(removeIndex, out int index) && index >= 1 && index <= contacts.Count)
        {
            var contactToBeRemoved = contacts[index - 1];
            contacts.RemoveAt(index - 1);
            Console.WriteLine("Contact" + contactToBeRemoved + " deleted successfully");
            isIndexValid = true;
            ViewContactInfo();
        }
        else
        {
            Console.WriteLine("The given index is not valid");
        }
    }
}
void SearchContactInfo()
{
    bool isNameValid = false;
    Console.WriteLine("Enter name to search: ");
    var searchName = Console.ReadLine();
    if (searchName.Length == 0)
    {
        Console.WriteLine("Not a valid input");
    }

    string foundName = contacts.Find(s => s.Equals(searchName, StringComparison.OrdinalIgnoreCase));
    if (foundName != null)
    {
        isNameValid = true;
        Console.WriteLine("Contact Found :" + foundName);
    }
    else
    {
        Console.WriteLine("There is no such contact");
    }
}

Console.ReadKey();