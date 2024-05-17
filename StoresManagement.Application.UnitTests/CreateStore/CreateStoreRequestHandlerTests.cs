using Bogus;
using Moq;
using Moq.AutoMock;
using StoresManagement.Application.Stores.Create;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Application.UnitTests.CreateStore;

public class CreateStoreRequestHandlerTests
{
    private readonly AutoMocker _autoMocker;

    public CreateStoreRequestHandlerTests()
        => _autoMocker = new AutoMocker();

    [Fact(DisplayName = "With invalid data")]
    public async Task Handle_WhenProvidedWithInvalidData_ShouldReturnError()
    {
        //Arrange
        var request = new CreateStoreRequest(default, default, default);

        //Act
        var result = await GetHandler().Handle(request, CancellationToken.None);

        //Assert
        Assert.True(result.IsFailed);
        Assert.Collection(result.Errors,
            error => Assert.Equal("'Company Id' must not be empty.", error.Message),
            error => Assert.Equal("'Name' must not be empty.", error.Message),
            error => Assert.Equal("'Address' must not be empty.", error.Message));

        _autoMocker.GetMock<IRepository<Company>>().Verify(e => e.FindAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never);
        _autoMocker.GetMock<IRepository<Store>>().Verify(e => e.AddAsync(It.IsAny<Store>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact(DisplayName = "With invalid store address")]
    public async Task Handle_WhenProvidedWithInvalidStoreAddress_ShouldReturnError()
    {
        //Arrange
        var faker = new Faker();
        var request = new CreateStoreRequest(Guid.NewGuid(), faker.Random.Word(),
            new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));

        //Act
        var result = await GetHandler().Handle(request, CancellationToken.None);

        //Assert
        Assert.True(result.IsFailed);
        Assert.Collection(result.Errors,
            error => Assert.Equal("'Street Name' must not be empty.", error.Message),
            error => Assert.Equal("'City Name' must not be empty.", error.Message),
            error => Assert.Equal("'Region Name' must not be empty.", error.Message),
            error => Assert.Equal("'Postal Code' must not be empty.", error.Message),
            error => Assert.Equal("'Country' must not be empty.", error.Message));

        _autoMocker.GetMock<IRepository<Company>>().Verify(e => e.FindAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never);
        _autoMocker.GetMock<IRepository<Store>>().Verify(e => e.AddAsync(It.IsAny<Store>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact(DisplayName = "When company doesn't exists")]
    public async Task Handle_WhenCompanyDoesntExists_ShouldReturnError()
    {
        //Arrange
        var faker = new Faker();
        var companyId = Guid.NewGuid();
        var request = new CreateStoreRequest(companyId, faker.Random.Word(), new Address
            (
                faker.Address.StreetName(),
                faker.Address.City(),
                faker.Address.State(),
                faker.Address.ZipCode(),
                faker.Address.Country()
            ));

        var cancellationToken = new CancellationToken();

        //Act
        var result = await GetHandler().Handle(request, cancellationToken);

        //Assert
        Assert.True(result.IsFailed);
        Assert.Equal("The company id provided doesn't match with any existent company.",
            Assert.Single(result.Errors).Message);

        _autoMocker.GetMock<IRepository<Company>>().Verify(e => e.Exists(companyId, cancellationToken), Times.Once);
        _autoMocker.GetMock<IRepository<Store>>().Verify(e => e.AddAsync(It.IsAny<Store>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact(DisplayName = "With valid data")]
    public async Task Handle_WithValidData_ShouldReturnSuccess()
    {
        //Arrange
        var faker = new Faker();
        var companyId = Guid.NewGuid();
        var request = new CreateStoreRequest(companyId, faker.Random.Word(), new Address
            (
                faker.Address.StreetName(),
                faker.Address.City(),
                faker.Address.State(),
                faker.Address.ZipCode(),
                faker.Address.Country()
            ));

        var cancellationToken = new CancellationToken();

        _autoMocker.GetMock<IRepository<Company>>().Setup(e => e.Exists(companyId, cancellationToken)).ReturnsAsync(true);

        //Act
        var result = await GetHandler().Handle(request, cancellationToken);

        //Assert
        Assert.True(result.IsSuccess);
        Assert.NotEqual(Guid.Empty, result.Value);

        _autoMocker.GetMock<IRepository<Company>>().Verify(e => e.Exists(companyId, cancellationToken), Times.Once);
        _autoMocker.GetMock<IRepository<Store>>().Verify(e => e.AddAsync(It.Is<Store>(e =>
                e.Id != Guid.Empty &&
                e.CompanyId == companyId &&
                e.Name == request.Name &&
                e.Address == request.Address), cancellationToken), Times.Once);
    }

    private CreateStoreRequestHandler GetHandler()
        => _autoMocker.CreateInstance<CreateStoreRequestHandler>();
}