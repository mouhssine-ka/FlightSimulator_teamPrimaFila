namespace CompanyService;

public class CreateBigliettoRequest
{
    public long IdVolo {get; set;}
    public int PostiPrenotati {get; set;}

    public CreateBigliettoRequest(long idVolo,int postiPrenotati)
    {       
        IdVolo = idVolo;
        PostiPrenotati = postiPrenotati;
    }
}