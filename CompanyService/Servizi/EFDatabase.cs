
using Microsoft.EntityFrameworkCore;

namespace CompanyService;

public class EFDatabase : IDatabaseService
{
    private FlightSimulatorDBContext _context;
    public EFDatabase(FlightSimulatorDBContext context)
    {
        _context = context;
    }

    public async Task<Aereo> AddAereoAFlotta(long idFlotta, string codiceAereo, string colore, long numeroPosti)
    {
        Aereo a = new Aereo(idFlotta, codiceAereo, colore, numeroPosti);
        await _context.Aerei.AddAsync(a);
        await _context.SaveChangesAsync();
        return a;
    }

    public async Task<Flotta> CreateFlotta(string nome)
    {
        Flotta f = Flotta.FlottaFactory(nome);
        await _context.Flotte.AddAsync(f);
        await _context.SaveChangesAsync();

        return await GetFlottaByIdFlotta(f.FlottaId);
    }

    public async Task DeleteAereoDaIdAereo(long idAereo)
    {
        var aereo = await GetAereoDaIdAereo(idAereo);
        if (aereo != null)
        {
            _context.Aerei.Remove(aereo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Aereo?> GetAereoDaIdAereo(long idAereo)
    {
        return await _context.Aerei.FirstOrDefaultAsync(
            x => x.AereoId == idAereo
        );
    }

    public async Task<List<Flotta>> GetElencoFlotte()
    {
        return await _context.Flotte
        .Include(b => b.Aerei).ToListAsync();
    }

    public async Task<Flotta?> GetFlottaByIdFlotta(long idFlotta)
    {
        return await _context.Flotte.Where(
           x => x.FlottaId == idFlotta
       )
       .Include(b => b.Aerei)
       .FirstOrDefaultAsync();
    }

    public async Task<Aereo?> UpdateAereoByIdAereo(long idAereo, string codiceAereo, string colore, long numeroDiPosti)
    {
        var aereo = await GetAereoDaIdAereo(idAereo);
        if (aereo != null)
        {
            aereo.UpdateInformazioniAereo(codiceAereo, colore, numeroDiPosti);
            await _context.SaveChangesAsync();
        }           
        return aereo;
    }
}
