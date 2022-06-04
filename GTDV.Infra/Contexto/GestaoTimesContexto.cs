using GestaoDeTimes.Entidades;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace GestaoDeTimes.Context
{
    public class GestaoTimesContexto : DbContext
    {
        public GestaoTimesContexto(DbContextOptions<GestaoTimesContexto> options) : base(options)
        { }

        public DbSet<Jogador> Jogador { get; set; }
    }
}
