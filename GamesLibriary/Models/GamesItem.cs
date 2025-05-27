using System.ComponentModel.DataAnnotations;

namespace GamesLibriary.Models
{
    public class GamesItem
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Publication { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        public enum GameGenre
        {
            Action,
            Adventure,
            RolePlaying,
            Simulation,
            Strategy,
            Sports,
            Puzzle,
            Racing,
            Fighting,
            Horror,
            Stealth
        }
        [Required]
        public string ImageUrl { get; set; }
    }
}
