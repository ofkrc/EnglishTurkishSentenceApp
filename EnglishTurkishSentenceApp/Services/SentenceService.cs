using EnglishTurkishSentenceApp.Models;
using System.Text.Json;

namespace EnglishTurkishSentenceApp.Services
{
    public class SentenceService
    {
        private readonly List<Sentence> _sentences;

        public SentenceService()
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "dataset.json");
            var jsonData = File.ReadAllText(jsonFilePath);
            _sentences = JsonSerializer.Deserialize<List<Sentence>>(jsonData);
        }

        public List<Sentence> GetSentences()
        {
            return _sentences;
        }
    }
}
