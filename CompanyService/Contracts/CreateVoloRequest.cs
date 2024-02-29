namespace CompanyService;

public class CreateVoloRequest
{
    public Aereo Aereo { get; set; }
    public long PostiRimanenti { get; set; }
    public decimal CostoDelPosto { get; set; }
    public string CittaPartenza { get; set; }
    public string CittaArrivo { get; set; }
    public DateTime OrarioPartenza { get; set; }
    public DateTime OrarioArrivo { get; set; }

    
    public CreateVoloRequest(Aereo aereo, long postiRimanenti, decimal costoDelPosto,
     string cittaPartenza, string cittaArrivo, DateTime orarioPartenza, DateTime orarioArrivo)
    {    
        
       
        Aereo = aereo;
        PostiRimanenti = postiRimanenti;
        CostoDelPosto = costoDelPosto;
        CittaPartenza = cittaPartenza;
        CittaArrivo = cittaArrivo;
        OrarioPartenza = orarioPartenza;
        OrarioArrivo = orarioArrivo;
    }
}
