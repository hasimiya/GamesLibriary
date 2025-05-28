using System.Collections.Generic;

namespace GamesLibriary.Models
{
    public interface IGamesRepository
    {
        List<GamesItem> GetAllGames();
        void AddGames(GamesItem games);
        void DeleteGames(int id);
        GamesItem GetByIdGames(int id);
        void UpdateGames(GamesItem updatedGames);
    }
}
