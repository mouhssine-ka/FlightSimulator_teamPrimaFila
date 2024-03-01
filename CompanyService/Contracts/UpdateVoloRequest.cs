namespace CompanyService;

public class UpdateVoloRequest
{
    public long VoloId {get; set;}
    public long AereoId { get; set; }
    public decimal CostoDelPosto { get; set; }
    public string CittaPartenza {get; set;}
    public string CittaArrivo {get; set;}
    public long Posti {get; set;}
    public DateTime OrarioPartenza { get; set; }
    public DateTime OrarioArrivo { get; set; }

    
    public UpdateVoloRequest(long voloId, long aereoId, decimal costoDelPosto,
     string cittaPartenza, string cittaArrivo, DateTime orarioPartenza, DateTime orarioArrivo)
    {    
        VoloId = voloId;
        AereoId = aereoId;
        CostoDelPosto = costoDelPosto;
        CittaPartenza = cittaPartenza;
        CittaArrivo = cittaArrivo;
        OrarioPartenza = orarioPartenza;
        OrarioArrivo = orarioArrivo;
    }
}
