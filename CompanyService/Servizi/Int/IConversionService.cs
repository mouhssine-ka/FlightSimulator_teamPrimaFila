namespace CompanyService;

public interface IConversionService
{
    AereoApi ConvertAereoToAereoApi(Aereo aereo);
    FlottaApi ConvertFlottaToFlottaApi(Flotta flotta, List<AereoApi> aerei);
}
