namespace CompanyService;

public interface IDatabaseService
{
    Task<Aereo?> GetAereoDaIdAereo(long idAereo);

    Task<Flotta?> GetFlottaByIdFlotta(long idFlotta);

    Task<Aereo> AddAereoAFlotta(long idFlotta, string codiceAereo,
    string colore, long numeroPosti);

    Task DeleteAereoDaIdAereo(long idAereo);

    Task<Aereo?> UpdateAereoByIdAereo(long idAereo, string codiceAereo, string colore, long numeroDiPosti);

    Task<List<Flotta>> GetElencoFlotte();

    Task<Flotta> CreateFlotta(string nome);
}
