namespace CompanyService;

public class Biglietto
{
    public int BigliettoId {get; set;}
    public Volo Volo {get; set;}
    public int PostiPrenotati {get; set;}
    public decimal ImportoTotale {get; set;}
    public DateTime DataAcquisto {get; set;}

    public Biglietto(){
        
    }
    public Biglietto(int bigliettoId, Volo volo, int postiPrenotati, decimal importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        Volo = volo;
        PostiPrenotati = postiPrenotati;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
    public Biglietto(Volo volo, int postiPrenotati, decimal importoTotale, DateTime dataAcquisto)
    {
        Volo = volo;
        PostiPrenotati = postiPrenotati;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
}
