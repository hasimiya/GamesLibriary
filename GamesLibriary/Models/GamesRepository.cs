using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static GamesLibriary.Models.GamesItem;

namespace GamesLibriary.Models
{
    public class GamesRepository : IGamesRepository
    {
        public static List<GamesItem> listGames = new List<GamesItem>()
        {
            new GamesItem{ ID = 1, Name = "Gost Ot Thushima", Description = "Ghost of Tsushima — компьютерная игра в жанре action-adventure с открытым миром, разработанная " +
                "компанией Sucker Punch Productions. Издателем игры выступила Sony Interactive Entertainment.", ImageUrl = "~/images/Ghost_of_Tsushima.jpg",
            Genre = GameGenre.Stealth, Publication = 2020 },

            new GamesItem { ID = 2,  Name = "Grand Theft Auto III", Description = "Grand Theft Auto III — компьютерная игра в жанре action-adventure, разработанная компанией " +
                "DMA Design и выпущенная Rockstar Games. Это третья по счёту и первая трёхмерная игра в серии Grand Theft Auto.", ImageUrl = "~/images/GTA3.jpg",
            Genre = GameGenre.Action, Publication = 2001 },

            new GamesItem { ID = 3,  Name = "Detroit: Become Human", Description = "Detroit: Become Human — приключенческая компьютерная игра с элементами «интерактивного кино», разработанная " +
                "французской студией Quantic Dream и выпущенная компанией Sony Interactive Entertainment для PlayStation 4 в мае 2018 года; в декабре 2019 года игра " +
                "была перевыпущена на Windows. ", ImageUrl = "~/images/Detroit-Become-Human.webp", Genre = GameGenre.Strategy, Publication = 2018 },

            new GamesItem { ID = 4,  Name = "Max Payne", Description = "Max Payne — серия компьютерных игр в жанре шутера от третьего лица в стиле неонуар, разработанная " +
                "компаниями Remedy Entertainment и Rockstar Studios. Серия названа в честь главного героя, Макса Пэйна, полицейского детектива из Нью-Йорка, ставшего " +
                "мстителем после того, как его семья была убита наркоманами.", ImageUrl = "~/images/Max-Payne.jpg", Genre = GameGenre.Action, Publication = 2001 },

            new GamesItem { ID = 5,  Name="Grand Theft Auto Vice City", Description = "Grand Theft Auto: Vice City — компьютерная игра в жанре action-adventure от третьего лица, " +
                "разработанная британской студией Rockstar North и выпущенная американской студией Rockstar Games. Является четвёртой основной по счёту и второй " +
                "трёхмерной игрой из серии Grand Theft Auto.", ImageUrl = "~/images/GTA-Vice-City.jpg", Genre = GameGenre.Action, Publication = 2002 },

            new GamesItem { ID = 6,  Name= "Spider Man", Description = "Spider-Man — компьютерная игра 2000 года в жанре action-adventure, основанная на персонаже комиксов Marvel " +
                "Comics Человеке-пауке. Игра была разработана студией Neversoft и выпущенная Activision с использованием игрового движка Tony Hawk's Pro Skater для " +
                "PlayStation.", ImageUrl = "~/images/Spider-Man.jpg", Genre= GameGenre.Action, Publication= 2000 }
        };

        public static void GamesService()
        {
            string filePath = "GamesLibrary.json";

            if (File.Exists(filePath)) // File.Exists - проверка на существование файла                
            {
                string jsonString = File.ReadAllText(filePath); // File - чтение файла ReadAllText - чтение всего содержимого файла в строку
                listGames = JsonSerializer.Deserialize<List<GamesItem>>(jsonString); // JsonSerializer - десериализация JSON-строки в список объектов GamesItem
                // Deserialize - преобразование JSON-строки в объекты
            }
            else
            {
                listGames = new List<GamesItem>(); // или начальный список
            }
        }
        public static void SaveToFile()
        {
            string jsonstring = JsonSerializer.Serialize(listGames, new JsonSerializerOptions { WriteIndented = true });
            // Serialize - преобразование объектов в JSON-строку
            // WriteIndented - форматирование JSON-строки с отступами для лучшей читаемости

            File.WriteAllText("GamesLibrary.json", jsonstring); // File - запись в файл WriteAllText - запись строки в файл
        }

        public void AddGames(GamesItem games)
        {
            int idMax = listGames.Any() ? listGames.Max(x => x.ID) : 0;
            games.ID = idMax + 1;
            listGames.Add(games);
            SaveToFile();
        }

        public void DeleteGames(int id)
        {
            var games = GetByIdGames(id);
            if (games != null)
            {
                listGames.Remove(games);
                SaveToFile();
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
        }
    }
}
