using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Moq;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Validators;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests;
public class PostDtoValidatorTests
{

    [Fact]
    public async Task ShouldReturnValidationErrorIfPostDocumentIsInvalid()
    {
        //Arrange
        var validator = new PostDTOValidator();

        var posDTO = new PostInputDTO()
        {
            Title = "This is a fale title",
            Text = "this is a fake text",
        };
        // Act
        var result = await validator.TestValidateAsync(posDTO);

        // Assert
        result.ShouldHaveValidationErrorFor(user => user.UploadedFile).WithErrorMessage("'Uploaded File' must not be empty.");
    }

    [Fact]
    public async Task ShouldReturnValidationErrorIfPostTitleIsEmpty()
    {
        // arrange
        var fileMock = new Mock<IFormFile>();
        var validator = new PostDTOValidator();
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
        fileMock.Setup(_ => _.Length).Returns(500000);
        fileMock.Setup(_ => _.ContentType).Returns("application/pdf");

        var posDTO = new PostInputDTO()
        {
            Title = "",
            Text = "this is a fake text",
            UploadedFile = fileMock.Object
        };
        var result = await validator.TestValidateAsync(posDTO);

        result.ShouldHaveValidationErrorFor(user => user.Title);
    }
}
