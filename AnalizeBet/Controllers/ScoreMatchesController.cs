using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalizeBet.Data;
using AnalizeBet.Models;
using AnalizeBet.Services.Repositories;
using AnalizeBet.Services.Repositories.Basic;
using AnalizeBet.Models.Authorization.UnLocal.MyScore;

namespace AnalizeBet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreMatchesController : ControllerBase
    {
        private readonly ScoresContext _context;
        private readonly ScoreRepository<ScoreMatches> repository;

        public ScoreMatchesController(ScoresContext context,   ScoreRepository<ScoreMatches> _repository)
        {
            _context = context;
            repository = _repository;
        }

        // GET: api/ScoreMatches
        [HttpGet]
        public IEnumerable<ScoreMatches> GetScores([FromRoute] MyScoreRequest msc)
        {
            if(msc.href.Contains("www.myscore.com.ua")||msc.href.Contains("www.myscore.com.ru")){
                repository.GetScores(msc );
            }
            return _context.Scores;
        }

        // GET: api/ScoreMatches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScoreMatches([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scoreMatches = await _context.Scores.FindAsync(id);

            if (scoreMatches == null)
            {
                return NotFound();
            }

            return Ok(scoreMatches);
        }

        // PUT: api/ScoreMatches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScoreMatches([FromRoute] string id, [FromBody] ScoreMatches scoreMatches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scoreMatches.ID)
            {
                return BadRequest();
            }

            _context.Entry(scoreMatches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreMatchesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ScoreMatches
        [HttpPost]
        public async Task<IActionResult> PostScoreMatches([FromBody] ScoreMatches scoreMatches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Scores.Add(scoreMatches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScoreMatches", new { id = scoreMatches.ID }, scoreMatches);
        }

        // DELETE: api/ScoreMatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreMatches([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scoreMatches = await _context.Scores.FindAsync(id);
            if (scoreMatches == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(scoreMatches);
            await _context.SaveChangesAsync();

            return Ok(scoreMatches);
        }

        private bool ScoreMatchesExists(string id)
        {
            return _context.Scores.Any(e => e.ID == id);
        }
    }
}