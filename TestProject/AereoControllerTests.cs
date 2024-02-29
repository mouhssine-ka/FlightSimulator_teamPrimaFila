using System.Net;
using AirRouteAdministrator.API;
using CompanyService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject;

public class AereoControllerTests{
   
    [Fact]  
    public async void GetAereo_RecuperoUnAereo_RitornoUnAereo(){
        
        // ARRANGE
        var database = new Mock<IDatabaseService>();
        database.Setup(x => x.GetAereoDaIdAereo(It.IsAny<long>())).ReturnsAsync(new Aereo(1, 10000, "Codice", "Colore", 50));
        var _aereoController = new AereoController(database.Object);
        long idAereo = 1;

        // ACT
        var result = await _aereoController.Get(idAereo) as ObjectResult;

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }
 
    [Fact]  
    public async void PostAereo_CreoUnAereo_AereoCreato(){
        
        // ARRANGE
        var database = new Mock<IDatabaseService>();
        database.Setup(x => x.GetFlottaByIdFlotta(It.IsAny<long>())).ReturnsAsync(new Flotta(1, "FLOTTA 1", new List<Aereo>()));
        database.Setup(x => x.AddAereoAFlotta(It.IsAny<long>(), It.IsAny<string>(),It.IsAny<string>(),It.IsAny<long>())).ReturnsAsync(new Aereo(1,10000, "MONTI", "ASADADADA", 100));

        var _aereoController = new AereoController(database.Object);
        CreateAereoRequest createAereoRequest = new CreateAereoRequest(10000,
        "MONTI", "ASADADADA", 100);

        // ACT
        // POST
        var result = await _aereoController.Post(createAereoRequest) as ObjectResult;

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]  
    public async void PostAereo_CreoUnAereo_AereoTrovatoEVerificato(){
        
        // ARRANGE
         var database = new Mock<IDatabaseService>();
        database.Setup(x => x.GetAereoDaIdAereo(It.IsAny<long>())).ReturnsAsync(new Aereo(1, 10000,"MONTI", "ASADADADA", 100));
         database.Setup(x => x.GetFlottaByIdFlotta(It.IsAny<long>())).ReturnsAsync(new Flotta(1, "FLOTTA 1", new List<Aereo>()));
        database.Setup(x => x.AddAereoAFlotta(It.IsAny<long>(), It.IsAny<string>(),It.IsAny<string>(),It.IsAny<long>())).ReturnsAsync(new Aereo(1, 10000,"MONTI", "ASADADADA", 100));
        
        var _aereoController = new AereoController(database.Object);
        CreateAereoRequest createAereoRequest = new CreateAereoRequest(10000,
        "MONTI", "ASADADADA", 100);

        // ACT
        // POST
        var result = await _aereoController.Post(createAereoRequest) as ObjectResult;

        // ASSERT
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        
        AereoApi a = (AereoApi)result.Value;
        var resultGet = await _aereoController.Get(a.IdAereo) as ObjectResult;
        Assert.NotNull(resultGet);
        Assert.NotNull(resultGet.Value);

        AereoApi b = (AereoApi)resultGet.Value;
        Assert.Equal(a.CodiceAereo, b.CodiceAereo);
        Assert.Equal(a.Colore, b.Colore);
        Assert.Equal(a.NumeroDiPosti, b.NumeroDiPosti);

    }
}