using System;
using System.Collections.Generic;
namespace contacts_app_csharp
{
    class ContactsOperations
    {
        public void ViewOptions()
        {
            Console.WriteLine();
            Console.WriteLine("L�tfen yapmak istedi�iniz i�lemi se�iniz :");
            Console.WriteLine("******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numaray� Silmek");
            Console.WriteLine("(3) Varolan Numaray� G�ncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(6) ��k�� Yapmak");
            Console.WriteLine();
        }
        public void AddContact(List<Contact> contactList)
        {
            Console.WriteLine("Yeni Numara Kaydetmek");
            Console.WriteLine("L�tfen isim giriniz             :");
            string first_name = Console.ReadLine();
            Console.WriteLine("L�tfen soyisim giriniz          :");
            string last_name = Console.ReadLine();
            Console.WriteLine("L�tfen telefon numaras� giriniz :");
            string phone = Console.ReadLine();
            Contact newContact = new Contact(first_name, last_name, phone);
            contactList.Add(newContact);
            Console.WriteLine("Ki�i rehbere eklendi");
        }

        public void DeleteContact(List<Contact> contactList)
        {
            Console.WriteLine("Silmek istedi�iniz ki�inin ad�n� ya da soyad�n� giriniz: ");
            Console.WriteLine("L�tfen isim giriniz   :");
            string first_name = Console.ReadLine();
            Console.WriteLine("L�tfen soyisim giriniz:");
            string last_name = Console.ReadLine();
            var contact = contactList.Find(
                x => x.getFirstName() == first_name ||
                x.getLastName() == last_name);
            if (contact != null)
            {
                Console.WriteLine(contact.getFirstName() + " " + contact.getLastName()
                + " isimli ki�i rehberden silinmek �zere, onayl�yor musunuz ?(y/n)");
                string confirmation = Console.ReadLine();
                if (confirmation == "y" || confirmation == "yes")
                {
                    contactList.Remove(contact);
                    Console.WriteLine("Ki�i rehberden silindi");
                }
            }
            else
            {
                Console.WriteLine("Arad���n�z kriterlere uygun veri rehberde bulunamad�. L�tfen bir se�im yap�n�z.");
                Console.WriteLine("* Silmeyi sonland�rmak i�in : (1)");
                Console.WriteLine("* Yeniden denemek i�in      : (2)");
                int option = Convert.ToInt16(Console.ReadLine());
                if (option == 2)
                {
                    DeleteContact(contactList);
                }
            }
        }

        public void UpdateContact(List<Contact> contactList)
        {
            Console.WriteLine(" L�tfen numaras�n� g�ncellemek istedi�iniz ki�inin ad�n� ya da soyad�n� giriniz: ");
            Console.WriteLine("L�tfen isim giriniz    :");
            string first_name = Console.ReadLine();
            Console.WriteLine("L�tfen soyisim giriniz :");
            string last_name = Console.ReadLine();

            var contact = contactList.Find(
                x => x.getFirstName() == first_name ||
                x.getLastName() == last_name);

            if (contact != null)
            {
                Console.WriteLine("Bulunan ki�i: ");
                Console.WriteLine();
                Console.WriteLine("�sim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
                Console.WriteLine("*".PadRight(44, '*'));
                Console.WriteLine(
                    contact.getFirstName().PadRight(15, ' ')
                    + contact.getLastName().PadRight(15, ' ')
                    + contact.getPhone().PadRight(15, ' '));

                //G�ncellenecek veri isteniyor
                Console.WriteLine("L�tfen yeni isim giriniz    :");
                string new_first_name = Console.ReadLine();
                Console.WriteLine("L�tfen yeni soyisim giriniz :");
                string new_last_name = Console.ReadLine();
                Console.WriteLine("L�tfen yeni numara giriniz :");
                string new_phone = Console.ReadLine();
                if (new_first_name != "" || new_last_name != "" || new_phone != "")
                {
                    if (new_first_name != "")
                    {
                        contact.setFirstName(new_first_name);
                    }
                    if (new_last_name != "")
                    {
                        contact.setLastName(new_last_name);
                    }
                    if (new_phone != "")
                    {
                        contact.setPhone(new_phone);
                    }

                    Console.WriteLine("G�ncelleme tamamland�");
                }
            }
            else
            {
                Console.WriteLine("Arad���n�z kriterlere uygun veri rehberde bulunamad�. L�tfen bir se�im yap�n�z.");
                Console.WriteLine("* G�ncellemeyi sonland�rmak i�in:(1)");
                Console.WriteLine("* Yeniden denemek i�in          :(2)");
                int option = Convert.ToInt16(Console.ReadLine());
                if (option == 2)
                {
                    UpdateContact(contactList);
                }
            }
        }

        public void ViewContacts(List<Contact> contactList)
        {
            Console.WriteLine("Rehberi Listelemek");
            Console.WriteLine("*".PadRight(44, '*'));
            Console.WriteLine("�sim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
            Console.WriteLine();
            foreach (var item in contactList)
            {
                Console.WriteLine(
                    item.getFirstName().PadRight(15, ' ')
                    + item.getLastName().PadRight(15, ' ')
                    + item.getPhone().PadRight(15, ' '));
            }
        }

        public void ViewContact(List<Contact> contactList)
        {
            Console.WriteLine("Arama yapmak istedi�iniz tipi se�iniz.");
            Console.WriteLine(" **********************************************");
            Console.WriteLine("�sim veya soyisime g�re arama yapmak i�in: (1)");
            Console.WriteLine("Telefon numaras�na g�re arama yapmak i�in: (2)");
            int option = Convert.ToInt16(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("L�tfen isim giriniz   :");
                string first_name = Console.ReadLine();
                Console.WriteLine("L�tfen soyisim giriniz:");
                string last_name = Console.ReadLine();

                var contact = contactList.Find(
                x => x.getFirstName() == first_name ||
                x.getLastName() == last_name);
                if (contact != null)
                {
                    Console.WriteLine("Bulunan Ki�i: ");
                    Console.WriteLine();
                    Console.WriteLine("�sim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
                    Console.WriteLine("*".PadRight(44, '*'));

                    Console.WriteLine(
                    contact.getFirstName().PadRight(15, ' ')
                    + contact.getLastName().PadRight(15, ' ')
                    + contact.getPhone().PadRight(15, ' '));

                }
                else
                {
                    Console.WriteLine("Ki�i bulunamad�");
                }
            }
            else if (option == 2)
            {
                Console.WriteLine("L�tfen telefon numaras� giriniz:");
                string phone = Console.ReadLine();
                var contact = contactList.Find(
                x => x.getPhone() == phone);

                if (contact != null)
                {
                    Console.WriteLine("Bulunan ki�i: ");
                    Console.WriteLine();
                    Console.WriteLine("�sim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
                    Console.WriteLine("*".PadRight(44, '*'));

                    Console.WriteLine(
                    contact.getFirstName().PadRight(15, ' ')
                    + contact.getLastName().PadRight(15, ' ')
                    + contact.getPhone().PadRight(15, ' '));
                }
                else
                {
                    Console.WriteLine("Ki�i bulunamad�");
                }
            }
        }
    }
}