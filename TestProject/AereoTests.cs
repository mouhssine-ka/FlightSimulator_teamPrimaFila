using CompanyService;

namespace TestProject;

public class AereoTests
{
    [Fact]
    public void VerificaInizializzazioneId()
    {
        // ARRANGE
        int idAreeo = 1;
        string codiceAereo = "ABCDEF";
        string colore = "Rosso";
        long numeroDiPosti = 120;
        long flottaId = 100000;

        // ACT
        var aereo = new Aereo(idAreeo, flottaId, codiceAereo, colore, numeroDiPosti );

        // ASSERT
        Assert.Equal(idAreeo, aereo.AereoId);
        Assert.Equal(codiceAereo, aereo.CodiceAereo);
    }
}
