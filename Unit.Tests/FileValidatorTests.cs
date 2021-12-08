using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Moq;
using ShareMyPaper.Application.Validators;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests;
public class FileValidatorTests
{

    [Fact]
    public async Task ShoudThrowValidationExceptionIfFileExceeds5MB()
    {
        //Arrange
        var fileMock = new Mock<IFormFile>();
        var validator = new FileValidator();
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(5000001);
        fileMock.Setup(_ => _.ContentType).Returns("application/pdf");
        // Act
        var result = await validator.TestValidateAsync(fileMock.Object);

        // Assert

        result.ShouldHaveValidationErrorFor(file => file.Length).WithErrorMessage("File size can't be greater than 5MB");
    }
    [Fact]
    public async Task ShoudThrowValidationExceptionIfFileTypeIsNotImageNorPdf()
    {
        //Arrange
        var fileMock = new Mock<IFormFile>();
        var validator = new FileValidator();
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(5000001);
        fileMock.Setup(_ => _.ContentType).Returns("application/zip");
        // Act
        var result = await validator.TestValidateAsync(fileMock.Object);

        // Assert

        result.ShouldHaveValidationErrorFor(file => file.ContentType).WithErrorMessage("File type is not allowed, use .jpg, .jpeg or .pdf instead");
        result.ShouldHaveValidationErrorFor(file => file.Length).WithErrorMessage("File size can't be greater than 5MB");
    }
    [Theory]
    [InlineData("application/pdf")]
    [InlineData("image/jpg")]
    [InlineData("image/jpeg")]
    [InlineData("image/png")]
    public async Task ShouldPassValidationIfContentTypeIsPdfOrImage(string contentType)
    {
        //Arrange
        var fileMock = new Mock<IFormFile>();
        var validator = new FileValidator();
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(40000);
        fileMock.Setup(_ => _.ContentType).Returns(contentType);
        // Act
        var result = await validator.TestValidateAsync(fileMock.Object);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
