using Microsoft.EntityFrameworkCore;

namespace CompanyService;

public class FlightSimulatorDBContext : DbContext
{
    public DbSet<Aereo> Aerei { get; set; }   
    public DbSet<Flotta> Flotte { get; set; }
    public DbSet<Crew> Crews { get; set; }
    public DbSet<Volo> Voli {get; set;}

    public FlightSimulatorDBContext(DbContextOptions<FlightSimulatorDBContext> options) : base(options)
    {

    }
}
