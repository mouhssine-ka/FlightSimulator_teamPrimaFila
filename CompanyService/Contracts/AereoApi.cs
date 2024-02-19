namespace CompanyService;

public class AereoApi
{
    public long IdAereo { get; set; }
    public string CodiceAereo { get; set; }
    public string Colore { get; set; }
    public long NumeroDiPosti { get; set; }

    public AereoApi(long idAereo, string codiceAereo, string colore, long numeroDiPosti)
    {
        IdAereo = idAereo;
        CodiceAereo = codiceAereo;
        Colore = colore;
        NumeroDiPosti = numeroDiPosti;
    }
}
