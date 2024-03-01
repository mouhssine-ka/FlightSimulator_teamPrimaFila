namespace CompanyService;

public class BigliettoApi
{
    public int BigliettoId {get; set;}
    public Volo Volo {get; set;}
    public int PostiDaPrenotare {get; set;}
    public decimal ImportoTotale {get; set;}
    public DateTime DataAcquisto {get; set;}
    public BigliettoApi(int bigliettoId, Volo volo, int postiDaPrenotare, decimal importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        Volo = volo;
        PostiDaPrenotare = postiDaPrenotare;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
}