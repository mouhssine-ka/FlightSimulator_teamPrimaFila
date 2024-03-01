namespace CompanyService;

public class Biglietto
{
    public int BigliettoId {get; set;}
    public Volo Volo {get; set;}
    public int PostiDaPrenotare {get; set;}
    public decimal ImportoTotale {get; set;}
    public DateTime DataAcquisto {get; set;}

    public Biglietto(){
        
    }
    public Biglietto(int bigliettoId, Volo volo, int postiDaPrenotare, decimal importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        Volo = volo;
        PostiDaPrenotare = postiDaPrenotare;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
    public Biglietto(Volo volo, int postiDaPrenotare, decimal importoTotale, DateTime dataAcquisto)
    {
        Volo = volo;
        PostiDaPrenotare = postiDaPrenotare;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
}
