namespace CompanyService;

public class VoloApi
{
    public long IdVolo { get; set; }
    public Aereo Aereo { get; set; }
    public long PostiRimanenti { get; set; }
    public decimal CostoDelPosto { get; set; }
    public string CittaPartenza { get; set; }
    public string CittaArrivo { get; set; }
    public DateTime OrarioPartenza { get; set; }
    public DateTime OrarioArrivo { get; set; }
    public List<Biglietto> Biglietti = new List<Biglietto>();

    public VoloApi(long idVolo, Aereo aereo, long postiRimanenti, decimal costoDelPosto,
    string cittaPartenza, string cittaArrivo, DateTime orarioPartenza, DateTime orarioArrivo,List<Biglietto> biglietti )
    {
        IdVolo = idVolo;
        Aereo = aereo;
        PostiRimanenti = postiRimanenti;
        CostoDelPosto = costoDelPosto;
        CittaPartenza = cittaPartenza;
        CittaArrivo = cittaArrivo;
        OrarioPartenza = orarioPartenza;
        OrarioArrivo = orarioArrivo;
        Biglietti=biglietti;

    }
}
