using System;
using System.Collections.Generic;
using lab7.Data;
using lab7.Models;

class Program
{
    const string ConnectionString =
        "Server=localhost,1433;Database=ContactDB;User Id=sa;Password=TwojHaslo123!;TrustServerCertificate=True;";

    static void Main()
    {
        ContactRepository repo = new ContactRepository(ConnectionString);

        while (true)
        {
            PrintMenu();
            string choice = Console.ReadLine() ?? "";
            try
            {
                switch (choice)
                {
                    case "1":
                        Create(repo);
                        break;
                    case "2":
                        ReadAll(repo);
                        break;
                    case "3":
                        Search(repo);
                        break;
                    case "4":
                        Update(repo);
                        break;
                    case "5":
                        Delete(repo);
                        break;
                    case "6":
                        BulkInsertDemo(repo);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("\n=== CONTACT MANAGER (ADO.NET + DAL) ===");
        Console.WriteLine("1) Dodaj kontakt");
        Console.WriteLine("2) Pokaż wszystkie");
        Console.WriteLine("3) Wyszukaj po nazwisku");
        Console.WriteLine("4) Edytuj kontakt");
        Console.WriteLine("5) Usuń kontakt");
        Console.WriteLine("6) Bulk insert (transakcja) - demo");
        Console.WriteLine("0) Wyjście");
        Console.Write("Wybór: ");
    }

    static void Create(ContactRepository repo)
    {
        Contact c = new Contact
        {
            FirstName = ReadRequired("Imię: "),
            LastName = ReadRequired("Nazwisko: "),
            Phone = ReadOptional("Telefon (opcjonalnie): "),
            Email = ReadOptional("Email (opcjonalnie): "),
        };
        int id = repo.Add(c);
        Console.WriteLine($"Dodano kontakt z Id={id}");
    }

    static void ReadAll(ContactRepository repo)
    {
        List<Contact> list = repo.GetAll();
        Console.WriteLine(
            $"\n{"Id", -5} {"Imię", -15} {"Nazwisko", -15} {"Telefon", -15} {"Email"}"
        );
        Console.WriteLine(new string('-', 65));
        foreach (Contact c in list)
            Console.WriteLine(c);
        Console.WriteLine($"\nŁącznie: {list.Count} kontaktów.");
    }

    static void Search(ContactRepository repo)
    {
        string fragment = ReadRequired("Fragment nazwiska: ");
        List<Contact> list = repo.SearchByLastName(fragment);
        if (list.Count == 0)
        {
            Console.WriteLine("Nie znaleziono kontaktów.");
            return;
        }
        foreach (Contact c in list)
            Console.WriteLine(c);
        Console.WriteLine($"\nZnaleziono: {list.Count}");
    }

    static void Update(ContactRepository repo)
    {
        int id = ReadInt("Id kontaktu do edycji: ");
        Contact c = new Contact
        {
            Id = id,
            FirstName = ReadRequired("Nowe imię: "),
            LastName = ReadRequired("Nowe nazwisko: "),
            Phone = ReadOptional("Nowy telefon (opcjonalnie): "),
            Email = ReadOptional("Nowy email (opcjonalnie): "),
        };
        bool ok = repo.Update(c);
        Console.WriteLine(ok ? "Zaktualizowano." : "Nie znaleziono kontaktu o podanym Id.");
    }

    static void Delete(ContactRepository repo)
    {
        int id = ReadInt("Id kontaktu do usunięcia: ");
        bool ok = repo.Delete(id);
        Console.WriteLine(ok ? "Usunięto." : "Nie znaleziono kontaktu o podanym Id.");
    }

    static void BulkInsertDemo(ContactRepository repo)
    {
        int ile = ReadInt("Ile rekordów wygenerować? ");
        List<Contact> lista = new List<Contact>();
        for (int i = 1; i <= ile; i++)
        {
            lista.Add(
                new Contact
                {
                    FirstName = $"Imię{i}",
                    LastName = $"Nazwisko{i}",
                    Phone = $"60000000{i % 10}",
                    Email = $"kontakt{i}@example.com",
                }
            );
        }
        int dodano = repo.BulkInsert(lista);
        Console.WriteLine($"Dodano {dodano} rekordów.");
    }

    static string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write(label);
            string s = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(s))
                return s.Trim();
            Console.WriteLine("Pole nie może być puste.");
        }
    }

    static string? ReadOptional(string label)
    {
        Console.Write(label);
        string s = (Console.ReadLine() ?? "").Trim();
        return string.IsNullOrWhiteSpace(s) ? null : s;
    }

    static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (int.TryParse(Console.ReadLine(), out int id))
                return id;
            Console.WriteLine("Podaj poprawną liczbę całkowitą.");
        }
    }
}

