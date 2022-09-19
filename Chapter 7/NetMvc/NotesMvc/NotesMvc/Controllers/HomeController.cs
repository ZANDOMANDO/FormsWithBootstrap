using Microsoft.AspNetCore.Mvc;
using NotesMvc.Models;
using System.Diagnostics;

namespace NotesMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NotesMvcContext context = new NotesMvcContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateNote()
        {
            return View();
        }

        public IActionResult AddNoteToDb(Note note)
        {
            note.Timestamp = DateTime.Now;
            context.Notes.Add(note);
            context.SaveChanges();

            return RedirectToAction("GetNotes");
        }

        public IActionResult GetNotes()
        {
            List<Note> notes = context.Notes.ToList();
            return View(notes);
        }
    }
}