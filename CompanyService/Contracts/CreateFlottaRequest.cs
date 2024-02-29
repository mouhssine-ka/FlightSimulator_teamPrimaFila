namespace CompanyService;

public class CreateFlottaRequest
{
    public string NomeFlotta { get; set; }

    public CreateFlottaRequest()
    {        
       
    }

    public CreateFlottaRequest(string nomeFlotta)
    {
        NomeFlotta = nomeFlotta;
    }
}
