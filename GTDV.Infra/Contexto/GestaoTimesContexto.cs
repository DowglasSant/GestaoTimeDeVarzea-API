using GestaoDeTimes.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace GestaoDeTimes.Context
{
    public class GestaoTimesContexto : IdentityDbContext
    {
        public GestaoTimesContexto(DbContextOptions<GestaoTimesContexto> options) : base(options)
        { }

        public DbSet<Jogador> Jogador { get; set; }
    }
}
