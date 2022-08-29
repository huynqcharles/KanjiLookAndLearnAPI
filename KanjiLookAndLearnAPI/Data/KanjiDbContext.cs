using KanjiLookAndLearnAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KanjiLookAndLearnAPI.Data
{
    public class KanjiDbContext : DbContext
    {
        public KanjiDbContext(DbContextOptions<KanjiDbContext> options) : base(options)
        {

        }
        public DbSet<Kanji> Kanjis { get; set; }
    }
}
