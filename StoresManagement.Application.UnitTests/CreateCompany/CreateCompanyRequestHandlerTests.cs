using Bogus;
using Moq;
using Moq.AutoMock;
using StoresManagement.Application.CreateCompany;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.UnitTests.CreateCompany;

public class CreateCompanyRequestHandlerTests
{
    private readonly AutoMocker _autoMocker;

    public CreateCompanyRequestHandlerTests()
        => _autoMocker = new AutoMocker();

    [Fact(DisplayName = "Without name")]
    public async Task Handle_WhenProvidedWithoutName_ShouldReturnError()
    {
        //Arrange
        var request = new CreateCompanyRequest(default);

        //Act
        var result = await GetHandler().Handle(request, CancellationToken.None);

        //Assert
        Assert.True(result.IsFailed);
        Assert.Collection(result.Errors, error => Assert.Equal("'Name' must not be empty.", error.Message));
    }

    [Fact(DisplayName = "With invalid store")]
    public async Task Handle_WhenProvidedWithInvalidStore_ShouldReturnError()
    {
        //Arrange
        var faker = new Faker();
        var request = new CreateCompanyRequest(faker.Random.Word(),
            [
                new CreateStoreWithinCompanyDto
                (
                    default!, default!
                )
            ]);

        var cancellationToken = new CancellationToken();

        //Act
        var result = await GetHandler().Handle(request, cancellationToken);

        //Assert
        Assert.True(result.IsFailed);
        Assert.Collection(result.Errors,
            error => Assert.Equal("'Name' must not be empty.", error.Message),
            error => Assert.Equal("'Address' must not be empty.", error.Message));
    }

    [Fact(DisplayName = "With invalid store address")]
    public async Task Handle_WhenProvidedWithInvalidStoreAddress_ShouldReturnError()
    {
        //Arrange
        var faker = new Faker();
        var request = new CreateCompanyRequest(faker.Random.Word(),
            [
                new CreateStoreWithinCompanyDto
                (
                    faker.Random.Word(), new Domain.Models.ValuedObjects.Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
                )
            ]);

        var cancellationToken = new CancellationToken();

        //Act
        var result = await GetHandler().Handle(request, cancellationToken);

        //Assert
        Assert.True(result.IsFailed);
        Assert.Collection(result.Errors,
            error => Assert.Equal("'Street Name' must not be empty.", error.Message),
            error => Assert.Equal("'City Name' must not be empty.", error.Message),
            error => Assert.Equal("'Region Name' must not be empty.", error.Message),
            error => Assert.Equal("'Postal Code' must not be empty.", error.Message),
            error => Assert.Equal("'Country' must not be empty.", error.Message));
    }

    [Fact(DisplayName = "Without stores")]
    public async Task Handle_WhenProvidedWithoutStores_ShouldReturnSuccess()
    {
        //Arrange
        var request = new CreateCompanyRequest(new Faker().Random.Word());
        var cancellationToken = new CancellationToken();

        //Act
        var result = await GetHandler().Handle(request, cancellationToken);

        //Assert
        Assert.True(result.IsSuccess);

        _autoMocker.GetMock<ICompanyRepository>().Verify(e => e.CreateAsync(It.Is<Domain.Models.Entities.Company>
            (e => e.Id != Guid.Empty &&
                e.Name == request.Name &&
                e.Stores.Count == 0), cancellationToken), Times.Once);
    }

    [Fact(DisplayName = "With valid stores")]
    public async Task Handle_WhenProvidedWithValidStores_ShouldReturnSuccess()
    {
        //Arrange
        var faker = new Faker();
        var request = new CreateCompanyRequest(faker.Random.Word(),
            [
                new CreateStoreWithinCompanyDto
                (
                    faker.Random.Word(),
                    new Domain.Models.ValuedObjects.Address
                    (
                        faker.Address.StreetName(),
                        faker.Address.City(),
                        faker.Address.State(),
                        faker.Address.ZipCode(),
                        faker.Address.Country()
                    )
                )
            ]);

        var cancellationToken = new CancellationToken();

        //Act
        var result = await GetHandler().Handle(request, cancellationToken);

        //Assert
        Assert.True(result.IsSuccess);

        var storeRequest = request.Stores!.First();

        _autoMocker.GetMock<ICompanyRepository>().Verify(e => e.CreateAsync(It.Is<Domain.Models.Entities.Company>
            (e => e.Id != Guid.Empty &&
                e.Name == request.Name &&
                e.Stores.Count == 1 &&
                e.Stores.Count(x => x.Id != Guid.Empty &&
                    x.CompanyId == e.Id &&
                    x.Name == storeRequest.Name &&
                    x.Address == storeRequest.Address) == 1), cancellationToken), Times.Once);
    }

    private CreateCompanyRequestHandler GetHandler()
        => _autoMocker.CreateInstance<CreateCompanyRequestHandler>();
}