namespace CompanyService;

public class BigliettoApi
{
    public int BigliettoId {get; set;}
    public Volo Volo {get; set;}
    public int PostiPrenotati {get; set;}
    public decimal ImportoTotale {get; set;}
    public DateTime DataAcquisto {get; set;}
    public BigliettoApi(int bigliettoId, Volo volo, int postiPrenotati, decimal importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        Volo = volo;
        PostiPrenotati = postiPrenotati;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
}