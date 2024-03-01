namespace CompanyService;

public class CreateVoloRequest
{
    public long AereoId { get; set; }
    public decimal CostoDelPosto { get; set; }
    public string CittaPartenza { get; set; }
    public string CittaArrivo { get; set; }
    public DateTime OrarioPartenza { get; set; }
    public DateTime OrarioArrivo { get; set; }

    
    public CreateVoloRequest(long aereoId, decimal costoDelPosto,
     string cittaPartenza, string cittaArrivo, DateTime orarioPartenza, DateTime orarioArrivo)
    {    
        AereoId = aereoId;
        CostoDelPosto = costoDelPosto;
        CittaPartenza = cittaPartenza;
        CittaArrivo = cittaArrivo;
        OrarioPartenza = orarioPartenza;
        OrarioArrivo = orarioArrivo;
    }
}
