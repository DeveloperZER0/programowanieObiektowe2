namespace lab4.FileLab
{
    internal class JsonContactRepository
    {
        private readonly string _filePath;

        public JsonContactRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(List<Contact> contacts)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };

            string json = JsonSerializer.Serialize(contacts, options);
            File.WriteAllText(_filePath, json);
        }

        public List<Contact> GetContacts()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Contact>();
            }
            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Contact>();
            }

            List<Contact> contacts = JsonSerializer.Deserialize<List<Contact>>(json);

            return contacts ?? new List<Contact>();
        }
    }
}
