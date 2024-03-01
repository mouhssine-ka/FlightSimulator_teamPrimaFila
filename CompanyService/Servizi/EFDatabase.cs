
using System.IO.Compression;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Volo?> GetVoloByID(long idVolo)
    {
        var volo = await _context.Voli.Where(x => x.VoloId == idVolo).Include(a=> a.Aereo).FirstOrDefaultAsync();
        return volo;
    }

    public async Task DeleteVoloByID(long idVolo)
    {
        var volo = await GetVoloByID(idVolo);
        if (volo != null)
        {
            _context.Voli.Remove(volo);
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task<Volo> AddVolo(long aereoId, decimal costoDelPosto, string cittaPartenza, string cittaArrivo, DateTime orarioPartenza, DateTime orarioArrivo)
    {
        Aereo? aereo = await _context.Aerei.FirstOrDefaultAsync(x=>x.AereoId == aereoId);
        if(aereo == null){
            return null;
        }
        Volo v = new Volo(aereo, aereo.NumeroDiPosti, costoDelPosto, cittaPartenza, cittaArrivo, orarioPartenza, orarioArrivo);
        await _context.Voli.AddAsync(v);
        await _context.SaveChangesAsync();
        return v;
    }
    public async Task<List<Biglietto>> GetElencoBiglietti(){
        var biglietti = await _context.Biglietti.Include(b=> b.Volo).ToListAsync();
        return biglietti;
    }
    public async Task<List<Volo>> GetElencoVoli(){
        var voli = await _context.Voli.Include(a => a.Aereo).ToListAsync();
        return voli;
    }


    public async Task<Biglietto?> GetBigliettoByID(long idBiglietto)
    {
           var biglietto = await _context.Biglietti.Where(x => x.BigliettoId == idBiglietto).Include(b => b.Volo)
           .ThenInclude(a => a.Aereo).FirstOrDefaultAsync();
           return biglietto;
    }

    public async Task<Biglietto> AddBiglietto(Volo volo, int postiPrenotati)
    {
        var importoTotale = postiPrenotati * volo.CostoDelPosto;
        Biglietto b = new Biglietto(volo, postiPrenotati, importoTotale, DateTime.Now);
        await _context.Biglietti.AddAsync(b);
        await _context.SaveChangesAsync();
        return b;
    }


    public async Task DeleteBigliettoByID(long idBiglietto)
    {
        var biglietto = await GetBigliettoByID(idBiglietto);
        if (biglietto != null)
        {
            _context.Biglietti.Remove(biglietto);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Volo> UpdateVoloById(UpdateVoloRequest volo)
    {
        Volo? voloTrovato = await GetVoloByID(volo.VoloId);
    
        voloTrovato.Aereo.AereoId = volo.AereoId;
        voloTrovato.PostiRimanenti = volo.Posti;
        voloTrovato.CostoDelPosto = volo.CostoDelPosto;
        voloTrovato.CittaPartenza = volo.CittaPartenza;
        voloTrovato.CittaArrivo = volo.CittaArrivo;
        voloTrovato.OrarioPartenza = volo.OrarioPartenza;
        voloTrovato.OrarioArrivo= volo.OrarioArrivo;

        await _context.SaveChangesAsync();
        return voloTrovato;

    }
}