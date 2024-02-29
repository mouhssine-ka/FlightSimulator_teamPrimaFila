namespace CompanyService;

public class Volo
{
    public string IdVolo { get; set; }
    public Aereo Aereo { get; set; }
    public long PostiRimanenti { get; set; }
    public decimal CostoDelPosto { get; set; }
    public string CittaPartenza { get; set; }
    public string CittaArrivo { get; set; }
    public DateTime OrarioPartenza { get; set; }
    public DateTime OrarioArrivo { get; set; }

    public Volo(string idVolo, Aereo aereo, long postiRimanenti, decimal costroDelPorsto,
     string cittaPartenza, string cittaArrivo, DateTime orarioPartenza, DateTime orarioArrivo)
    {
        IdVolo = idVolo;
        Aereo = aereo;
        PostiRimanenti = postiRimanenti;
        CostoDelPosto = costroDelPorsto;
        CittaPartenza = cittaPartenza;
        CittaArrivo = cittaArrivo;
        OrarioPartenza = orarioPartenza;
        OrarioArrivo = orarioArrivo;
        
    }
}
