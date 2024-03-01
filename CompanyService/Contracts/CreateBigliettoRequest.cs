namespace CompanyService;

public class CreateBigliettoRequest
{
    public long IdVolo {get; set;}
    public int PostiDaPrenotare {get; set;}

    public CreateBigliettoRequest(long idVolo,int postiDaPrenotare)
    {       
        IdVolo = idVolo;
        PostiDaPrenotare = postiDaPrenotare;
    }
}