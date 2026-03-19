namespace Klasy
{
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        private List<int> oceny;
        public ReadOnlyCollection<int> Liczby => liczby.asReadOnly();
    }
}
