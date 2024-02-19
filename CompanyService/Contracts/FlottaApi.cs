namespace CompanyService;

public class FlottaApi
{
    public long IdFlotta { get; set; }
    public string Nome {get; set;}
    public List<AereoApi> Aerei { get; set; }

    public FlottaApi(long idFlotta, List<AereoApi> aerei, string nome)
    {
        IdFlotta = idFlotta;
        Aerei = aerei;
        Nome = nome;           
    }

    public static FlottaApi FlottaApiFactory(long idFlotta, List<AereoApi> aerei, string nome)
    {
        return new FlottaApi(idFlotta, aerei, nome);
    }
}
