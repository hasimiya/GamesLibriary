using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static GamesLibriary.Models.GamesItem;

namespace GamesLibriary.Models
{
    public class GamesRepository : IGamesRepository
    {
        public static List<GamesItem> listGames;
        private readonly IGamesService _gamesService;
        public GamesRepository(IGamesService gamesService)
        {
            _gamesService = gamesService;
            listGames = _gamesService.GetAllGames();
        }

        public void AddGames(GamesItem games)
        {
            int idMax = listGames.Any() ? listGames.Max(x => x.ID) : 0;
            games.ID = idMax + 1;
            listGames.Add(games);
            _gamesService.SaveToFile();
        }

        public void DeleteGames(int id)
        {
            var games = GetByIdGames(id);
            if (games != null)
            {
                listGames.Remove(games);
                _gamesService.SaveToFile();
            }
        }

        public List<GamesItem> GetAllGames()
        {
            return listGames;
        }

        public GamesItem GetByIdGames(int id)
        {
            return listGames.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateGames(GamesItem updatedGames)
        {
            var _games = GetByIdGames(updatedGames.ID);
            if (_games != null)
            {
                _games.Name = updatedGames.Name;
                _games.Description = updatedGames.Description;
                _games.ImageUrl = updatedGames.ImageUrl;
                _games.Genre = updatedGames.Genre;
                _games.Publication = updatedGames.Publication;
            }
            _gamesService.SaveToFile();
        }
    }
}
