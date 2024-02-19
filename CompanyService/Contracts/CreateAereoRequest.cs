namespace CompanyService;

public class CreateAereoRequest
{
    public long IdFLotta {get; set;}
    public string CodiceAereo { get; set; }
    public string Colore { get; set; }
    public long NumeroDiPosti { get; set; }
    
    public CreateAereoRequest(long idFLotta, string codiceAereo, string colore, long numeroDiPosti)
    {        
        IdFLotta = idFLotta;
        CodiceAereo = codiceAereo;
        Colore = colore;
        NumeroDiPosti = numeroDiPosti;
    }
}
