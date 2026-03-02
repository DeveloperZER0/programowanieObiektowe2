namespace Task001
{
    /// <summary>
    /// Zestaw metod realizujacych zadania z lab01:
    /// </summary>
    /// <remarks>
    /// Autor: Wiktor Piwowar
    /// Data: 02.03.2026
    /// Wersja: 1.0
    /// Srodowisko: .net 10
    /// </remarks>
    internal class TaskLab
    {
        /// <summary>
        /// Metoda uruchomieniowa dla zadan z lab01
        /// </summary>
        public void Run()
        {
            RownanieKw();
        }

        /// <summary>
        /// Metoda obliczajaca wyroznik delta i pierwiastki trojmianu kwadratowego
        /// </summary>
        private void RownanieKw()
        {
            Console.WriteLine("Rozwiązanie równania kwadratowego ax^2 + bx + c = 0");
            double a = inputDouble("Podaj wspolczynnik a: ");
            double b = inputDouble("Podaj wspolczynnik b: ");
            double c = inputDouble("Podaj wspolczynnik c: ");

            if (a == 0)
            {
                Console.WriteLine("To nie jest rownanie kwadratowe (a=0)");
                return;
            }
            double delta = Math.Pow(b, 2) - (4 * a * c);

            if (delta > 0)
            {
                double x1 = -b - Math.Sqrt(delta) / (2 * a);
                double x2 = -b + Math.Sqrt(delta) / (2 * a);

                Console.WriteLine("Rownanie ma dwa pierwiastki rzeczywiste: ");
                Console.WriteLine($"x1 = {x1:F2}\nx2 = {x2:F2}");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Rownanie ma jedno rozwiazanie w zbiorze liczb rzeczywistych");
                Console.WriteLine($"x = {x:F2}");
            }
            else
            {
                Console.WriteLine("Brak rozwiazania w zbiorze liczb rzeczywistych");
            }
        }

        /// <summary>
        /// Metoda ktora pobiera string od usera i wykonuje konwersje na double. Wymusza na userze poprawne podanie liczby
        /// </summary>
        private double inputDouble(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double liczba))
                {
                    return liczba;
                }
                Console.WriteLine("Bledna wartosc. Podaj poprawna liczbe!");
            }
        }
    }
}
