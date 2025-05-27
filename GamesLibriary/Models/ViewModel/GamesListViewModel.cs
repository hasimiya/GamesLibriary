using System.Collections.Generic;

namespace GamesLibriary.Models.ViewModel
{
    public class GamesListViewModel
    {
        public List<GamesItem> gamesItems;
        public GamesItem.GameGenre? CurrentGenre;
        public int TotalPages;
        public int CurrentPage;
    }
}
