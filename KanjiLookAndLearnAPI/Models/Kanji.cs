using System.ComponentModel.DataAnnotations;

namespace KanjiLookAndLearnAPI.Models
{
    public class Kanji
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Word { get; set; }
        [Required]
        public string Meaning { get; set; }
    }
}
