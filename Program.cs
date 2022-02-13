using System;
using System.Collections.Generic;
namespace contacts_app_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int operation = 0;
            List<Contact> contactsList = new List<Contact>();
            ContactsOperations ops = new ContactsOperations();
            contactsList.Add(new Contact("Ali", "Özcan", "05465962135"));
            contactsList.Add(new Contact("Aslı", "Kara", "05321654979"));
            contactsList.Add(new Contact("Selin", "Güçlü", "05333657815"));
            contactsList.Add(new Contact("Kerem", "Akdoğan", "05559651548"));

            do
            {
                ops.ViewOptions();
                operation = Convert.ToInt16(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ops.AddContact(contactsList);
                        break;
                    case 2:
                        ops.DeleteContact(contactsList);
                        break;
                    case 3:
                        ops.UpdateContact(contactsList);
                        break;
                    case 4:
                        ops.ViewContacts(contactsList);
                        break;
                    case 5:
                        ops.ViewContact(contactsList);
                        break;
                }
            } while (Convert.ToInt16(operation) != 6);


        }
    }
}