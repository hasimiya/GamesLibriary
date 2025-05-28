using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GamesLibriary.Models
{
    public class GamesService : IGamesService
    {
        private readonly string filePath = "GamesLibrary.json";
        private List<GamesItem> listGames;

        public GamesService()
        {
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
        public void SaveToFile()
        {
            string jsonstring = JsonSerializer.Serialize(listGames, new JsonSerializerOptions { WriteIndented = true });
            // Serialize - преобразование объектов в JSON-строку
            // WriteIndented - форматирование JSON-строки с отступами для лучшей читаемости

            File.WriteAllText(filePath, jsonstring); // File - запись в файл WriteAllText - запись строки в файл
        }
        public List<GamesItem> GetAllGames() => listGames;
    }
}
