using GamesLibriary.Models;
using GamesLibriary.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace GamesLibriary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesRepository _gamesRepository;
        private readonly IGamesService _gamesService;

        public HomeController(ILogger<HomeController> logger, IGamesRepository gamesRepository, IGamesService gamesService)
        {
            _logger = logger;
            _gamesRepository = gamesRepository;
            _gamesService = gamesService;
        }

        public IActionResult Index(int page, string sortOrder, GamesItem.GameGenre? gamesGenre)
        {
            //var games = _gamesRepository.GetAllGames();
            var games = _gamesService.GetAllGames();
            games = sortOrder switch
            {
                "title__ascending" => games.OrderBy(x => x.Name).ToList(),
                "title__descending" => games.OrderByDescending(x => x.Name).ToList(),
                _ => games.OrderBy(x => x.Name).ToList()
            };

            if (gamesGenre != null)
            {
                games = games.Where(x => x.Genre == gamesGenre).ToList();
            }

            int pageSize = 4;
            int totalGames = games.Count;
            var pagesGames = games.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewmodel = new GamesListViewModel
            {
                gamesItems = pagesGames,
                CurrentGenre = gamesGenre,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalGames / pageSize)
            };
            TempData["message"] = "Игра удалена!";
            return View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult Create(GamesItem games)
        {
            if (!ModelState.IsValid)
            {
                return View(games);
            }
            _gamesRepository.AddGames(games);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var games = _gamesRepository.GetByIdGames(id);
            if (games == null)
            {
                return NotFound();
            }
            _gamesRepository.DeleteGames(games.ID);
            TempData["message"] = "Игра удалена!";
            return RedirectToAction("Index");
        }
        //public IActionResult Edit(int id)
        //{
        //    var games = _gamesRepository.GetByIdGames(id);
        //    return View(games);
        //}
        [HttpPost]
        public IActionResult Edit(GamesItem games)
        {
            if (!ModelState.IsValid)
            {
                return View(games);
            }
            _gamesRepository.UpdateGames(games);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
