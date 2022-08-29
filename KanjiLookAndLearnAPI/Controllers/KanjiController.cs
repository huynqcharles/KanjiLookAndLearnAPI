using KanjiLookAndLearnAPI.Data;
using KanjiLookAndLearnAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanjiLookAndLearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanjiController : ControllerBase
    {
        private readonly KanjiDbContext _context;
        public KanjiController(KanjiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Kanji>> Get()
        {
            return await _context.Kanjis.ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Kanji), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var kanji = await _context.Kanjis.FindAsync(id);
            return kanji == null ? NotFound() : Ok(kanji);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Kanji kanji)
        {
            await _context.Kanjis.AddAsync(kanji);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = kanji.Id }, kanji);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Kanji kanji)
        {
            if (id != kanji.Id) return BadRequest();

            _context.Entry(kanji).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var kanjiToDelete = await _context.Kanjis.FindAsync(id);
            if (kanjiToDelete == null) return NotFound();

            _context.Kanjis.Remove(kanjiToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
