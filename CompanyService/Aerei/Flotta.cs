using System.Security.Principal;

namespace CompanyService;

public class Flotta
{
    public long FlottaId { get; set; }
    public string Nome {get; set;}
    public virtual ICollection<Aereo> Aerei { get; set; }

    public Flotta(string nome)
    {
        Nome = nome;
    } 

    public Flotta(long idFLotta, List<Aereo> aerei, string nome)
    {
        FlottaId = idFLotta;
        Aerei = aerei;
        Nome = nome;
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
