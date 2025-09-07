using System.Runtime.InteropServices;
using LighthouseSocialProject.Application.Contracts.Repositories;
using LighthouseSocialProject.Application.Dtos;
using LighthouseSocialProject.Application.Features.Lighthouse;
using LighthouseSocialProject.Domain.Entities;
using LighthouseSocialProject.Domain.Interfaces;
using Moq;
using Xunit;

namespace LighthouseSocialProject.Application.Tests.Features.Lighthouse;

public class CreateLighthouseHandlerTests
{
    private readonly Mock<ILighthouseRepository> _repositoryMock;
    private readonly Mock<ICountryDataReader> _countryDataReaderMock;
    private readonly CreateLighthouseHandler _handler;

    public CreateLighthouseHandlerTests()
    {
        _repositoryMock = new Mock<ILighthouseRepository>();
        _countryDataReaderMock = new Mock<ICountryDataReader>();
        _handler = new CreateLighthouseHandler(_repositoryMock.Object, _countryDataReaderMock.Object);
    }

    [Fact]
    public async Task HandleAsync_ShouldReturnSuccess_WhenInputIsValid()
    {
        var dto = new LighthouseDto(Guid.NewGuid(), "Roman Rock", 27, 34.10, 34.13);
        var country = new Country(27, "South Africa");

        _countryDataReaderMock.Setup(r => r.GetById(dto.CountryId)).Returns(country);

        var result = await _handler.HandleAsync(dto);
        
        Assert.True(result.Success);
        Assert.NotEqual(Guid.Empty, result.Data);
        
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Domain.Entities.Lighthouse>()), Times.Once);

    }

    [Fact]
    public async Task HandleAsync_ShouldReturnFail_WhenCountryIsNotFound()
    {
        var dto = new LighthouseDto(Guid.NewGuid(), "Green Point", 999, 0, 0);
        _countryDataReaderMock.Setup(r => r.GetById(It.IsAny<int>())).Throws(new Exception("Not Found"));
        
        var result = await _handler.HandleAsync(dto);
        
        Assert.False(result.Success);
        Assert.Contains("Invalid country", result.ErrorMessage);

    }
}