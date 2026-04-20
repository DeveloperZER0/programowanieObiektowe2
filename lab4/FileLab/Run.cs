namespace lab4.FileLab
{
    internal class Run
    {
        public void runSystem()
        {
            List<Contact> contacts = new List<Contact>();

            string fileTxt = "contacts.txt";
            string fileJson = "contacts.json";

            TxtContactRepository txtContactRepository = new TxtContactRepository(fileTxt);
            JsonContactRepository jsonContactRepository = new JsonContactRepository(fileJson);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("--- SYSTEM ZARZĄDZANIA KONTAKTAMI ---");
                Console.WriteLine("--- Opcje: ---");
                Console.WriteLine("1. Dodaj Kontakt");
                Console.WriteLine("2. Wyświetl kontakt");
                Console.WriteLine("3. Zapisz kontakty do TXT");
                Console.WriteLine("4. Odczytaj kontakty z TXT");
                Console.WriteLine("5. Zapisz kontakty do JSON");
                Console.WriteLine("6. Odczytaj kontakty z JSON");
                Console.WriteLine("0. Wyjście");

                Console.WriteLine("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact(contacts);
                        break;
                    case "2":
                        ViewContact(contacts);
                        break;
                    case "3":
                        txtContactRepository.Save(contacts);
                        Console.WriteLine("Dane zostały zapisane do pliku TXT");
                        Pause();
                        break;
                    case "4":
                        txtContactRepository.GetContacts();
                        Console.WriteLine("Dane zostały odczytane z pliku TXT");
                        break;
                    case "5":
                        jsonContactRepository.Save(contacts);
                        Console.WriteLine("Dane zostały zapisane do pliku JSON");
                        break;
                    case "6":
                        jsonContactRepository.GetContacts();
                        Console.WriteLine("Dane zostały odczytane z pliku JSON");
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja!");
                        Pause();
                        break;
                }
            }
        }

        private void AddContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("---- Dodawanie kontaktów ----");

            int id = GenerateId(contacts);

            Console.WriteLine("Podaj imię i nazwisko: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj email: ");
            string email = Console.ReadLine();

            Contact contact = new Contact(id, name, email);

            contacts.Add(contact);

            Console.WriteLine("Kontakt został dodany!");
            Pause();
        }

        private int GenerateId(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                return 1;
            }

            return contacts.Max(c => c.Id) + 1;
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Naciśnij dowolny klawicz, aby kontynuować...");
            Console.ReadKey();
        }
    }
}
