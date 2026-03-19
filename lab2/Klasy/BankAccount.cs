namespace Klasy
{
    public class BankAccount
    {
        public double Saldo { get; private set; }
        public string Wlasciciel { get; set; }

        public BankAccount(string wlasciciel, double saldo)
        {
            if (saldo < 0)
            {
                throw new ArgumentException("Saldo nie może być ujemne!");
            }
            Saldo = saldo;
            Wlasciciel = wlasciciel;
        }

        public void Wplata(double kwota)
        {
            if (kwota < 0)
            {
                throw new ArgumentException("Kwota wpłaty nie może być ujemna!");
            }
            Saldo += kwota;
        }

        public void Wyplata(double kwota)
        {
            if (kwota < 0)
            {
                throw new ArgumentException("Kwota wypłaty nie może być ujemna!");
            }
            else if (Saldo < kwota)
            {
                throw new ArgumentException("Kwota nie może być większa od salda!");
            }
            Saldo -= kwota;
        }
    }
}
