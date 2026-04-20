namespace lab4.FileLab
{
    internal class Contact
    {
        public Contact() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Contact(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"ID: {Id}\t Imię i nazwisko: {Name}\t Email: {Email}";
        }
    }
}
