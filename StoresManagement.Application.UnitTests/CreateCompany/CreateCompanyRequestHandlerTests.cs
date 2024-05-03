using Moq.AutoMock;
using StoresManagement.Application.CreateCompany;

namespace StoresManagement.Application.UnitTests.CreateCompany;

public class CreateCompanyRequestHandlerTests
{
    private readonly AutoMocker _autoMocker;

    public CreateCompanyRequestHandlerTests()
        => _autoMocker = new AutoMocker();

    [Fact]
    public async Task Handle_WhenProvidedWithoutName_ShouldReturnError()
    {
        //Arrange
        var request = new CreateCompanyRequest(default);

        //Act
        var result = await GetHandler().Handle(request, CancellationToken.None);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.True(result.IsFailed);
            Assert.Collection(result.Errors, error => Assert.Equal("", error.Message));
        });
    }

    private CreateCompanyRequestHandler GetHandler()
        => _autoMocker.CreateInstance<CreateCompanyRequestHandler>();
}