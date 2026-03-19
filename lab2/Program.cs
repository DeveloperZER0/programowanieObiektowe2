// See https://aka.ms/new-console-template for more information
using Klasy;

Osoba student1 = new("Wiktor", "Piwowar", 21);

student1.WyswietlInformacje();

BankAccount konto1 = new(student1.Imie + " " + student1.Nazwisko, 500.0);
Console.WriteLine(konto1.Wlasciciel + " " + konto1.Saldo);
konto1.Wplata(100);
Console.WriteLine(konto1.Wlasciciel + " " + konto1.Saldo);
konto1.Wyplata(200);
Console.WriteLine(konto1.Wlasciciel + " " + konto1.Saldo);
