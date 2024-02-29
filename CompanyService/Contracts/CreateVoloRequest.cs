namespace CompanyService;

public class CreateVoloRequest
{
    public long IdFLotta {get; set;}
    public string CodiceAereo { get; set; }
    public string Colore { get; set; }
    public long NumeroDiPosti { get; set; }
    
    public CreateVoloRequest(long idFLotta, string codiceAereo, string colore, long numeroDiPosti)
    {        
        IdFLotta = idFLotta;
        CodiceAereo = codiceAereo;
        Colore = colore;
        NumeroDiPosti = numeroDiPosti;
    }
}
