using CompanyService;

namespace TestProject;

public class FlottaTests
{
    [Fact]
    public void VerificareCheDatoUnidRitorniUnsoloAereo(){
        
        // ARRANGE
        var aereo1 = new Aereo(1, 1, "ABCDEF1", "Rosso", 120);
        var aereo2 = new Aereo(2, 1, "ABCDEF2", "Rosso", 120);
        var aereo3 = new Aereo(3, 1, "ABCDEF3", "Rosso", 120);

        List<Aereo> lista = new List<Aereo>();
        lista.Add(aereo1);
        lista.Add(aereo2);
        lista.Add(aereo3);

        Flotta f = new Flotta(1, "FLOTTA 1", lista);

        // ACT
        var aereo = f.GetAereoById(aereo1.AereoId);

        // ASSERT
        Assert.NotNull(aereo);         
        Assert.Equal(aereo1.AereoId, aereo.AereoId);
        Assert.Equal(aereo1.CodiceAereo, aereo.CodiceAereo);       
    }

    [Fact]
    public void VerificareCheDatoUnidRitorniNullSelAereoNonEsiste(){
        
          
        // ARRANGE
        var aereo1 = new Aereo(1, 1, "ABCDEF1", "Rosso", 120);
        var aereo2 = new Aereo(2, 1,"ABCDEF2", "Rosso", 120);
        var aereo3 = new Aereo(3, 1,"ABCDEF3", "Rosso", 120);

        List<Aereo> lista = new List<Aereo>();
        lista.Add(aereo1);
        lista.Add(aereo2);
        lista.Add(aereo3);

        Flotta f = new Flotta(1, "FLOTTA 1", lista);

        int idAereoNonEsistente = 10;

        // ACT
        var aereo = f.GetAereoById(idAereoNonEsistente);

        // ASSERT
        Assert.Null(aereo);         
    }
}
