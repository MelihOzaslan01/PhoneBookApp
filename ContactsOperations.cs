using System;
using System.Collections.Generic;
namespace contacts_app_csharp
{
    class ContactsOperations
    {
        public void ViewOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Lütfen yapmak istediðiniz iþlemi seçiniz :");
            Console.WriteLine("******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayý Silmek");
            Console.WriteLine("(3) Varolan Numarayý Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(6) Çýkýþ Yapmak");
            Console.WriteLine();
        }
        public void AddContact(List<Contact> contactList)
        {
            Console.WriteLine("Yeni Numara Kaydetmek");
            Console.WriteLine("Lütfen isim giriniz             :");
            string first_name = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz          :");
            string last_name = Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarasý giriniz :");
            string phone = Console.ReadLine();
            Contact newContact = new Contact(first_name, last_name, phone);
            contactList.Add(newContact);
            Console.WriteLine("Kiþi rehbere eklendi");
        }

        public void DeleteContact(List<Contact> contactList)
        {
            Console.WriteLine("Silmek istediðiniz kiþinin adýný ya da soyadýný giriniz: ");
            Console.WriteLine("Lütfen isim giriniz   :");
            string first_name = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz:");
            string last_name = Console.ReadLine();
            var contact = contactList.Find(
                x => x.getFirstName() == first_name ||
                x.getLastName() == last_name);
            if (contact != null)
            {
                Console.WriteLine(contact.getFirstName() + " " + contact.getLastName()
                + " isimli kiþi rehberden silinmek üzere, onaylýyor musunuz ?(y/n)");
                string confirmation = Console.ReadLine();
                if (confirmation == "y" || confirmation == "yes")
                {
                    contactList.Remove(contact);
                    Console.WriteLine("Kiþi rehberden silindi");
                }
            }
            else
            {
                Console.WriteLine("Aradýðýnýz kriterlere uygun veri rehberde bulunamadý. Lütfen bir seçim yapýnýz.");
                Console.WriteLine("* Silmeyi sonlandýrmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                int option = Convert.ToInt16(Console.ReadLine());
                if (option == 2)
                {
                    DeleteContact(contactList);
                }
            }
        }

        public void UpdateContact(List<Contact> contactList)
        {
            Console.WriteLine(" Lütfen numarasýný güncellemek istediðiniz kiþinin adýný ya da soyadýný giriniz: ");
            Console.WriteLine("Lütfen isim giriniz    :");
            string first_name = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz :");
            string last_name = Console.ReadLine();

            var contact = contactList.Find(
                x => x.getFirstName() == first_name ||
                x.getLastName() == last_name);

            if (contact != null)
            {
                Console.WriteLine("Bulunan kiþi: ");
                Console.WriteLine();
                Console.WriteLine("Ýsim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
                Console.WriteLine("*".PadRight(44, '*'));
                Console.WriteLine(
                    contact.getFirstName().PadRight(15, ' ')
                    + contact.getLastName().PadRight(15, ' ')
                    + contact.getPhone().PadRight(15, ' '));

                //Güncellenecek veri isteniyor
                Console.WriteLine("Lütfen yeni isim giriniz    :");
                string new_first_name = Console.ReadLine();
                Console.WriteLine("Lütfen yeni soyisim giriniz :");
                string new_last_name = Console.ReadLine();
                Console.WriteLine("Lütfen yeni numara giriniz :");
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

                    Console.WriteLine("Güncelleme tamamlandý");
                }
            }
            else
            {
                Console.WriteLine("Aradýðýnýz kriterlere uygun veri rehberde bulunamadý. Lütfen bir seçim yapýnýz.");
                Console.WriteLine("* Güncellemeyi sonlandýrmak için:(1)");
                Console.WriteLine("* Yeniden denemek için          :(2)");
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
            Console.WriteLine("Ýsim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
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
            Console.WriteLine("Arama yapmak istediðiniz tipi seçiniz.");
            Console.WriteLine(" **********************************************");
            Console.WriteLine("Ýsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasýna göre arama yapmak için: (2)");
            int option = Convert.ToInt16(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Lütfen isim giriniz   :");
                string first_name = Console.ReadLine();
                Console.WriteLine("Lütfen soyisim giriniz:");
                string last_name = Console.ReadLine();

                var contact = contactList.Find(
                x => x.getFirstName() == first_name ||
                x.getLastName() == last_name);
                if (contact != null)
                {
                    Console.WriteLine("Bulunan Kiþi: ");
                    Console.WriteLine();
                    Console.WriteLine("Ýsim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
                    Console.WriteLine("*".PadRight(44, '*'));

                    Console.WriteLine(
                    contact.getFirstName().PadRight(15, ' ')
                    + contact.getLastName().PadRight(15, ' ')
                    + contact.getPhone().PadRight(15, ' '));

                }
                else
                {
                    Console.WriteLine("Kiþi bulunamadý");
                }
            }
            else if (option == 2)
            {
                Console.WriteLine("Lütfen telefon numarasý giriniz:");
                string phone = Console.ReadLine();
                var contact = contactList.Find(
                x => x.getPhone() == phone);

                if (contact != null)
                {
                    Console.WriteLine("Bulunan kiþi: ");
                    Console.WriteLine();
                    Console.WriteLine("Ýsim".PadRight(15, ' ') + "Soyisim".PadRight(15, ' ') + "Telefon".PadRight(15, ' '));
                    Console.WriteLine("*".PadRight(44, '*'));

                    Console.WriteLine(
                    contact.getFirstName().PadRight(15, ' ')
                    + contact.getLastName().PadRight(15, ' ')
                    + contact.getPhone().PadRight(15, ' '));
                }
                else
                {
                    Console.WriteLine("Kiþi bulunamadý");
                }
            }
        }
    }
}