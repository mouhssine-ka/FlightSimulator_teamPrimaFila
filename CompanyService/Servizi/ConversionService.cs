namespace CompanyService;

public class ConversionService : IConversionService
{
    public AereoApi ConvertAereoToAereoApi(Aereo aereo)
    {
        var a = new AereoApi(aereo.AereoId, aereo.CodiceAereo, aereo.Colore, aereo.NumeroDiPosti);
        return a;
    }

    public FlottaApi ConvertFlottaToFlottaApi(Flotta flotta, List<AereoApi> aerei)
    {
        var f = new FlottaApi(flotta.FlottaId, flotta.Nome, aerei);
        return f;
    }
}
