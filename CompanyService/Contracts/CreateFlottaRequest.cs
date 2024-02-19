namespace CompanyService;

public class CreateFlottaRequest
{
   public string Nome {get; set;}
    
    public CreateFlottaRequest(string nome)
    {        
        Nome = nome;  
    }
}
