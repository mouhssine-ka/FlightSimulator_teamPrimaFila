using System.Security.Principal;

namespace CompanyService;

public class Flotta
{
    public long FlottaId { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<Aereo> Aerei { get; set; }

    public Flotta()
    {

    } 

    public Flotta(long idFLotta, string nome, List<Aereo> aerei)
    {
        FlottaId = idFLotta;
        Nome = nome;
        Aerei = aerei;
    }

    public static Flotta FlottaFactory(string nome)
    {
        return new Flotta(0, nome, new List<Aereo>());
    }

    public Aereo? GetAereoById(long idAereo)
    {
        foreach (var aereo in Aerei)
        {
            if (aereo.AereoId == idAereo)
            {
                return aereo;
            }
        }

        return null;
    }

}
