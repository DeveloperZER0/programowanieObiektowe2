namespace Klasy
{
    public class Osoba
    {
        public string Imie
        {
            get;
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Imię musi mieć co najmniej 2 znaki!");
                }
                field = value;
            }
        }

        public string Nazwisko
        {
            get;
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Nazwisko musi mieć co najmniej 2 znaki!");
                }
                field = value;
            }
        }

        public int Wiek
        {
            get;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wiek musi być dodatni!");
                }
                field = value;
            }
        }

        public Osoba(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine("Imię: " + Imie + ", Nazwisko: " + Nazwisko + ", Wiek: " + Wiek);
        }
    }
}
