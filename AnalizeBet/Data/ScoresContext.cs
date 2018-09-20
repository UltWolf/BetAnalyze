using AnalizeBet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Data
{
    public class ScoresContext:DbContext
    {
        public ScoresContext(DbContextOptions<ScoresContext> options):base(options) {
        }
        public ScoresContext() { }
        
        public DbSet<ScoreMatches> Scores { get; set; }
    }
}
