namespace CompanyService;

public class CreateBigliettoRequest
{
    public long IdVolo {get; set;}
    public int PostiPrenotati {get; set;}

    // public int BigliettoId {get; set;}
    // public double ImportoTotale {get; set;}
    // public DateTime DataAcquisto {get; set;}

    public CreateBigliettoRequest(long idVolo,int postiPrenotai)
    {        
        IdVolo = idVolo;
        PostiPrenotati = postiPrenotai;
    }

    // public CreateBigliettoRequest(int bigliettoId, Volo volo, int postiPrenotati, double importoTotale, DateTime dataAcquisto)
    // {
    //     BigliettoId = bigliettoId;
    //     Volo = volo;
    //     PostiPrenotati = postiPrenotati;
    //     ImportoTotale = importoTotale;
    //     DataAcquisto = dataAcquisto;
    // }
}