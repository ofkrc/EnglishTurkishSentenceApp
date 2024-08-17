using EnglishTurkishSentenceApp.Models;
using EnglishTurkishSentenceApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace EnglishTurkishSentenceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Sentence> _sentences;

        public HomeController(SentenceService sentenceService)
        {
            _sentences = sentenceService.GetSentences();
        }

        public IActionResult Index()
        {
            // Ýlk cümleyi göstermek için
            ViewBag.Index = 0;
            ViewBag.Sentence = _sentences[0].english;
            ViewBag.Translation = string.Empty;
            return View();
        }

        [HttpPost]
        public IActionResult NextSentence(int currentIndex)
        {
            var nextIndex = (currentIndex + 1) % (_sentences.Count * 2);

            ViewBag.Index = nextIndex;
            if (nextIndex % 2 == 0)
            {
                ViewBag.Sentence = _sentences[nextIndex / 2].english;
                ViewBag.Translation = string.Empty;
            }
            else
            {
                ViewBag.Sentence = _sentences[nextIndex / 2].english;
                ViewBag.Translation = _sentences[nextIndex / 2].turkish;
            }

            return View("Index");
        }
    }
}
