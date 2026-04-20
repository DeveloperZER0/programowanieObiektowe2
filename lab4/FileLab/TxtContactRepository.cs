namespace lab4.FileLab
{
    internal class TxtContactRepository
    {
        private readonly string _filePath;

        public TxtContactRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(List<Contact> contacts)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                foreach (Contact contact in contacts)
                {
                    writer.WriteLine($"{contact.Id};{contact.Name};{contact.Email}");
                }
            }
        }

        public List<Contact> GetContacts()
        {
            List<Contact> list = new List<Contact>();

            if (!File.Exists(_filePath))
            {
                return list;
            }
            string[] lines = File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3)
                {
                    int id;
                    bool isParsed = int.TryParse(parts[0], out id);
                    if (isParsed)
                    {
                        list.Add(new Contact(id, parts[1], parts[2]));
                    }
                }
            }
            return list;
        }
    }
}
