namespace CompanyService;

public class FlottaApi
{
    public long IdFlotta { get; set; }
    public string Nome { get; set; }
    public List<AereoApi> Aerei { get; set; }

    public FlottaApi(long idFlotta, string nome, List<AereoApi> aerei)
    {
        IdFlotta = idFlotta;
        Nome = nome;
        Aerei = aerei;
    }

    public static FlottaApi FlottaApiFactory(long idFlotta, string nome, List<AereoApi> aerei)
    {
        return new FlottaApi(idFlotta, nome, aerei);
    }
}
