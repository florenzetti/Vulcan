using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Modelisateur.Model.Repositories
{
    public class EmplacementRepository : IRepository
    {
        private FileInfo _context;
        public EmplacementRepository(string filePath) : this(new FileInfo(filePath))
        {
        }
        public EmplacementRepository(FileInfo context)
        {
            _context = context;
        }

        public Emplacement Load()
        {
            Emplacement result = new Emplacement();
            try
            {
                if (_context.Exists)
                {
                    using (StreamReader reader = new StreamReader(_context.FullName))
                    {
                        string content = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<Emplacement>(content);
                    }
                }
            }
            //TODO: error log
            catch
            { }
            return result;
        }

        public async Task<Emplacement> LoadAsync()
        {
            Emplacement result = new Emplacement();
            if (_context.Exists)
            {
                using (StreamReader reader = new StreamReader(_context.FullName))
                {
                    string content = await reader.ReadToEndAsync();
                    result = JsonConvert.DeserializeObject<Emplacement>(content);
                }
            }

            return result;
        }

        public void Save(Emplacement emplacement, bool createFile)
        {
            string content = JsonConvert.SerializeObject(emplacement, Formatting.Indented);
            Save(content, createFile);
        }

        public void Save(string codeSource, bool createFile)
        {
            if (createFile || _context.Exists)
            {
                using (StreamWriter writer = new StreamWriter(_context.FullName))
                {
                    writer.Write(codeSource);
                }
            }
        }
    }
}