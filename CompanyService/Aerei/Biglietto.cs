namespace CompanyService;

public class Biglietto
{
    public int BigliettoId {get; set;}
    public Volo Volo {get; set;}
    public int PostiPrenotati {get; set;}
    public double ImportoTotale {get; set;}
    public DateTime DataAcquisto {get; set;}

    public Biglietto(int bigliettoId, Volo volo, int postiPrenotati, double importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        Volo = volo;
        PostiPrenotati = postiPrenotati;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }
    public Biglietto(Volo volo, int postiPrenotati)
    {
        Volo = volo;
        PostiPrenotati = postiPrenotati;
    }
}
