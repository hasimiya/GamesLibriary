using System.Collections.Generic;

namespace GamesLibriary.Models
{
    public interface IGamesService
    {
        List<GamesItem> GetAllGames();
        void SaveToFile();
    }
}
